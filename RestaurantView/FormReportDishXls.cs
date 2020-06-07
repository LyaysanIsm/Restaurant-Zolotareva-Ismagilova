using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Unity;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.ViewModels;
using RestaurantBusinessLogic.BusinessLogics;

namespace RestaurantView
{
    public partial class FormReportDishXls : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportDishXls(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            dataGridViewFoodToDish.Columns.Add("Блюда", "Блюда");
            dataGridViewFoodToDish.Columns.Add("Продукты", "Продукты");
            dataGridViewFoodToDish.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void FormReportFoodsToDishes_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = logic.GetDishFoods();
                if (dict != null)
                {
                    Dictionary<string, List<ReportDishFoodViewModel>> dishFoods = new Dictionary<string, List<ReportDishFoodViewModel>>();
                    dataGridViewFoodToDish.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        if (!dishFoods.ContainsKey(elem.DishName))
                            dishFoods.Add(elem.DishName, new List<ReportDishFoodViewModel>() { elem });
                        else
                            dishFoods[elem.DishName].Add(elem);
                    }
                    foreach (var order in dishFoods)
                    {
                        dataGridViewFoodToDish.Rows.Add(order.Key, "", "");
                        foreach (var dish in order.Value)
                        {
                            dataGridViewFoodToDish.Rows.Add("", dish.FoodName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveOrdersToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}