using System;
using System.Windows.Forms;
using Business.Models;
using Desktop.Forms.Infracciones;

namespace Desktop.Forms
{
    public partial class SistemaForm : Form
    {
        private readonly SistemaInfracciones _sistema = new SistemaInfracciones();

        public SistemaForm()
        {
            InitializeComponent();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TiposInfraccionesForm(_sistema);

            form.ShowDialog();
        }

        private void nuevoTipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TipoInfraccionForm();

            form.ShowDialog();
        }

        private void verListadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new InfraccionesForm();

            form.ShowDialog();
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RegistrarInfraccionForm();

            form.ShowDialog();
        }
    }
}