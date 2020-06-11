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
using RestaurantBusinessLogic.BusinessLogics;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using RestaurantBusinessLogic.ViewModels;
using System.Runtime.Serialization.Json;

namespace RestaurantView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MainLogic logic;
        private readonly IOrderLogic orderLogic;
        private readonly IRequestLogic requestLogic;
        private readonly IDishLogic dishLogic;
        private readonly IFoodLogic foodLogic;
        private readonly ReportLogic report;

        public FormMain(MainLogic logic, IOrderLogic orderLogic, ReportLogic report,
            IFoodLogic foodLogic, IRequestLogic requestLogic, IDishLogic dishLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.orderLogic = orderLogic;
            this.report = report;
            this.dishLogic = dishLogic;
            this.requestLogic = requestLogic;
            this.foodLogic = foodLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var listOrders = orderLogic.Read(null);
            if (listOrders != null)
            {
                dataGridView.DataSource = listOrders;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView.Columns[6].Visible = false;
            }
            dataGridView.Update();
        }

        private void FoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFoods>();
            form.ShowDialog();
        }

        private void DishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDishes>();
            form.ShowDialog();
        }

        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void ButtonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.TakeOrderInWork(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.FinishOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void продуктыPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportMovingPdf>();
            form.ShowDialog();
        }

        private void блюдаDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        report.SaveOrdersToWordFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Отчет сохранен и отправлен на почту", "Успех", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void блюдаXlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportDishXls>();
            form.ShowDialog();
        }

        private void заказатьПродуктыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateRequest>();
            form.ShowDialog();
        }

        private void посмотретьДоступныеПродуктыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequest>();
            form.ShowDialog();
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    requestLogic.SaveXmlRequest(fbd.SelectedPath);
                    requestLogic.SaveXmlRequestFood(fbd.SelectedPath);
                    dishLogic.SaveXmlDish(fbd.SelectedPath);
                    dishLogic.SaveXmlDishFood(fbd.SelectedPath);
                    orderLogic.SaveXmlOrder(fbd.SelectedPath);
                    foodLogic.SaveXmlFood(fbd.SelectedPath);
                    report.SendMailReport("kristina.zolotareva.14@gmail.com", fbd.SelectedPath, "XML бекап", "xml");
                    MessageBox.Show("Бекап сохранен и отправлен на почту", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    requestLogic.SaveJsonRequest(fbd.SelectedPath);
                    requestLogic.SaveJsonRequestFood(fbd.SelectedPath);
                    dishLogic.SaveJsonDish(fbd.SelectedPath);
                    dishLogic.SaveJsonDishFood(fbd.SelectedPath);
                    orderLogic.SaveJsonOrder(fbd.SelectedPath);
                    foodLogic.SaveJsonFood(fbd.SelectedPath);
                    report.SendMailReport("kristina.zolotareva.14@gmail.com", fbd.SelectedPath, "JSON бекап", "json");
                    MessageBox.Show("Бекап сохранен и отправлен на почту", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}