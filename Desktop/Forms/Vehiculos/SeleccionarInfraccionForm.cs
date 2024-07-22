using Desktop.Controls;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Desktop.Forms.Vehiculos
{
    public partial class SeleccionarInfraccionForm : Form
    {
        private readonly SistemaInfracciones _sistema;
        private readonly Vehiculo _vehiculo;
        private FilterableDataGridView<RegistroInfraccion> _filterableDataGridView;

        public SeleccionarInfraccionForm(SistemaInfracciones sistema, Vehiculo vehiculo)
        {
            _sistema = sistema;
            _vehiculo = vehiculo;
            InitializeComponent();
            CenterToParent();
            SetupCustomDataGridView();
        }

        private void SetupCustomDataGridView()
        {
            _filterableDataGridView = new FilterableDataGridView<RegistroInfraccion>
            {
                Dock = DockStyle.Fill,
                DataFetcher = () => _sistema.GetRegistrosPendientes(_vehiculo.Dominio),
                DisplayProperties = new List<string> { "ID", "InfraccionID", "VehiculoDominio", "FechaSuceso", "FechaVencimiento", "Importe" }
            };

            _filterableDataGridView.AddCustomButton("Registrar pago", OnRegisterPaymentClicked);

            Controls.Add(_filterableDataGridView);

        }

        private void OnRegisterPaymentClicked(RegistroInfraccion registroInfraccion)
        {
            if (MessageBox.Show("¿Está seguro que desea registrar este pago?", "Registrar pago",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                _sistema.RegistrarPagoVehiculo(registroInfraccion);

                MessageBox.Show("Pago registrado correctamente", "Pago registrado", MessageBoxButtons.OK,
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
