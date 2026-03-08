using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmPrincipal : Form
    {
        // 1. Variable para recordar qué botón está presionado actualmente
        private Button botonActivo = null;

        public FrmPrincipal()
        {
            InitializeComponent();

            // Aplicamos el efecto hover a todos los botones
            AplicarEfectoHover(btnAbrirChoferes);
            AplicarEfectoHover(btnAbrirRutas);
            AplicarEfectoHover(btnAbrirVehiculos);
            AplicarEfectoHover(btnAbrirViajes);
            AplicarEfectoHover(btnAbrirTickets);
            AplicarEfectoHover(btnAbrirReportes);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Simula un clic en Choferes apenas abre el programa.
            btnAbrirChoferes.PerformClick();
        }

        // --- Navegación del Sistema ---

        private void btnAbrirChoferes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender); // Pinta el botón de verde
            AbrirFormularioEnPanel(new FrmChoferes());
        }

        private void btnAbrirRutas_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmRutas());
        }

        private void btnAbrirVehiculos_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmVehiculos());
        }

        private void btnAbrirViajes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmViajes());
        }

        private void btnAbrirTickets_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmTickets());
        }

        private void btnAbrirReportes_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
            AbrirFormularioEnPanel(new FrmReportes());
        }

        // --- Lógica Visual de los Botones ---

        private void ActivarBoton(Button btn)
        {
            if (btn != null)
            {
                // 1. Apagamos todos los botones
                RestaurarColoresBotones();

                // 2. Registramos cuál es el nuevo botón activo
                botonActivo = btn;

                // 3. Lo pintamos del verde principal de la OMSA
                botonActivo.BackColor = ColorTranslator.FromHtml("#009A44");
            }
        }

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

        private void AplicarEfectoHover(Button btn)
        {
            btn.MouseEnter += (s, e) =>
            {
                // Solo hace el hover si el botón NO es el que está activo actualmente
                if (btn != botonActivo)
                {
                    btn.BackColor = ColorTranslator.FromHtml("#00843D"); // Verde más oscuro para hover
                }
            };

            btn.MouseLeave += (s, e) =>
            {
                // Solo regresa a gris si el botón NO es el que está activo
                if (btn != botonActivo)
                {
                    btn.BackColor = ColorTranslator.FromHtml("#2D2D2D"); // Gris original
                }
            };
        }

        // --- Método Único para abrir formularios dentro del panel central ---

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