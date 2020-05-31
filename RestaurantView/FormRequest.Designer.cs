namespace RestaurantView
{
    partial class FormRequest
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.dataGridViewComponents = new System.Windows.Forms.DataGridView();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(435, 300);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(96, 30);
            this.buttonOk.TabIndex = 13;
            this.buttonOk.Text = "Ок";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.dataGridViewComponents);
            this.groupBoxComponents.Location = new System.Drawing.Point(22, 13);
            this.groupBoxComponents.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxComponents.Size = new System.Drawing.Size(520, 270);
            this.groupBoxComponents.TabIndex = 11;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Продукты";
            // 
            // dataGridViewComponents
            // 
            this.dataGridViewComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComponents.Location = new System.Drawing.Point(10, 21);
            this.dataGridViewComponents.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewComponents.Name = "dataGridViewComponents";
            this.dataGridViewComponents.RowHeadersWidth = 51;
            this.dataGridViewComponents.Size = new System.Drawing.Size(499, 241);
            this.dataGridViewComponents.TabIndex = 0;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(319, 300);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(96, 30);
            this.buttonUpdate.TabIndex = 14;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // FormRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 353);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBoxComponents);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormRequest";
            this.Text = "Заказы продуктов";
            this.Load += new System.EventHandler(this.FormDisplayStorageMaterials_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.DataGridView dataGridViewComponents;
        private System.Windows.Forms.Button buttonUpdate;
    }
}