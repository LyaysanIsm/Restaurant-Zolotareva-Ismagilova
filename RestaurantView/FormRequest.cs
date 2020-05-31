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
using RestaurantBusinessLogic.ViewModels;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.Enums;

namespace RestaurantView
{
    public partial class FormRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IRequestLogic logic;

        public FormRequest(IRequestLogic logic)
        {
            InitializeComponent();
            this.logic = logic;

        }

        private void FormDisplayStorageMaterials_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            var listRequest = logic.Read(null);
            if (listRequest != null)
            {
                dataGridViewComponents.DataSource = listRequest;
               // dataGridViewComponents.Columns[0].Visible = false;
               // dataGridViewComponents.Columns[1].Visible = false;
                dataGridViewComponents.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            dataGridViewComponents.Update();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}