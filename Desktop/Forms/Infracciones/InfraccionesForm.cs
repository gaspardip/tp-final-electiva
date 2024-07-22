using System.Collections.Generic;
using System.Windows.Forms;
using Business.Models;
using Desktop.Controls;

namespace Desktop.Forms.Infracciones
{
    public partial class InfraccionesForm : Form
    {
        private readonly SistemaInfracciones _sistema;
        private FilterableDataGridView<RegistroInfraccion> _filterableDataGridView;

        public InfraccionesForm(SistemaInfracciones sistema)
        {
            _sistema = sistema;

            InitializeComponent();
            CenterToParent();
            SetupCustomDataGridView();
        }

        private void SetupCustomDataGridView()
        {
            _filterableDataGridView = new FilterableDataGridView<RegistroInfraccion>
            {
                Dock = DockStyle.Fill,
                DataFetcher = () => _sistema.Registros,
                DisplayProperties = new List<string>
                {
                    "ID", "Infraccion.Descripcion", "VehiculoDominio", "FechaSuceso", "FechaVencimiento",
                    "Infraccion.Importe"
                }
            };

            Controls.Add(_filterableDataGridView);

            _filterableDataGridView.AddEditButton(registro =>
            {
                var form = new RegistrarInfraccionForm(_sistema, registro);

                form.ShowDialog();
            });

            _filterableDataGridView.AddDeleteButton(registro =>
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Eliminar registro",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                try
                {
                    _sistema.EliminarRegistro(registro.ID);

                    MessageBox.Show("Registro eliminado correctamente", "Registro eliminado", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
        }
    }
}