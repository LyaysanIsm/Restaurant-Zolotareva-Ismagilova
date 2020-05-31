using System;
using System.Windows.Forms;
using Unity;
using RestaurantBusinessLogic.Interfaces;

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
                dataGridViewComponents.Columns[0].Visible = false;
                dataGridViewComponents.Columns[1].Visible = false;
                dataGridViewComponents.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            dataGridViewComponents.Update();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}