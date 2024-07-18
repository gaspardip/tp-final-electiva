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
            this.textBoxDom = new System.Windows.Forms.TextBox();
            this.dateTimePickerFS = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCod = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dominio del vehículo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha del suceso";
            // 
            // textBoxDom
            // 
            this.textBoxDom.Location = new System.Drawing.Point(186, 58);
            this.textBoxDom.Name = "textBoxDom";
            this.textBoxDom.Size = new System.Drawing.Size(148, 20);
            this.textBoxDom.TabIndex = 2;
            // 
            // dateTimePickerFS
            // 
            this.dateTimePickerFS.Location = new System.Drawing.Point(186, 151);
            this.dateTimePickerFS.Name = "dateTimePickerFS";
            this.dateTimePickerFS.Size = new System.Drawing.Size(148, 20);
            this.dateTimePickerFS.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Código de infracción";
            // 
            // textBoxCod
            // 
            this.textBoxCod.Location = new System.Drawing.Point(186, 104);
            this.textBoxCod.Name = "textBoxCod";
            this.textBoxCod.Size = new System.Drawing.Size(148, 20);
            this.textBoxCod.TabIndex = 6;
            // 
            // RegistrarInfraccionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 263);
            this.Controls.Add(this.textBoxCod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePickerFS);
            this.Controls.Add(this.textBoxDom);
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
        private System.Windows.Forms.TextBox textBoxDom;
        private System.Windows.Forms.DateTimePicker dateTimePickerFS;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCod;
    }
}