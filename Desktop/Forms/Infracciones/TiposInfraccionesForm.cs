using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Models;
using Desktop.Controls;

namespace Desktop.Forms.Infracciones
{
    public partial class TiposInfraccionesForm : Form
    {
        private readonly SistemaInfracciones _sistema;
        private FilterableDataGridView<Infraccion> _filterableDataGridView;

        public TiposInfraccionesForm(SistemaInfracciones sistema)
        {
            _sistema = sistema;

            InitializeComponent();
            CenterToParent();
            SetupCustomDataGridView();
        }

        private void SetupCustomDataGridView()
        {
            _filterableDataGridView = new FilterableDataGridView<Infraccion>
            {
                Dock = DockStyle.Fill,
                DataFetcher = () => _sistema.Infracciones,
                DisplayProperties = new List<string>
                    { "Codigo", "Descripcion", "Importe", "Tipo" }
            };


            _filterableDataGridView.AddEditButton(OnEditClicked);
            _filterableDataGridView.AddDeleteButton(OnDeleteClicked);

            Controls.Add(_filterableDataGridView);
        }

        private void OnEditClicked(Infraccion infraccion)
        {
            var editInfraccionForm = new TipoInfraccionForm(_sistema, infraccion);

            editInfraccionForm.ShowDialog();
        }

        private void OnDeleteClicked(Infraccion infraccion)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar esta infracción?", "Eliminar infracción",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                _sistema.DarBajaInfraccion(infraccion.Codigo);

                MessageBox.Show("Infracción eliminada correctamente", "Infracción eliminada", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}