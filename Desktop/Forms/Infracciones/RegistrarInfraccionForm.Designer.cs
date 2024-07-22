namespace Desktop.Forms.Infracciones
{
    partial class RegistrarInfraccionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerFS = new System.Windows.Forms.DateTimePicker();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxInfraccion = new System.Windows.Forms.ComboBox();
            this.comboBoxDominio = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dominio del vehículo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha del suceso";
            // 
            // dateTimePickerFS
            // 
            this.dateTimePickerFS.Location = new System.Drawing.Point(158, 117);
            this.dateTimePickerFS.Name = "dateTimePickerFS";
            this.dateTimePickerFS.Size = new System.Drawing.Size(148, 20);
            this.dateTimePickerFS.TabIndex = 2;
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(231, 169);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmar.TabIndex = 4;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConf_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Infracción";
            // 
            // comboBoxInfraccion
            // 
            this.comboBoxInfraccion.FormattingEnabled = true;
            this.comboBoxInfraccion.Location = new System.Drawing.Point(158, 70);
            this.comboBoxInfraccion.Name = "comboBoxInfraccion";
            this.comboBoxInfraccion.Size = new System.Drawing.Size(148, 21);
            this.comboBoxInfraccion.TabIndex = 6;
            // 
            // comboBoxDominio
            // 
            this.comboBoxDominio.FormattingEnabled = true;
            this.comboBoxDominio.Location = new System.Drawing.Point(158, 24);
            this.comboBoxDominio.Name = "comboBoxDominio";
            this.comboBoxDominio.Size = new System.Drawing.Size(148, 21);
            this.comboBoxDominio.TabIndex = 6;
            // 
            // RegistrarInfraccionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 216);
            this.Controls.Add(this.comboBoxDominio);
            this.Controls.Add(this.comboBoxInfraccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonConfirmar);
            this.Controls.Add(this.dateTimePickerFS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistrarInfraccionForm";
            this.Text = "Registrar Infracción";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerFS;
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxInfraccion;
        private System.Windows.Forms.ComboBox comboBoxDominio;
    }
}