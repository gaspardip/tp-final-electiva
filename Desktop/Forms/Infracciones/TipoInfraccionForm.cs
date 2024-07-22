using System;
using System.Windows.Forms;
using Business;
using Business.Enums;
using Business.Models;
using Desktop.Enums;

namespace Desktop.Forms.Infracciones
{
    public partial class TipoInfraccionForm : Form
    {
        private readonly int _id;
        private readonly SistemaInfracciones _sistemaInfracciones;


        public TipoInfraccionForm(SistemaInfracciones si, Infraccion inf = null)
        {
            _sistemaInfracciones = si;

            InitializeComponent();
            CenterToParent();

            comboBoxTipo.DataSource = Enum.GetValues(typeof(TipoInfraccion));

            if (inf == null) return;

            CurrentMode = FormMode.Edit;

            _id = inf.ID;
            textBoxDesc.Text = inf.Descripcion;
            textBoxAmount.Text = inf.Importe.ToString();
            comboBoxTipo.Text = inf.Tipo.ToString();
        }


        public string Descripcion => textBoxDesc.Text;
        public string Importe => textBoxAmount.Text;
        public TipoInfraccion Tipo => (TipoInfraccion)comboBoxTipo.SelectedItem;
        public FormMode CurrentMode { get; } = FormMode.Create;

        private void buttonConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Descripcion) ||
                    string.IsNullOrWhiteSpace(Importe) || string.IsNullOrWhiteSpace(Tipo.ToString()))
                {
                    throw new Exception("Debe completar todos los campos");
                }

                var importe = Validator.ValidateImporte(Importe);


                if (CurrentMode == FormMode.Create)
                {
                    _sistemaInfracciones.CrearInfraccion(Descripcion, importe, Tipo);

                    MessageBox.Show("Infracción creada correctamente", "Infracción Creada", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    _sistemaInfracciones.EditarInfraccion(_id, Descripcion, importe, Tipo);

                    MessageBox.Show("Infracción editada correctamente", "Infracción Editada", MessageBoxButtons.OK,
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