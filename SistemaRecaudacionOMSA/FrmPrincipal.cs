using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Formulario contenedor principal con menú lateral animado y panel de navegación
    public partial class FrmPrincipal : Form
    {
        // Gestión de estado de la interfaz
        private Button botonActivo = null;
        private Form formularioActivo = null;

        // Definición de la paleta de colores corporativa
        private Color colorInactivo = ColorTranslator.FromHtml("#2D2D2D");
        private Color colorActivo = ColorTranslator.FromHtml("#1C1C1C");
        private bool menuExpandido = true;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Carga inicial del Dashboard
            ActivarBoton(btnDashboard);
            AbrirFormularioEnPanel(new FrmDashboard());
        }

        // Carga un formulario hijo dentro del panel contenedor central
        private void AbrirFormularioEnPanel(Form formularioHijo)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            this.pnlContenedor.Controls.Clear();
            this.pnlContenedor.Controls.Add(formularioHijo);
            this.pnlContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        // Resalta visualmente el botón seleccionado en el menú lateral
        private void ActivarBoton(Button btn)
        {
            if (btn != null)
            {
                RestaurarColoresBotones();
                botonActivo = btn;
                botonActivo.BackColor = colorActivo;
            }
        }

        // Restablece el color de fondo de todos los botones del menú
        private void RestaurarColoresBotones()
        {
            foreach (Control control in pnlLateral.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = colorInactivo;
                }
            }
        }

        // --- MANEJADORES DE EVENTOS DE NAVEGACIÓN ---

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmDashboard());
        }

        private void btnDespachoViajes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmViajes());
        }

        private void btnVentaTickets_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmTickets());
        }

        private void btnChoferes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmChoferes());
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmVehiculos());
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmRutas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmReportes());
        }

        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmAcercaDe());
        }

        // Gestiona la animación de expansión y colapso del menú lateral
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (menuExpandido)
            {
                // Colapsar menú
                pnlLateral.Width = 65;
                lblOperacion.Visible = lblAdministracion.Visible = lblSistema.Visible = false;

                foreach (Control control in pnlLateral.Controls)
                {
                    if (control is Button btn)
                    {
                        if (btn.Tag == null || string.IsNullOrEmpty(btn.Tag.ToString()))
                            btn.Tag = btn.Text;
                        btn.Text = "";
                    }
                }
                menuExpandido = false;
            }
            else
            {
                // Expandir menú
                pnlLateral.Width = 250;
                lblOperacion.Visible = lblAdministracion.Visible = lblSistema.Visible = true;

                foreach (Control control in pnlLateral.Controls)
                {
                    if (control is Button btn && btn.Tag != null)
                        btn.Text = btn.Tag.ToString();
                }
                menuExpandido = true;
            }
        }
    }
}