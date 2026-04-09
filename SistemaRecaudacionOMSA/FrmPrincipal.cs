using CapaPresentacion;
using OMSA_Recaudacion.CapaNegocio;
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
        private Color colorInactivo = ColorTranslator.FromHtml("#2D2D2D");
        private Color colorActivo = ColorTranslator.FromHtml("#1C1C1C");

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
        // 3. PERMISOS SEGÚN ROL
        // =====================================================================
        private void AplicarPermisos()
        {
            // Mostrar usuario logueado si tenés esos labels
            // lblUsuario.Text = Sesion.NombreUsuario;
            // lblRol.Text     = Sesion.Rol;

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

        // =====================================================================
        // 4. EVENTOS DE CARGA Y NAVEGACIÓN
        // =====================================================================
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ActivarBoton(btnDashboard);
            AbrirFormularioEnPanel(new FrmDashboard());
            AplicarPermisos();
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
            if (!Sesion.EsAdministrador)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.",
                                "Acceso denegado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmChoferes());
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            if (!Sesion.EsAdministrador)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.",
                                "Acceso denegado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmVehiculos());
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            if (!Sesion.EsAdministrador)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.",
                                "Acceso denegado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmRutas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (!Sesion.EsAdministrador)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.",
                                "Acceso denegado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
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

        // =====================================================================
        // 5. CERRAR SESIÓN
        // =====================================================================
        private void btnCerrarSesion_Click(object sender, EventArgs e)
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
                    this.Show();
                else
                    Application.Exit();
            }
        }

        // =====================================================================
        // 6. ANIMACIÓN DEL MENÚ LATERAL
        // =====================================================================
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

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
        }
    }
}