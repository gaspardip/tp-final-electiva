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
    public partial class TipoInfraccionForm : Form
    {
        private readonly SistemaInfracciones _sistemaInfracciones;
        private readonly int _codAValidar;


        public TipoInfraccionForm(SistemaInfracciones si, Infraccion inf = null)
        {
            _sistemaInfracciones = si;

            InitializeComponent();
            CenterToParent();
            comboBoxTipo.DataSource = Enum.GetValues(typeof(TipoInfraccion));

            if (inf == null) return;

            CurrentMode = FormMode.Edit;

            Text = "Editar Tipo de Infracción";

            textBoxCod.Text = inf.Codigo.ToString();
            _codAValidar = inf.Codigo;
            textBoxDesc.Text = inf.Descripcion.ToString();
            textBoxAmount.Text = inf.Importe.ToString();
            comboBoxTipo.Text = inf.Tipo.ToString();

        }

        public string Codigo => textBoxCod.Text;
        public string Descripcion => textBoxDesc.Text;
        public string Importe => textBoxAmount.Text;
        public TipoInfraccion Tipo => (TipoInfraccion)comboBoxTipo.SelectedItem;
        public FormMode CurrentMode { get; } = FormMode.Create;

        private void buttonConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Codigo) || string.IsNullOrWhiteSpace(Descripcion) ||
                    string.IsNullOrWhiteSpace(Importe) || string.IsNullOrWhiteSpace(Tipo.ToString()))
                {
                    throw new Exception("Debe completar todos los campos");
                }

                var cod = Validator.ValidateCodigo(Codigo);

                var importe = Validator.ValidateImporte(Importe);

                var codEditado = Validator.CodigoEditado(_codAValidar, cod);


                if (CurrentMode == FormMode.Create)
                {
                    _sistemaInfracciones.CrearInfraccion(cod, Descripcion, importe, Tipo);

                    MessageBox.Show("Infracción creada correctamente", "Infracción Creada", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    _sistemaInfracciones.EditarInfraccion(cod, codEditado, Descripcion, importe, Tipo);

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
