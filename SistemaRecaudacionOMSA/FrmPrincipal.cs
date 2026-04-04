using CapaPresentacion;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmPrincipal : Form
    {
        // Variables para recordar qué botón está seleccionado y qué formulario está abierto
        private Button botonActivo = null;
        private Form formularioActivo = null;

        // Colores de la OMSA para tu diseño
        private Color colorInactivo = ColorTranslator.FromHtml("#2D2D2D"); // Gris oscuro
        private Color colorActivo = ColorTranslator.FromHtml("#1C1C1C");   // Verde

        // Variable para saber si el menú está expandido o encogido
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
            // Si ya hay un formulario abierto, lo cerramos para hacer espacio
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            // Configuramos el nuevo formulario para que se comporte como un panel
            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // Lo agregamos al contenedor blanco y lo mostramos
            this.pnlContenedor.Controls.Add(formularioHijo);
            this.pnlContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        // =====================================================================
        // 2. EFECTOS VISUALES: ACTIVAR Y RESTAURAR BOTONES
        // =====================================================================
        private void ActivarBoton(Button btn)
        {
            if (btn != null)
            {
                RestaurarColoresBotones(); // Apaga todos los botones
                botonActivo = btn;
                botonActivo.BackColor = colorActivo; // Enciende de verde el que clickeamos
            }
        }

        private void RestaurarColoresBotones()
        {
            // Busca todos los controles dentro de tu panel lateral principal
            foreach (Control control in pnlLateral.Controls)
            {
                // Si el control es un botón, lo vuelve a pintar de gris oscuro
                if (control is Button)
                {
                    control.BackColor = colorInactivo;
                }
            }
        }

        // =====================================================================
        // 3. EVENTOS DE LOS BOTONES DEL MENÚ (CLICK)
        // =====================================================================

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            // Si creas un FrmDashboard más adelante, descomenta la siguiente línea:
            // AbrirFormularioEnPanel(new FrmDashboard());
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
        // 4. ANIMACIÓN DEL MENÚ HAMBURGUESA (YOUTUBE STYLE)
        // =====================================================================
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (menuExpandido)
            {
                // --- COLAPSAR ---
                pnlLateral.Width = 65;

                lblOperacion.Visible = false;
                lblAdministracion.Visible = false;
                lblSistema.Visible = false;

                foreach (Control control in pnlLateral.Controls)
                {
                    if (control is Button btn)
                    {
                        // Si la mochila está vacía, guardamos el texto antes de borrarlo
                        if (btn.Tag == null || string.IsNullOrEmpty(btn.Tag.ToString()))
                        {
                            btn.Tag = btn.Text;
                        }
                        btn.Text = "";
                    }
                }
                menuExpandido = false;
            }
            else
            {
                // --- EXPANDIR ---
                pnlLateral.Width = 250; // Ajusta a tu ancho real

                lblOperacion.Visible = true;
                lblAdministracion.Visible = true;
                lblSistema.Visible = true;

                foreach (Control control in pnlLateral.Controls)
                {
                    if (control is Button btn)
                    {
                        // Si por alguna razón la mochila está vacía, le ponemos un nombre manual
                        // para que no se quede en blanco (esto es un salvavidas)
                        if (btn.Tag != null)
                        {
                            btn.Text = btn.Tag.ToString();
                        }
                        else
                        {
                            // Esto solo pasará si algo salió muy mal, 
                            // te ayudará a ver qué botones están fallando.
                            btn.Text = "Revisar";
                        }
                    }
                }
                menuExpandido = true;
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        /*private void tmrMenu_Tick(object sender, EventArgs e)
        {
            if (menuExpandido == true)
            {
                // 1. MAGIA: Borramos el texto de todos los botones INMEDIATAMENTE
                foreach (Control control in pnlLateral.Controls)
                {
                    if (control is Button) control.Text = "";
                }

                // 2. Ocultamos los Labels de los títulos
                lblOperacion.Visible = false;
                lblAdministracion.Visible = false; // Asegúrate de que el nombre sea correcto
                lblSistema.Visible = false;

                // 3. Encogemos el panel
                pnlLateral.Width -= 10;

                if (pnlLateral.Width <= 65)
                {
                    pnlLateral.Width = 65;
                    menuExpandido = false;
                    tmrMenu.Stop();
                }
            }
            else
            {
                // 1. Expandimos el panel
                pnlLateral.Width += 10;

                if (pnlLateral.Width >= 250) // Reemplaza 250 por tu ancho original exacto
                {
                    pnlLateral.Width = 250;
                    menuExpandido = true;
                    tmrMenu.Stop();

                    // 2. Mostramos los Labels de los títulos de nuevo
                    lblOperacion.Visible = true;
                    lblAdministracion.Visible = true;
                    lblSistema.Visible = true;

                    // 3. MAGIA: Recuperamos el texto de la mochila de los botones
                    foreach (Control control in pnlLateral.Controls)
                    {
                        if (control is Button && control.Tag != null)
                        {
                            control.Text = control.Tag.ToString();
                        }
                    }
                }
            }
        }*/
    }

}