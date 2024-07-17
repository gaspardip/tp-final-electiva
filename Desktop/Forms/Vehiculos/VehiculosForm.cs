using Business.Models;
using Desktop.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    { "Dominio", "Propietario" }
            };


            _filterableDataGridView.AddEditButton(OnEditClicked);
            _filterableDataGridView.AddDeleteButton(OnDeleteClicked);

            Controls.Add(_filterableDataGridView);
        }

        private void OnEditClicked(Vehiculo vehiculo)
        {
            var editVehiculoForm = new NuevoVehiculoForm(_sistema, vehiculo);

            editVehiculoForm.ShowDialog();
        }

        private void OnDeleteClicked(Vehiculo vehiculo)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar este vehículo?", "Eliminar vehículo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                _sistema.DarBajaVehiculo(vehiculo.Dominio);

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
