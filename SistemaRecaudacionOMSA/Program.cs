using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    internal static class Program
    {
        // Punto de entrada principal para la aplicación
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia el formulario principal del sistema
            Application.Run(new FrmPrincipal());
        }
    }
}