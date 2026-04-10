using System;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    internal static class Program
    {
        // Punto de entrada principal de la aplicación
        [STAThread]
        static void Main()
        {
            // Configuración visual inicial de Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Control de seguridad: Inicia el Login antes del sistema principal
            using (FrmLogin login = new FrmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Autenticación exitosa, carga el entorno de trabajo
                    Application.Run(new FrmPrincipal());
                }
                else
                {
                    // Cierre del programa si el usuario cancela el acceso
                    Application.Exit();
                }
            }
        }
    }
}