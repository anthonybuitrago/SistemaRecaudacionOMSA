using CapaNegocios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Formulario contenedor principal y gestor de navegación
    public partial class FrmPrincipal : Form
    {
        // Variables de control de interfaz
        private bool menuExpandido = true;
        private Button botonActivo = null;
        private Form formularioActivo = null;

        // Paleta de colores para el menú de navegación
        private Color colorInactivo = ColorTranslator.FromHtml("#2D2D2D");
        private Color colorActivo = ColorTranslator.FromHtml("#1C1C1C");

        // TODO: [REQUISITO] - Menú de navegación principal con accesos a Entrada, Consulta y Sistema.

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        // ==========================================================
        // GESTIÓN DE NAVEGACIÓN E INTERFAZ
        // ==========================================================

        // Renderiza un formulario hijo dentro del panel central
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

        // ==========================================================
        // SEGURIDAD Y CONTROL DE ACCESO (RBAC)
        // ==========================================================

        // Habilita o deshabilita módulos según el rol del usuario logueado
        private void AplicarPermisos()
        {
            if (Sesion.EsAdministrador)
            {
                btnDespachoViajes.Enabled = true;
                btnVentaTickets.Enabled = true;
                btnChoferes.Enabled = true;
                btnVehiculos.Enabled = true;
                btnRutas.Enabled = true;
                btnReportes.Enabled = true;
            }
            else if (Sesion.EsOperador)
            {
                btnDespachoViajes.Enabled = true;
                btnVentaTickets.Enabled = true;
                btnChoferes.Enabled = false;
                btnVehiculos.Enabled = false;
                btnRutas.Enabled = false;
                btnReportes.Enabled = false;
            }
        }

        // ==========================================================
        // EVENTOS DE CARGA Y MENÚ
        // ==========================================================

        // Inicialización del entorno de trabajo post-login
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ActivarBoton(btnDashboard);
            AbrirFormularioEnPanel(new FrmDashboard());
            AplicarPermisos();
        }

        // Animación de expansión y contracción del menú lateral
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (menuExpandido)
            {
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

        // ==========================================================
        // EVENTOS DE NAVEGACIÓN DIRECTA
        // ==========================================================

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
            if (!Sesion.EsAdministrador)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmChoferes());
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            if (!Sesion.EsAdministrador)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmVehiculos());
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            if (!Sesion.EsAdministrador)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmRutas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (!Sesion.EsAdministrador)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmReportes());
        }

        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmAcercaDe());
        }

        // ==========================================================
        // EVENTOS DE CIERRE DE SESIÓN Y SALIDA
        // ==========================================================

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            ProcesarCierreSesion();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ProcesarCierreSesion();
        }

        // Metodo centralizado para manejar la salida del usuario
        private void ProcesarCierreSesion()
        {
            var confirmacion = MessageBox.Show(
                "¿Estás seguro que querés cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                Sesion.CerrarSesion();
                this.Hide();

                FrmLogin login = new FrmLogin();

                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Login exitoso, se aplican permisos y se muestra el entorno
                    AplicarPermisos();
                    this.Show();
                }
                else
                {
                    // Cierre definitivo del sistema
                    Application.Exit();
                }
            }
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {
            // Evento reservado para renderizado personalizado del contenedor si se requiere en el futuro
        }
    }
}