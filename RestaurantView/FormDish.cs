using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using RestaurantBusinessLogic.BindingModels;

namespace RestaurantView
{
    public partial class FormDish : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IDishLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> dishFoods;

        public FormDish(IDishLogic service)
        {
            InitializeComponent();
            dataGridViewComponents.Columns.Add("Id", "Id");
            dataGridViewComponents.Columns.Add("FoodName", "Материал");
            dataGridViewComponents.Columns.Add("Count", "Количество");
            dataGridViewComponents.Columns[0].Visible = false;
            dataGridViewComponents.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.logic = service;
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DishViewModel view = logic.Read(new DishBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxNameProduct.Text = view.DishName;
                        textBoxPrice.Text = view.Price.ToString();
                        dishFoods = view.DishFoods;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dishFoods = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (dishFoods != null)
                {
                    dataGridViewComponents.Rows.Clear();
                    foreach (var pc in dishFoods)
                    {
                        dataGridViewComponents.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка tyta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDishesFood>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (dishFoods.ContainsKey(form.Id))
                {
                    dishFoods[form.Id] = (form.FoodName, form.Count);
                }
                else
                {
                    dishFoods.Add(form.Id, (form.FoodName, form.Count));
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormDishesFood>();
                int id = Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = dishFoods[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    dishFoods[form.Id] = (form.FoodName, form.Count);
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        dishFoods.Remove(Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNameProduct.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dishFoods == null || dishFoods.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new DishBindingModel
                {
                    Id = id ?? null,
                    DishName = textBoxNameProduct.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    DishFoods = dishFoods
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}