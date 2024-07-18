using Business.Models;
using System;
using Desktop.Enums;
using System.Windows.Forms;


namespace Desktop.Forms.Infracciones
{
    public partial class RegistrarInfraccionForm : Form
    {
        private readonly SistemaInfracciones _sistemaInfracciones;
        private readonly DateTime _fechaSuceso;
        private readonly DateTime _fechaVencimiento;


        public RegistrarInfraccionForm(SistemaInfracciones si, RegistroInfraccion ri = null)
        {
            _sistemaInfracciones = si;

            InitializeComponent();
            CenterToParent();

        }

        public DateTime FechaSuceso => dateTimePickerFS.Value;
        public DateTime FechaVencimiento => FechaSuceso.AddDays(30);
        public string Dominio => textBoxDom.Text;
        public int Codigo => int.Parse(textBoxCod.Text);

        private void buttonConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Dominio) || string.IsNullOrWhiteSpace(Codigo.ToString()))
                {
                    throw new Exception("Debe completar todos los campos");
                }

                _sistemaInfracciones.CrearRegistro(Codigo, Dominio, _fechaSuceso, _fechaVencimiento);

                MessageBox.Show("Vehículo creado correctamente", "Vehículo Creado", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
