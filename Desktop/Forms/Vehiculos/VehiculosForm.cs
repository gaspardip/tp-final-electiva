using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Models;
using Desktop.Controls;

namespace Desktop.Forms
{
    public partial class VehiculosForm : Form
    {
        private readonly SistemaInfracciones _sistema;
        private FilterableDataGridView<Vehiculo> _filterableDataGridView;

        public VehiculosForm(SistemaInfracciones sistema)
        {
            _sistema = sistema;

            InitializeComponent();
            CenterToParent();
            SetupCustomDataGridView();
        }

        private void SetupCustomDataGridView()
        {
            _filterableDataGridView = new FilterableDataGridView<Vehiculo>
            {
                Dock = DockStyle.Fill,
                DataFetcher = () => _sistema.Vehiculos,
                DisplayProperties = new List<string>
                    { "ID", "Dominio" }
            };

            _filterableDataGridView.AddDeleteButton(OnDeleteClicked);

            Controls.Add(_filterableDataGridView);
        }

        private void OnDeleteClicked(Vehiculo vehiculo)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar este vehículo?", "Eliminar vehículo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                _sistema.DarBajaVehiculo(vehiculo.ID);

                MessageBox.Show("Vehículo eliminado correctamente", "Vehículo eliminado", MessageBoxButtons.OK,
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