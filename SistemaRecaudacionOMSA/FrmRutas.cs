using System;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmRutas : Form
    {
        private N_Ruta objNegocio = new N_Ruta();
        private int idRuta = 0;

        public FrmRutas()
        {
            InitializeComponent();
        }

        private void FrmRutas_Load(object sender, EventArgs e)
        {
            MostrarRutasTabla();
            LimpiarCampos(); // Establece el estado inicial de los botones
        }

        private void MostrarRutasTabla()
        {
            dgvRutas.DataSource = objNegocio.MostrarRutas();
            AplicarEstiloTabla();
        }

        // --- Lógica de Botones y Validación ---

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombreRuta.Text) || string.IsNullOrWhiteSpace(txtTarifa.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Aviso");
                return;
            }

            // 2. VALIDACIÓN DE DUPLICADOS: Revisar si el nombre ya existe en la tabla actual
            foreach (DataGridViewRow fila in dgvRutas.Rows)
            {
                if (fila.Cells["NombreRuta"].Value != null &&
                    fila.Cells["NombreRuta"].Value.ToString().ToLower() == txtNombreRuta.Text.Trim().ToLower())
                {
                    MessageBox.Show("Esta ruta ya existe en el sistema. No se puede duplicar.", "Ruta Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                objNegocio.InsertarRuta(txtNombreRuta.Text, txtTarifa.Text);
                MessageBox.Show("¡Ruta guardada!", "Éxito");
                MostrarRutasTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idRuta == 0)
            {
                MessageBox.Show("Seleccione una ruta de la tabla.", "Aviso");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreRuta.Text) || string.IsNullOrWhiteSpace(txtTarifa.Text))
            {
                MessageBox.Show("Los campos no pueden estar vacíos.", "Aviso");
                return;
            }

            try
            {
                objNegocio.EditarRuta(idRuta, txtNombreRuta.Text, txtTarifa.Text);
                MessageBox.Show("Ruta actualizada.", "Éxito");
                MostrarRutasTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreRuta.Clear();
            txtTarifa.Clear();
            idRuta = 0;
            txtNombreRuta.Focus();

            // CONTROL VISUAL: Modo "Nueva Ruta"
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void dgvRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idRuta = Convert.ToInt32(dgvRutas.CurrentRow.Cells["ID_Ruta"].Value);
                txtNombreRuta.Text = dgvRutas.CurrentRow.Cells["NombreRuta"].Value.ToString();
                txtTarifa.Text = dgvRutas.CurrentRow.Cells["TarifaPasaje"].Value.ToString();

                // CONTROL VISUAL: Modo "Edición"
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idRuta == 0)
            {
                MessageBox.Show("Seleccione una ruta.", "Aviso");
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Eliminar esta ruta?", "Confirmar", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    objNegocio.EliminarRuta(idRuta);
                    MessageBox.Show("Ruta eliminada.");
                    MostrarRutasTabla();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // --- Resto de Métodos (Estilo y Teclado) ---

        private void txtTarifa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void AplicarEstiloTabla()
        {
            dgvRutas.RowHeadersVisible = false;
            dgvRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRutas.BackgroundColor = Color.White;
            dgvRutas.BorderStyle = BorderStyle.None;
            dgvRutas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRutas.GridColor = Color.Gainsboro;

            dgvRutas.EnableHeadersVisualStyles = false;
            dgvRutas.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvRutas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRutas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvRutas.ColumnHeadersHeight = 40;
            dgvRutas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvRutas.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvRutas.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9");
            dgvRutas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvRutas.RowTemplate.Height = 35;

            if (dgvRutas.Columns.Count > 0)
            {
                if (dgvRutas.Columns.Contains("ID_Ruta")) dgvRutas.Columns["ID_Ruta"].HeaderText = "ID";
                if (dgvRutas.Columns.Contains("NombreRuta")) dgvRutas.Columns["NombreRuta"].HeaderText = "Nombre de la Ruta";
                if (dgvRutas.Columns.Contains("TarifaPasaje")) dgvRutas.Columns["TarifaPasaje"].HeaderText = "Tarifa (RD$)";
                if (dgvRutas.Columns.Contains("Descripcion")) dgvRutas.Columns["Descripcion"].Visible = false;
            }
        }
    }
}