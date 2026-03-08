using System;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        // --- Navegación del Sistema ---

        private void btnAbrirChoferes_Click(object sender, EventArgs e)
        {
            FrmChoferes pantallaChoferes = new FrmChoferes();
            pantallaChoferes.ShowDialog();
        }

        private void btnAbrirRutas_Click(object sender, EventArgs e)
        {
            FrmRutas pantallaRutas = new FrmRutas();
            pantallaRutas.ShowDialog();
        }

        private void btnAbrirVehiculos_Click(object sender, EventArgs e)
        {
            FrmVehiculos pantallaVehiculos = new FrmVehiculos();
            pantallaVehiculos.ShowDialog();
        }

        private void btnAbrirViajes_Click(object sender, EventArgs e) // Renombrado para consistencia
        {
            FrmViajes pantallaViajes = new FrmViajes();
            pantallaViajes.ShowDialog();
        }

        private void btnAbrirTickets_Click(object sender, EventArgs e)
        {
            FrmTickets pantallaTickets = new FrmTickets();
            pantallaTickets.ShowDialog();
        }

        private void btnAbrirReportes_Click(object sender, EventArgs e)
        {
            FrmReportes pantallaReportes = new FrmReportes();
            pantallaReportes.ShowDialog();
        }
    }
}