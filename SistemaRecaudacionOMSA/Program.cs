using System;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// Gestiona el ciclo de vida inicial y la seguridad de acceso.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // TODO: [REQUISITO] - Control de flujo de seguridad (Login previo al inicio)
            // Ejecutamos el Login de manera modal antes de iniciar el loop principal de la aplicación.
            using (FrmLogin login = new FrmLogin())
            {
                // Solo si el usuario se autentica correctamente (DialogResult.OK)
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Iniciamos el formulario principal de la aplicación
                    Application.Run(new FrmPrincipal());
                }
                else
                {
                    // Si el login se cancela o se cierra, terminamos la ejecución
                    Application.Exit();
                }
            }
        }
    }
}