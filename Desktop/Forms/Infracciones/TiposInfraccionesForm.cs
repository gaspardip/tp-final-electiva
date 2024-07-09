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
                    { "ID", "Descripcion", "Importe", "Tipo" }
            };


            //_filterableDataGridView.AddEditButton(OnEditClicked);
            //_filterableDataGridView.AddDeleteButton(OnDeleteClicked);

            Controls.Add(_filterableDataGridView);
        }
    }
}