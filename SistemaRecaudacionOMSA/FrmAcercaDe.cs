using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmAcercaDe : Form
    {
        public FrmAcercaDe()
        {
            // Este método carga TODO lo que hiciste visualmente (colores, labels, posiciones)
            InitializeComponent();

            // Única configuración necesaria por código:
            // Quitamos los bordes para que se integre perfectamente en el panel blanco
            this.FormBorderStyle = FormBorderStyle.None;
        }

        // Si el botón de cerrar no es necesario, puedes borrar este método. 
        // Pero si lo dejas, no afecta en nada.
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Estos eventos vacíos se pueden quedar así, no estorban.
        private void FrmAcercaDe_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}