namespace RestaurantView
{
    partial class FormReportDishXls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportDishXls));
            this.dataGridViewFoodToDish = new System.Windows.Forms.DataGridView();
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFoodToDish)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFoodToDish
            // 
            this.dataGridViewFoodToDish.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewFoodToDish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFoodToDish.Location = new System.Drawing.Point(13, 49);
            this.dataGridViewFoodToDish.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewFoodToDish.Name = "dataGridViewFoodToDish";
            this.dataGridViewFoodToDish.RowHeadersWidth = 51;
            this.dataGridViewFoodToDish.Size = new System.Drawing.Size(687, 252);
            this.dataGridViewFoodToDish.TabIndex = 0;
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonSaveToExcel.Location = new System.Drawing.Point(517, 13);
            this.buttonSaveToExcel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(183, 28);
            this.buttonSaveToExcel.TabIndex = 1;
            this.buttonSaveToExcel.Text = "Сохранить в Excel";
            this.buttonSaveToExcel.UseVisualStyleBackColor = false;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // FormReportDishXls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(713, 314);
            this.Controls.Add(this.buttonSaveToExcel);
            this.Controls.Add(this.dataGridViewFoodToDish);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormReportDishXls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Состав блюда";
            this.Load += new System.EventHandler(this.FormReportFoodsToDishes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFoodToDish)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFoodToDish;
        private System.Windows.Forms.Button buttonSaveToExcel;
    }
}