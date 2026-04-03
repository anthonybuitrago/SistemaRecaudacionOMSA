using CapaNegocios;
using System;
using System.Drawing;
using System.Threading.Tasks; // Obligatorio para Task
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmRutas : Form
    {
        // Instancia para la comunicación con la Capa de Negocio
        private N_Ruta objNegocio = new N_Ruta();

        // Variable para almacenar temporalmente el ID de la ruta seleccionada
        private int idRuta = 0;
        private string modoFormulario;

        // Constructor que inicializa los componentes de la ventana
        public FrmRutas()
        {
            InitializeComponent();
            AplicarEstiloTabla();
            ConfigurarVistaSegunModo();
        }

        private void ConfigurarVistaSegunModo()
        {
            if (modoFormulario == "Consulta")
            {
                panel1.Visible = false;
                dgvRutas.Dock = DockStyle.Fill;
            }
            else
            {
                dgvRutas.Visible = false;
                BloquearCampos();
            }
        }

        // Evento ASÍNCRONO que carga los datos y prepara la interfaz al abrir la ventana
        private async void FrmRutas_Load(object sender, EventArgs e)
        {
            await MostrarRutasTablaAsync();
            BloquearCampos(); // Los campos arrancan desactivados por defecto
        }

        // Método ASÍNCRONO para solicitar y mostrar la lista actualizada de rutas
        private async Task MostrarRutasTablaAsync()
        {
            try
            {
                dgvRutas.DataSource = await objNegocio.MostrarRutasAsync();
                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar rutas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento ASÍNCRONO para registrar una nueva ruta
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombreRuta.Text) || string.IsNullOrWhiteSpace(txtTarifa.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificación de duplicados recorriendo la tabla actual (Mantenemos tu lógica original)
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
                // Envío asíncrono de datos a la Capa de Negocio
                await objNegocio.InsertarRutaAsync(txtNombreRuta.Text, txtTarifa.Text);

                MessageBox.Show("¡Ruta guardada!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await MostrarRutasTablaAsync();
                btnLimpiar.PerformClick(); // Reinicia y bloquea
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento ASÍNCRONO para guardar las modificaciones de una ruta existente
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (idRuta == 0)
            {
                MessageBox.Show("Seleccione una ruta de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreRuta.Text) || string.IsNullOrWhiteSpace(txtTarifa.Text))
            {
                MessageBox.Show("Los campos no pueden estar vacíos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Envío asíncrono de la actualización a la Capa de Negocio
                await objNegocio.EditarRutaAsync(idRuta, txtNombreRuta.Text, txtTarifa.Text);

                MessageBox.Show("Ruta actualizada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await MostrarRutasTablaAsync();
                btnLimpiar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LÓGICA DE INTERFAZ: BLOQUEO Y HABILITACIÓN ---

        private void BloquearCampos()
        {
            txtNombreRuta.Enabled = false;
            txtTarifa.Enabled = false;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void HabilitarCampos()
        {
            txtNombreRuta.Enabled = true;
            txtTarifa.Enabled = true;
        }

        // Evento para reiniciar manualmente el formulario (Botón "Nuevo")
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreRuta.Clear();
            txtTarifa.Clear();
            idRuta = 0;

            HabilitarCampos();
            txtNombreRuta.Focus();

            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            if (modoFormulario.Equals("Consulta", StringComparison.OrdinalIgnoreCase))
            {
                panel1.Visible = false; // Se esconde al terminar
            }
        }

        // Evento para seleccionar un registro y habilitar edición
        private void dgvRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idRuta = Convert.ToInt32(dgvRutas.CurrentRow.Cells["ID_Ruta"].Value);
                txtNombreRuta.Text = dgvRutas.CurrentRow.Cells["NombreRuta"].Value.ToString();
                txtTarifa.Text = dgvRutas.CurrentRow.Cells["TarifaPasaje"].Value.ToString();

                panel1.Visible = true; // Aparece el cajón para editar

                HabilitarCampos();
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        // Evento ASÍNCRONO para eliminar una ruta
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idRuta == 0)
            {
                MessageBox.Show("Seleccione una ruta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar esta ruta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EliminarRutaAsync(idRuta);
                    MessageBox.Show("Ruta eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await MostrarRutasTablaAsync();
                    btnLimpiar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Restricciones de teclado (Se mantiene tu lógica)
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

        // Estilos visuales (Mantenemos tu configuración corporativa)
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
            dgvRutas.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
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