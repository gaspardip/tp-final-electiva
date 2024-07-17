using Business.Models;
using System;
using Desktop.Enums;
using Business;
using Business.Enums;
using System.Windows.Forms;
using System.Net;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Desktop.Forms
{
    public partial class NuevoVehiculoForm : Form
    {
        private readonly SistemaInfracciones _sistemaInfracciones;
        private readonly string _domAValidar;


        public NuevoVehiculoForm(SistemaInfracciones si, Vehiculo veh = null)
        {
            _sistemaInfracciones = si;

            InitializeComponent();
            CenterToParent();

            if (veh == null) return;

            CurrentMode = FormMode.Edit;

            Text = "Editar Vehículo";

            textBoxDom.Text = veh.Dominio.ToString();
            _domAValidar = veh.Dominio.ToString(); ;
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

                var codEditado = Validator.DominioEditado(_domAValidar, Dominio);

                if (CurrentMode == FormMode.Create)
                {
                    _sistemaInfracciones.CrearVehiculo(Dominio, Propietario);

                    MessageBox.Show("Vehículo creado correctamente", "Vehículo Creado", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    _sistemaInfracciones.EditarVehiculo(Dominio, codEditado, Propietario);

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
