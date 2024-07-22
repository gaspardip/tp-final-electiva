using System;
using System.Windows.Forms;
using Business.Models;
using Desktop.Enums;

namespace Desktop.Forms.Infracciones
{
    public partial class RegistrarInfraccionForm : Form
    {
        private readonly int _id;
        private readonly SistemaInfracciones _sistemaInfracciones;

        public RegistrarInfraccionForm(SistemaInfracciones si, RegistroInfraccion ri = null)
        {
            _sistemaInfracciones = si;

            InitializeComponent();
            CenterToParent();

            var vehiculos = _sistemaInfracciones.Vehiculos;
            var infracciones = _sistemaInfracciones.Infracciones;


            comboBoxDominio.DataSource = vehiculos;
            comboBoxDominio.ValueMember = "Dominio";
            comboBoxDominio.DisplayMember = "Dominio";

            comboBoxInfraccion.DataSource = infracciones;
            comboBoxInfraccion.ValueMember = "ID";
            comboBoxInfraccion.DisplayMember = "Descripcion";

            if (ri == null) return;

            CurrentMode = FormMode.Edit;

            _id = ri.ID;
            dateTimePickerFS.Value = ri.FechaSuceso;
            comboBoxDominio.SelectedItem = vehiculos.Find(vehiculo => vehiculo.Dominio == ri.VehiculoDominio);
            comboBoxInfraccion.SelectedItem = infracciones.Find(infraccion => infraccion.ID == ri.Infraccion.ID);
        }

        public DateTime FechaSuceso => dateTimePickerFS.Value;
        public Vehiculo Vehiculo => (Vehiculo)comboBoxDominio.SelectedItem;
        public Infraccion Infraccion => (Infraccion)comboBoxInfraccion.SelectedItem;
        public FormMode CurrentMode { get; } = FormMode.Create;

        private void buttonConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentMode == FormMode.Create)
                {
                    _sistemaInfracciones.CrearRegistro(Infraccion, Vehiculo.Dominio, FechaSuceso);

                    MessageBox.Show("Registro creado correctamente", "Registro Creado", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    _sistemaInfracciones.EditarRegistro(_id, Infraccion, Vehiculo.Dominio, FechaSuceso);

                    MessageBox.Show("Registro editado correctamente", "Registro Editado", MessageBoxButtons.OK,
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