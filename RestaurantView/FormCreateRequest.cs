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
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using RestaurantBusinessLogic.BusinessLogics;

namespace RestaurantView
{
    public partial class FormCreateRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IRequestLogic requestLogic;
        private readonly ISupplierLogic supplierLogic;
        private readonly MainLogic mainLogic;
        public int ID { set { Id = value; } }
        private int? Id;
        private Dictionary<int, (string, int)> requestFoods;

        public FormCreateRequest(MainLogic mainLogic,
            IRequestLogic requestLogic, ISupplierLogic supplierLogic)
        {
            InitializeComponent();
            this.requestLogic = requestLogic;
            this.supplierLogic = supplierLogic;
            this.mainLogic = mainLogic;
        }

        private void RequestCreationForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            if (Id.HasValue)
            {
                try
                {
                    RequestViewModel request = requestLogic.Read(new RequestBindingModel
                    {
                        Id = Id.Value
                    })?[0];
                    if (request != null)
                    {
                        comboBoxSupplier.SelectedIndex =
                            comboBoxSupplier.FindStringExact(request.SupplierFIO);
                        requestFoods = request.Foods;
                        LoadFoods();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Ошибка загрузки данных заявки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                requestFoods = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                List<SupplierViewModel> suppliersList = supplierLogic.Read(null);
                if (suppliersList != null)
                {
                    comboBoxSupplier.DisplayMember = "Login";
                    comboBoxSupplier.ValueMember = "Id";
                    comboBoxSupplier.DataSource = suppliersList;
                    comboBoxSupplier.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки списка поставщиков",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadFoods()
        {
            try
            {
                if (requestFoods != null)
                {
                    foodsGridView.Rows.Clear();
                    foreach (var requestFood in requestFoods)
                    {
                        foodsGridView.Rows.Add(new object[] {
                            requestFood.Key,
                            requestFood.Value.Item1,
                            requestFood.Value.Item2
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddFoods>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (requestFoods.ContainsKey(form.Id))
                {
                    requestFoods[form.Id] = (form.FoodName, form.Count);
                }
                else
                {
                    requestFoods.Add(form.Id, (form.FoodName, form.Count));
                }
                LoadFoods();
            }
        }

        private void UpdateFoodButton_Click(object sender, EventArgs e)
        {
            if (foodsGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormAddFoods>();
                int Id = Convert.ToInt32(foodsGridView.SelectedRows[0].Cells[0].Value);
                form.Id = Id;
                form.Count = requestFoods[Id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    requestFoods[form.Id] = (form.FoodName, form.Count);
                    LoadFoods();
                }
            }
        }

        private void DeleteFoodButton_Click(object sender, EventArgs e)
        {
            if (foodsGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show(
                    "Действительно хотите удалить продукт?",
                    "Требуется подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        requestFoods.Remove(Convert.ToInt32(foodsGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            ex.Message,
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    LoadFoods();
                }
            }
        }

        private void RefreshFoodsButton_Click(object sender, EventArgs e)
        {
            LoadFoods();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (comboBoxSupplier.SelectedValue == null)
            {
                MessageBox.Show(
                    "Поставщик не выбран",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (requestFoods == null || requestFoods.Count == 0)
            {
                MessageBox.Show(
                    "Не выбрано ни одного продукта",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                mainLogic.CreateOrUpdateRequest(new RequestBindingModel
                {
                    Id = Id,
                    SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue),
                    Foods = requestFoods
                });
                MessageBox.Show(
                    "Сохранение заявки прошло успешно",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void СancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}