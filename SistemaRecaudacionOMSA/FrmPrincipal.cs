using CapaPresentacion;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmPrincipal : Form
    {
        // Variable para recordar qué botón del menú está seleccionado actualmente
        private Button botonActivo = null;
        private Color colorInactivo = ColorTranslator.FromHtml("#2D2D2D");

        // Constructor que inicializa la ventana principal y prepara las animaciones del menú
        public FrmPrincipal()
        {
            InitializeComponent();

            // 1. Aplicamos el efecto Hover a TODOS los botones automáticamente
            foreach (Control btn in pnlSubMenuEntrada.Controls) if (btn is Button) AplicarEfectoHover((Button)btn);
            foreach (Control btn in pnlSubMenuConsulta.Controls) if (btn is Button) AplicarEfectoHover((Button)btn);
            foreach (Control btn in pnlSubMenuSistema.Controls) if (btn is Button) AplicarEfectoHover((Button)btn);

            PersonalizarDiseno();

            this.pnlContenedor.Controls.Clear();

            // 2. Cargamos el logo
            this.pnlContenedor.BackgroundImage = Properties.Resources.omsa_logo1;
            this.pnlContenedor.BackgroundImageLayout = ImageLayout.Zoom;
        }

        // Evento que abre automáticamente la sección de Choferes al iniciar el sistema
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        // Evento para abrir la sección de Reportes y resaltar su botón
        private void btnAbrirReportes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmReportes());
        }

        // Método para pintar de verde el botón seleccionado y registrarlo como activo
        private void ActivarBoton(Button btn)
        {
            if (btn != null)
            {
                RestaurarColoresBotones();
                botonActivo = btn;
                botonActivo.BackColor = ColorTranslator.FromHtml("#009A44");
                btnAcercaDe.BackColor = colorInactivo;
                btnAcercaDe.BackColor = colorInactivo;
            }
        }

        // Método para devolver todos los botones del menú a su color gris oscuro original
        private void RestaurarColoresBotones()
        {
            Color colorInactivo = ColorTranslator.FromHtml("#2D2D2D");

            // Limpiamos la gaveta de ENTRADA
            foreach (Control boton in pnlSubMenuEntrada.Controls)
            {
                if (boton is Button) boton.BackColor = colorInactivo;
            }

            // Limpiamos la gaveta de CONSULTA
            foreach (Control boton in pnlSubMenuConsulta.Controls)
            {
                if (boton is Button) boton.BackColor = colorInactivo;
            }

            // Limpiamos la gaveta de SISTEMA
            foreach (Control boton in pnlSubMenuSistema.Controls)
            {
                if (boton is Button) boton.BackColor = colorInactivo;
            }
        }

        // 1. Oculta todos los submenús al iniciar el programa
        private void PersonalizarDiseno()
        {
            pnlSubMenuEntrada.Visible = false;
            pnlSubMenuConsulta.Visible = false;
            pnlSubMenuSistema.Visible = false;
        }

        // 2. Oculta los submenús si ya están abiertos (para que solo haya uno abierto a la vez)
        private void OcultarSubMenu()
        {
            if (pnlSubMenuEntrada.Visible == true) pnlSubMenuEntrada.Visible = false;
            if (pnlSubMenuConsulta.Visible == true) pnlSubMenuConsulta.Visible = false;
            if (pnlSubMenuSistema.Visible == true) pnlSubMenuSistema.Visible = false;
        }

        // 3. Abre el submenú que clickeamos (y cierra los demás)
        private void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                OcultarSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false; // Si ya estaba abierto, lo cierra
            }
        }

        // Método para cambiar el tono del botón al pasar el ratón por encima (Efecto Hover)
        private void AplicarEfectoHover(Button btn)
        {
            btn.MouseEnter += (s, e) =>
            {
                if (btn != botonActivo)
                {
                    btn.BackColor = ColorTranslator.FromHtml("#00843D");
                }
            };

            btn.MouseLeave += (s, e) =>
            {
                if (btn != botonActivo)
                {
                    btn.BackColor = ColorTranslator.FromHtml("#2D2D2D");
                }
            };
        }

        // Método principal para incrustar y mostrar las ventanas secundarias dentro del espacio central
        private void AbrirFormularioEnPanel(Form formularioHijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            this.pnlContenedor.Controls.Add(formularioHijo);
            this.pnlContenedor.Tag = formularioHijo;
            formularioHijo.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpiamos el panel contenedor si ya tiene otro formulario alojado
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);

            // Instanciamos el FrmAcercaDe
            FrmAcercaDe frm = new FrmAcercaDe();

            // CONFIGURACIÓN DE ARQUITECTURA: ALOJAR EN PANEL CONTENEDOR
            frm.TopLevel = false;  // Decimos que no es una ventana independiente
            frm.Dock = DockStyle.Fill; // Llenamos todo el espacio del contenedor
            this.pnlContenedor.Controls.Add(frm); // Agregamos el formulario al panel
            this.pnlContenedor.Tag = frm; // Lo marcamos como el control activo

            frm.Show(); // Finalmente lo mostramos
        }

        // 1. Este es para el botón que tienes en la barra lateral (la gris oscuro)
        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            // Usamos tus propios métodos para que todo sea simétrico
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmAcercaDe());
        }

        private void btnMenuEntrada_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnlSubMenuEntrada);
        }

        private void btnMenuConsulta_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnlSubMenuConsulta);
        }

        private void btnMenuSistema_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnlSubMenuSistema);
        }

        private void btnEntradaChoferes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmChoferes("Entrada"));
        }

        private void btnEntradaRutas_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmRutas("Entrada"));
        }

        private void btnEntradaVehiculos_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmVehiculos("Entrada"));
        }

        private void btnEntradaTickets_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmTickets("Entrada"));
        }

        private void btnConsultaChoferes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmChoferes("Consulta"));
        }

        private void btnConsultaRutas_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmRutas("Consulta"));
        }

        private void btnConsultaVehiculos_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmVehiculos("Consulta"));
        }

        private void btnConsultaViajes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmViajes("Consulta"));
        }

        // ⚠️ ATENCIÓN AQUÍ: Reportes y AcercaDe NO necesitan modo, porque solo tienen una función
        private void btnConsultaReportes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmReportes());
        }

        private void btnAcercaDe_Click_1(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmAcercaDe());
        }

        private void btnEntradaViajes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmViajes("Entrada"));
        }
    }

}