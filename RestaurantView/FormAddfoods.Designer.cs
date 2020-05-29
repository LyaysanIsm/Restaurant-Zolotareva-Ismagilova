namespace RestaurantView
{
    partial class FormAddFoods
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxCountComponent = new System.Windows.Forms.TextBox();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.labelCountComponent = new System.Windows.Forms.Label();
            this.labelComponentName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxStorages = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(348, 113);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(96, 34);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(227, 113);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 34);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxCountComponent
            // 
            this.textBoxCountComponent.Location = new System.Drawing.Point(107, 81);
            this.textBoxCountComponent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCountComponent.Name = "textBoxCountComponent";
            this.textBoxCountComponent.Size = new System.Drawing.Size(336, 22);
            this.textBoxCountComponent.TabIndex = 9;
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(107, 48);
            this.comboBoxComponent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(336, 24);
            this.comboBoxComponent.TabIndex = 8;
            // 
            // labelCountComponent
            // 
            this.labelCountComponent.AutoSize = true;
            this.labelCountComponent.Location = new System.Drawing.Point(13, 81);
            this.labelCountComponent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCountComponent.Name = "labelCountComponent";
            this.labelCountComponent.Size = new System.Drawing.Size(86, 17);
            this.labelCountComponent.TabIndex = 7;
            this.labelCountComponent.Text = "Количество";
            // 
            // labelComponentName
            // 
            this.labelComponentName.AutoSize = true;
            this.labelComponentName.Location = new System.Drawing.Point(13, 51);
            this.labelComponentName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComponentName.Name = "labelComponentName";
            this.labelComponentName.Size = new System.Drawing.Size(73, 17);
            this.labelComponentName.TabIndex = 6;
            this.labelComponentName.Text = "Продукты";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Поставщик";
            // 
            // comboBoxStorages
            // 
            this.comboBoxStorages.FormattingEnabled = true;
            this.comboBoxStorages.Location = new System.Drawing.Point(107, 15);
            this.comboBoxStorages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxStorages.Name = "comboBoxStorages";
            this.comboBoxStorages.Size = new System.Drawing.Size(336, 24);
            this.comboBoxStorages.TabIndex = 13;
            // 
            // FormAddFoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 155);
            this.Controls.Add(this.comboBoxStorages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCountComponent);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.labelCountComponent);
            this.Controls.Add(this.labelComponentName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormAddFoods";
            this.Text = "Добавление продукты";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxCountComponent;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.Label labelCountComponent;
        private System.Windows.Forms.Label labelComponentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxStorages;
    }
}