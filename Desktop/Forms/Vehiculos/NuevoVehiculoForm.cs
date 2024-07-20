using Business.Models;
using System;
using Desktop.Enums;
using System.Windows.Forms;


namespace Desktop.Forms
{
    public partial class NuevoVehiculoForm : Form
    {
        private readonly SistemaInfracciones _sistemaInfracciones;


        public NuevoVehiculoForm(SistemaInfracciones si, Vehiculo veh = null)
        {
            _sistemaInfracciones = si;

            InitializeComponent();
            CenterToParent();

        }

        public string Dominio => textBoxDom.Text;
        public FormMode CurrentMode { get; } = FormMode.Create;

        private void buttonConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Dominio))
                {
                    throw new Exception("Debe ingresar un dominio");
                }

                _sistemaInfracciones.CrearVehiculo(Dominio);

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
