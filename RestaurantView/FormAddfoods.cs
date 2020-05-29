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
using RestaurantBusinessLogic.BusinessLogics;
using RestaurantBusinessLogic.ViewModels;
using RestaurantBusinessLogic.BindingModels;

namespace RestaurantView
{
    public partial class FormAddFoods : Form
    {
        private readonly MainLogic mainLogic;
        private readonly IRequestLogic requestLogic;
        private readonly IFoodLogic foodLogic;
        private List<RequestViewModel> requestViews;
        private List<FoodViewModel> foodViews;

        public FormAddFoods(MainLogic mainLogic, IRequestLogic requestLogic, IFoodLogic foodLogic)
        {
            InitializeComponent();
            this.mainLogic = mainLogic;
            this.requestLogic = requestLogic;
            this.foodLogic = foodLogic;
            LoadData();
        }

        private void LoadData()
        {
            requestViews = requestLogic.Read(null);
            if (requestViews != null)
            {
                comboBoxStorages.DataSource = requestViews;
                comboBoxStorages.DisplayMember = "SupplierName";
            }
            foodViews = foodLogic.Read(null);
            if (foodViews != null)
            {
                comboBoxComponent.DataSource = foodViews;
                comboBoxComponent.DisplayMember = "FoodName";
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxCountComponent.Text == string.Empty)
                throw new Exception("Введите количество продуктов");

            mainLogic.ReplanishFridge(new ReserveFoodsBindingModel()
            {
                FridgeId = (comboBoxStorages.SelectedItem as FridgeViewModel).Id,
                FoodId = (comboBoxComponent.SelectedItem as FoodViewModel).Id,
                Count = Convert.ToInt32(textBoxCountComponent.Text)
            });
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}