namespace Desktop.Forms
{
    partial class NuevoVehiculoForm
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
            this.textBoxProp = new System.Windows.Forms.TextBox();
            this.buttonConf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dominio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Propietario";
            // 
            // textBoxDom
            // 
            this.textBoxDom.Location = new System.Drawing.Point(98, 52);
            this.textBoxDom.Name = "textBoxDom";
            this.textBoxDom.Size = new System.Drawing.Size(146, 20);
            this.textBoxDom.TabIndex = 2;
            // 
            // textBoxProp
            // 
            this.textBoxProp.Location = new System.Drawing.Point(98, 103);
            this.textBoxProp.Name = "textBoxProp";
            this.textBoxProp.Size = new System.Drawing.Size(146, 20);
            this.textBoxProp.TabIndex = 3;
            // 
            // buttonConf
            // 
            this.buttonConf.Location = new System.Drawing.Point(178, 164);
            this.buttonConf.Name = "buttonConf";
            this.buttonConf.Size = new System.Drawing.Size(75, 23);
            this.buttonConf.TabIndex = 4;
            this.buttonConf.Text = "Confirmar";
            this.buttonConf.UseVisualStyleBackColor = true;
            this.buttonConf.Click += new System.EventHandler(this.buttonConf_Click);
            // 
            // NuevoVehiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 205);
            this.Controls.Add(this.buttonConf);
            this.Controls.Add(this.textBoxProp);
            this.Controls.Add(this.textBoxDom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NuevoVehiculoForm";
            this.Text = "Nuevo Vehiculo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDom;
        private System.Windows.Forms.TextBox textBoxProp;
        private System.Windows.Forms.Button buttonConf;
    }
}