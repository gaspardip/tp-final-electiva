using Business.Models;
using System;
using Desktop.Enums;
using System.Windows.Forms;


namespace Desktop.Forms
{
    public partial class NuevoVehiculoForm : Form
    {
        private readonly SistemaInfracciones _sistemaInfracciones;
        private readonly int _id;


        public NuevoVehiculoForm(SistemaInfracciones si, Vehiculo veh = null)
        {
            _sistemaInfracciones = si;

            InitializeComponent();
            CenterToParent();

            if (veh == null) return;

            CurrentMode = FormMode.Edit;

            Text = "Editar Vehículo";

            _id = veh.ID;
            textBoxDom.Text = veh.Dominio.ToString();
            textBoxProp.Text = veh.Propietario.ToString();

        }

        public string Dominio => textBoxDom.Text;
        public string Propietario => textBoxProp.Text;
        public FormMode CurrentMode { get; } = FormMode.Create;

        private void buttonConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Dominio) || string.IsNullOrWhiteSpace(Propietario))
                {
                    throw new Exception("Debe completar todos los campos");
                }


                if (CurrentMode == FormMode.Create)
                {
                    _sistemaInfracciones.CrearVehiculo(Dominio, Propietario);

                    MessageBox.Show("Vehículo creado correctamente", "Vehículo Creado", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    _sistemaInfracciones.EditarVehiculo(_id, Dominio, Propietario);

                    MessageBox.Show("Vehículo editado correctamente", "Vehículo Editado", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }

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
