using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    internal static class Program
    {
        // Punto de entrada principal para la ejecución de la aplicación
        [STAThread]
        static void Main()
        {
            // Configura la apariencia visual moderna para los controles del sistema
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la ejecución del sistema cargando el formulario principal
            Application.Run(new FrmPrincipal());
        }
    }
}