namespace RestaurantView
{
    partial class FormReportMovingPdf
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportMovingPdf));
            this.ReportOrdersViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCreateToPdf = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.ReportFoodViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportFoodViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportOrdersViewModelBindingSource
            // 
            this.ReportOrdersViewModelBindingSource.DataSource = typeof(RestaurantBusinessLogic.ViewModels.ReportOrdersViewModel);
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonCreate.Location = new System.Drawing.Point(658, 13);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(133, 34);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Сформировать";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // buttonCreateToPdf
            // 
            this.buttonCreateToPdf.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonCreateToPdf.Location = new System.Drawing.Point(799, 13);
            this.buttonCreateToPdf.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateToPdf.Name = "buttonCreateToPdf";
            this.buttonCreateToPdf.Size = new System.Drawing.Size(121, 34);
            this.buttonCreateToPdf.TabIndex = 3;
            this.buttonCreateToPdf.Text = "В PDF";
            this.buttonCreateToPdf.UseVisualStyleBackColor = false;
            this.buttonCreateToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "RestaurantView.ReportMoving.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(13, 55);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(907, 372);
            this.reportViewer.TabIndex = 4;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(489, 22);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(161, 22);
            this.dateTimePickerTo.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "по";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "С";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(288, 22);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(161, 22);
            this.dateTimePickerFrom.TabIndex = 11;
            // 
            // ReportFoodViewModelBindingSource
            // 
            this.ReportFoodViewModelBindingSource.DataSource = typeof(RestaurantBusinessLogic.ViewModels.ReportFoodViewModel);
            // 
            // FormReportMovingPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(931, 442);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonCreateToPdf);
            this.Controls.Add(this.buttonCreate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormReportMovingPdf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Движение продуктов";
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportFoodViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCreateToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportOrdersViewModelBindingSource;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.BindingSource ReportFoodViewModelBindingSource;
    }
}