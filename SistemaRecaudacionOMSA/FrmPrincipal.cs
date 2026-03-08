using System;
using System.Drawing;
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
            AbrirFormularioEnPanel(new FrmChoferes());
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
        // Método para abrir formularios dentro del panel central
        private void AbrirFormularioEnPanel(object formularioHijo)
        {
            // Si ya hay algo abierto en el panel, lo cerramos
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);

            // Convertimos el objeto a Form
            Form fh = formularioHijo as Form;

            // Configuraciones clave para incrustarlo
            fh.TopLevel = false; // Le decimos que ya no es una ventana independiente
            fh.Dock = DockStyle.Fill; // Que llene el panel
            fh.FormBorderStyle = FormBorderStyle.None; // Le quitamos los bordes y la X de cerrar

            // Lo agregamos y lo mostramos
            this.pnlContenedor.Controls.Add(fh);
            this.pnlContenedor.Tag = fh;
            fh.Show();
        }
        private void AplicarEfectoHover(Button btn)
        {
            btn.MouseEnter += (s, e) => {
                btn.BackColor = ColorTranslator.FromHtml("#00843D"); // Se pone Verde OMSA al pasar el mouse
            };

            btn.MouseLeave += (s, e) => {
                btn.BackColor = ColorTranslator.FromHtml("#2D2D2D"); // Vuelve a Gris oscuro al quitarlo
            };
        }
    }
}