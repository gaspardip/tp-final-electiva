using System;
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
                    { "ID", "InfraccionCod", "VehiculoDom", "FechaSuceso", "FechaVencimiento" }
            };


            Controls.Add(_filterableDataGridView);
        }
    }
}