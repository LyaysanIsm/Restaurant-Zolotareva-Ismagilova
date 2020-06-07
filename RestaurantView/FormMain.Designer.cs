﻿namespace RestaurantView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.блюдаDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.блюдаXlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.продуктыPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказатьПродуктыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.посмотретьДоступныеПродуктыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.ButtonPayOrder = new System.Windows.Forms.Button();
            this.ButtonOrderReady = new System.Windows.Forms.Button();
            this.ButtonTakeOrderInWork = new System.Windows.Forms.Button();
            this.coздатьBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 32);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(696, 281);
            this.dataGridView.TabIndex = 0;
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.AliceBlue;
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.заказыToolStripMenuItem,
            this.coздатьBackupToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(934, 28);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.компонентыToolStripMenuItem.Text = "Продукты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.FoodsToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.изделияToolStripMenuItem.Text = "Блюда";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.DishesToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.блюдаDocToolStripMenuItem,
            this.блюдаXlsToolStripMenuItem,
            this.продуктыPdfToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // блюдаDocToolStripMenuItem
            // 
            this.блюдаDocToolStripMenuItem.Name = "блюдаDocToolStripMenuItem";
            this.блюдаDocToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.блюдаDocToolStripMenuItem.Text = "Блюда (doc)";
            this.блюдаDocToolStripMenuItem.Click += new System.EventHandler(this.блюдаDocToolStripMenuItem_Click);
            // 
            // блюдаXlsToolStripMenuItem
            // 
            this.блюдаXlsToolStripMenuItem.Name = "блюдаXlsToolStripMenuItem";
            this.блюдаXlsToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.блюдаXlsToolStripMenuItem.Text = "Блюда (xls)";
            this.блюдаXlsToolStripMenuItem.Click += new System.EventHandler(this.блюдаXlsToolStripMenuItem_Click);
            // 
            // продуктыPdfToolStripMenuItem
            // 
            this.продуктыPdfToolStripMenuItem.Name = "продуктыPdfToolStripMenuItem";
            this.продуктыPdfToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.продуктыPdfToolStripMenuItem.Text = "Движение продуктов (pdf)";
            this.продуктыPdfToolStripMenuItem.Click += new System.EventHandler(this.продуктыPdfToolStripMenuItem_Click);
            // 
            // заказыToolStripMenuItem
            // 
            this.заказыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заказатьПродуктыToolStripMenuItem,
            this.посмотретьДоступныеПродуктыToolStripMenuItem});
            this.заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            this.заказыToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.заказыToolStripMenuItem.Text = "Заказы";
            // 
            // заказатьПродуктыToolStripMenuItem
            // 
            this.заказатьПродуктыToolStripMenuItem.Name = "заказатьПродуктыToolStripMenuItem";
            this.заказатьПродуктыToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.заказатьПродуктыToolStripMenuItem.Text = "Заказать продукты";
            this.заказатьПродуктыToolStripMenuItem.Click += new System.EventHandler(this.заказатьПродуктыToolStripMenuItem_Click);
            // 
            // посмотретьДоступныеПродуктыToolStripMenuItem
            // 
            this.посмотретьДоступныеПродуктыToolStripMenuItem.Name = "посмотретьДоступныеПродуктыToolStripMenuItem";
            this.посмотретьДоступныеПродуктыToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.посмотретьДоступныеПродуктыToolStripMenuItem.Text = "Заказы";
            this.посмотретьДоступныеПродуктыToolStripMenuItem.Click += new System.EventHandler(this.посмотретьДоступныеПродуктыToolStripMenuItem_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonCreateOrder.Location = new System.Drawing.Point(717, 32);
            this.buttonCreateOrder.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(205, 32);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = false;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonRefresh.Location = new System.Drawing.Point(717, 281);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(205, 32);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Обновить список";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // ButtonPayOrder
            // 
            this.ButtonPayOrder.BackColor = System.Drawing.Color.AliceBlue;
            this.ButtonPayOrder.Location = new System.Drawing.Point(717, 152);
            this.ButtonPayOrder.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonPayOrder.Name = "ButtonPayOrder";
            this.ButtonPayOrder.Size = new System.Drawing.Size(205, 32);
            this.ButtonPayOrder.TabIndex = 7;
            this.ButtonPayOrder.Text = "Заказ оплачен";
            this.ButtonPayOrder.UseVisualStyleBackColor = false;
            this.ButtonPayOrder.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // ButtonOrderReady
            // 
            this.ButtonOrderReady.BackColor = System.Drawing.Color.AliceBlue;
            this.ButtonOrderReady.Location = new System.Drawing.Point(717, 112);
            this.ButtonOrderReady.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonOrderReady.Name = "ButtonOrderReady";
            this.ButtonOrderReady.Size = new System.Drawing.Size(205, 32);
            this.ButtonOrderReady.TabIndex = 8;
            this.ButtonOrderReady.Text = "Заказ готов";
            this.ButtonOrderReady.UseVisualStyleBackColor = false;
            this.ButtonOrderReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            // 
            // ButtonTakeOrderInWork
            // 
            this.ButtonTakeOrderInWork.BackColor = System.Drawing.Color.AliceBlue;
            this.ButtonTakeOrderInWork.Location = new System.Drawing.Point(717, 72);
            this.ButtonTakeOrderInWork.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonTakeOrderInWork.Name = "ButtonTakeOrderInWork";
            this.ButtonTakeOrderInWork.Size = new System.Drawing.Size(205, 32);
            this.ButtonTakeOrderInWork.TabIndex = 9;
            this.ButtonTakeOrderInWork.Text = "Выполнить";
            this.ButtonTakeOrderInWork.UseVisualStyleBackColor = false;
            this.ButtonTakeOrderInWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
            // 
            // coздатьBackupToolStripMenuItem
            // 
            this.coздатьBackupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMLToolStripMenuItem,
            this.jSONToolStripMenuItem});
            this.coздатьBackupToolStripMenuItem.Name = "coздатьBackupToolStripMenuItem";
            this.coздатьBackupToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.coздатьBackupToolStripMenuItem.Text = "Coздать backup";
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.xMLToolStripMenuItem.Text = "XML";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.xMLToolStripMenuItem_Click);
            // 
            // jSONToolStripMenuItem
            // 
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.jSONToolStripMenuItem.Text = "JSON";
            this.jSONToolStripMenuItem.Click += new System.EventHandler(this.jSONToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(934, 326);
            this.Controls.Add(this.ButtonTakeOrderInWork);
            this.Controls.Add(this.ButtonOrderReady);
            this.Controls.Add(this.ButtonPayOrder);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кафе";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private new System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem блюдаDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem блюдаXlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem продуктыPdfToolStripMenuItem;
        private System.Windows.Forms.Button ButtonPayOrder;
        private System.Windows.Forms.Button ButtonOrderReady;
        private System.Windows.Forms.Button ButtonTakeOrderInWork;
        private System.Windows.Forms.ToolStripMenuItem заказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказатьПродуктыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem посмотретьДоступныеПродуктыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coздатьBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem;
    }
}