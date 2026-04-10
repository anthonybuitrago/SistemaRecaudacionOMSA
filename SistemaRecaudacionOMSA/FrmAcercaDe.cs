using System;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // TODO: [REQUISITO] - Opción Sistema: Información de los desarrolladores del proyecto.

    // Interfaz de información general del sistema y créditos corporativos (Acerca De)
    public partial class FrmAcercaDe : Form
    {
        public FrmAcercaDe()
        {
            InitializeComponent();

            // Configuración visual para acoplamiento nativo en el panel contenedor principal
            this.FormBorderStyle = FormBorderStyle.None;
        }

        // ==========================================================
        // EVENTOS DE CONTROL DE INTERFAZ
        // ==========================================================

        // Finaliza el ciclo de vida del formulario y cierra la vista
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}