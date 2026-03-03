using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void btnAbrirChoferes_Click(object sender, EventArgs e)
        {
            FrmChoferes pantallaChoferes = new FrmChoferes();
            pantallaChoferes.ShowDialog();
        }
    }
}
