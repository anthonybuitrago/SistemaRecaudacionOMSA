using CapaPresentacion;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmPrincipal : Form
    {
        // Variables de estado
        private Button botonActivo = null;
        private Form formularioActivo = null;

        // Colores de la interfaz
        private Color colorInactivo = ColorTranslator.FromHtml("#2D2D2D"); // Gris oscuro
        private Color colorActivo = ColorTranslator.FromHtml("#1C1C1C");   // Gris más profundo / Activo

        bool menuExpandido = true;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        // =====================================================================
        // 1. MOTOR PRINCIPAL: ABRIR FORMULARIOS EN EL PANEL CENTRAL
        // =====================================================================
        private void AbrirFormularioEnPanel(Form formularioHijo)
        {
            // Si hay un formulario previo, lo cerramos para liberar memoria
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // Limpiamos el contenedor antes de agregar el nuevo
            this.pnlContenedor.Controls.Clear();
            this.pnlContenedor.Controls.Add(formularioHijo);
            this.pnlContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        // =====================================================================
        // 2. EFECTOS VISUALES: GESTIÓN DE BOTONES
        // =====================================================================
        private void ActivarBoton(Button btn)
        {
            if (btn != null)
            {
                RestaurarColoresBotones();
                botonActivo = btn;
                botonActivo.BackColor = colorActivo;
            }
        }

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

        // =====================================================================
        // 3. EVENTOS DE CARGA Y NAVEGACIÓN
        // =====================================================================

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Llamamos directamente al nombre del botón, sin usar (Button)sender
            ActivarBoton(btnDashboard);

            // Abrimos el dashboard de una vez
            AbrirFormularioEnPanel(new FrmDashboard());
        }

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

        // =====================================================================
        // 4. ANIMACIÓN DEL MENÚ LATERAL
        // =====================================================================
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (menuExpandido)
            {
                // --- COLAPSAR ---
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
                // --- EXPANDIR ---
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