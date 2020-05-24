namespace RestaurantView
{
    partial class FormDish
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
            this.labelNameProduct = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxNameProduct = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAddComponent = new System.Windows.Forms.Button();
            this.dataGridViewComponents = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNameProduct
            // 
            this.labelNameProduct.AutoSize = true;
            this.labelNameProduct.Location = new System.Drawing.Point(25, 26);
            this.labelNameProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNameProduct.Name = "labelNameProduct";
            this.labelNameProduct.Size = new System.Drawing.Size(76, 17);
            this.labelNameProduct.TabIndex = 0;
            this.labelNameProduct.Text = "Название:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(57, 62);
            this.labelPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(47, 17);
            this.labelPrice.TabIndex = 1;
            this.labelPrice.Text = "Цена:";
            // 
            // textBoxNameProduct
            // 
            this.textBoxNameProduct.Location = new System.Drawing.Point(113, 22);
            this.textBoxNameProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNameProduct.Name = "textBoxNameProduct";
            this.textBoxNameProduct.Size = new System.Drawing.Size(229, 22);
            this.textBoxNameProduct.TabIndex = 2;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(113, 58);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(111, 22);
            this.textBoxPrice.TabIndex = 3;
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.buttonDelete);
            this.groupBoxComponents.Controls.Add(this.buttonRefresh);
            this.groupBoxComponents.Controls.Add(this.buttonUpdate);
            this.groupBoxComponents.Controls.Add(this.buttonAddComponent);
            this.groupBoxComponents.Controls.Add(this.dataGridViewComponents);
            this.groupBoxComponents.Location = new System.Drawing.Point(16, 103);
            this.groupBoxComponents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxComponents.Size = new System.Drawing.Size(621, 270);
            this.groupBoxComponents.TabIndex = 4;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Продукты";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(517, 97);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(96, 30);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(517, 134);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(96, 30);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(517, 60);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(96, 30);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // buttonAddComponent
            // 
            this.buttonAddComponent.Location = new System.Drawing.Point(517, 23);
            this.buttonAddComponent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAddComponent.Name = "buttonAddComponent";
            this.buttonAddComponent.Size = new System.Drawing.Size(96, 30);
            this.buttonAddComponent.TabIndex = 1;
            this.buttonAddComponent.Text = "Добавить";
            this.buttonAddComponent.UseVisualStyleBackColor = true;
            this.buttonAddComponent.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // dataGridViewComponents
            // 
            this.dataGridViewComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComponents.Location = new System.Drawing.Point(11, 27);
            this.dataGridViewComponents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewComponents.Name = "dataGridViewComponents";
            this.dataGridViewComponents.RowHeadersWidth = 51;
            this.dataGridViewComponents.Size = new System.Drawing.Size(499, 241);
            this.dataGridViewComponents.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(413, 379);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 30);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(533, 379);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(96, 30);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.MouseCaptureChanged += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormDish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 412);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxNameProduct);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelNameProduct);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormDish";
            this.Text = "Блюдо";
            this.Load += new System.EventHandler(this.FormProduct_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNameProduct;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxNameProduct;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAddComponent;
        private System.Windows.Forms.DataGridView dataGridViewComponents;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}