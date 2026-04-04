using CapaPresentacion;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Instanciamos el formulario de Login de Elvis
            FrmLogin login = new FrmLogin();

            // 2. Le decimos que se muestre como un cuadro de diálogo (obligatorio responderle)
            // Y verificamos si el resultado fue un éxito (DialogResult.OK)
            if (login.ShowDialog() == DialogResult.OK)
            {
                // 3. Solo si el login fue exitoso, arrancamos el Menú Principal
                Application.Run(new FrmPrincipal());
            }
            else
            {
                // Si el usuario cerró el login con la "X", cerramos la app por completo
                Application.Exit();
            }
        }
    }
}