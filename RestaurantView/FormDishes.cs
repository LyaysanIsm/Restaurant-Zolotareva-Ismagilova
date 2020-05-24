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
using RestaurantBusinessLogic.BindingModels;


namespace RestaurantView
{
    public partial class FormDishes : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IDishLogic logic;

        public FormDishes(IDishLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormDisplayDishes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridViewDishes.DataSource = list;
                    dataGridViewDishes.Columns[0].Visible = false;
                    dataGridViewDishes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewDishes.Columns[3].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDish>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewDishes.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormDish>();
                form.Id = Convert.ToInt32(dataGridViewDishes.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewDishes.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewDishes.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new DishBindingModel { Id = id });
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
    }
}