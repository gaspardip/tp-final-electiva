using Business.Models;
using System.Windows.Forms;
using Desktop.Controls;
using System.Collections.Generic;

namespace Desktop.Forms.Vehiculos
{
    public partial class VehiculosSinPagarForm : Form
    {
        private readonly SistemaInfracciones _sistema;
        private FilterableDataGridView<Vehiculo> _filterableDataGridView;

        public VehiculosSinPagarForm(SistemaInfracciones sistema)
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
                DataFetcher = () => _sistema.VehiculosSinPagar,
                DisplayProperties = new List<string> { "ID", "Dominio", "Propietario" }
            };

            _filterableDataGridView.AddCustomButton("Ver Infracciones", OnViewInfringementsClicked);

            Controls.Add(_filterableDataGridView);
        }

        private void OnViewInfringementsClicked(Vehiculo vehiculo)
        {
            var seleccionarOrdenForm = new SeleccionarInfraccionForm(_sistema, vehiculo);

            seleccionarOrdenForm.ShowDialog();
        }
    }
}
