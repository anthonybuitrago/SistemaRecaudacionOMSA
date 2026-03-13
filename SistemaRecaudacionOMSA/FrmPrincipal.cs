using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmPrincipal : Form
    {
        // Variable para recordar qué botón del menú está seleccionado actualmente
        private Button botonActivo = null;

        // Constructor que inicializa la ventana principal y prepara las animaciones del menú
        public FrmPrincipal()
        {
            InitializeComponent();

            AplicarEfectoHover(btnAbrirChoferes);
            AplicarEfectoHover(btnAbrirRutas);
            AplicarEfectoHover(btnAbrirVehiculos);
            AplicarEfectoHover(btnAbrirViajes);
            AplicarEfectoHover(btnAbrirTickets);
            AplicarEfectoHover(btnAbrirReportes);
        }

        // Evento que abre automáticamente la sección de Choferes al iniciar el sistema
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            btnAbrirChoferes.PerformClick();
        }

        // Evento para abrir la sección de Choferes y resaltar su botón
        private void btnAbrirChoferes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmChoferes());
        }

        // Evento para abrir la sección de Rutas y resaltar su botón
        private void btnAbrirRutas_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmRutas());
        }

        // Evento para abrir la sección de Vehículos y resaltar su botón
        private void btnAbrirVehiculos_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmVehiculos());
        }

        // Evento para abrir la sección de Viajes y resaltar su botón
        private void btnAbrirViajes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmViajes());
        }

        // Evento para abrir la sección de Tickets y resaltar su botón
        private void btnAbrirTickets_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmTickets());
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
            }
        }

        // Método para devolver todos los botones del menú a su color gris oscuro original
        private void RestaurarColoresBotones()
        {
            Color colorInactivo = ColorTranslator.FromHtml("#2D2D2D");

            btnAbrirChoferes.BackColor = colorInactivo;
            btnAbrirRutas.BackColor = colorInactivo;
            btnAbrirVehiculos.BackColor = colorInactivo;
            btnAbrirTickets.BackColor = colorInactivo;
            btnAbrirViajes.BackColor = colorInactivo;
            btnAbrirReportes.BackColor = colorInactivo;
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
    }
}