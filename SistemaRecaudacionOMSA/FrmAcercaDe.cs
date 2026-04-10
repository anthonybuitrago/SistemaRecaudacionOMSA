using System;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Pantalla de información general sobre el sistema y sus creadores
    public partial class FrmAcercaDe : Form
    {
        public FrmAcercaDe()
        {
            InitializeComponent();

            // Elimina los bordes de la ventana para permitir su integración limpia en el panel principal
            this.FormBorderStyle = FormBorderStyle.None;
        }

        // Cierra la pantalla informativa
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}