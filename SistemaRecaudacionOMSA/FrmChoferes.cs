using CapaNegocios;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmChoferes : Form
    {
        // Instancia para la comunicación con la Capa de Negocio
        private N_Chofer objNegocio = new N_Chofer();

        // Variable para almacenar temporalmente el ID del chofer seleccionado
        private int idChofer = 0;
        private string modoFormulario;

        // Constructor que inicializa los componentes y aplica el diseño visual
        public FrmChoferes(string modo)
        {
            InitializeComponent();
            AplicarEstiloTabla();
            this.modoFormulario = modo;
            ConfigurarVistaSegunModo();
        }

        private void ConfigurarVistaSegunModo()
        {
            if (modoFormulario == "Consulta")
            {
                // Oculta las cajas de texto y los botones de guardar
                panel1.Visible = false;

                // Hace que la tabla ocupe toda la pantalla
                dgvChoferes.Dock = DockStyle.Fill;
            }
            else
            {
                // Oculta la tabla para dejar solo la pantalla de registro
                dgvChoferes.Visible = false;

                // Bloquea los campos al iniciar (Requisito de la rúbrica)
                BloquearCampos();
            }
        }

        // Evento asíncrono que carga los datos en la tabla al abrir la ventana
        private async void FrmChoferes_Load(object sender, EventArgs e)
        {
            await MostrarChoferesTablaAsync();
        }

        // Método asíncrono para solicitar y mostrar la lista actualizada de choferes
        private async Task MostrarChoferesTablaAsync()
        {
            try
            {
                dgvChoferes.DataSource = await objNegocio.MostrarChoferesAsync();

                // Renombramiento de las cabeceras para una mejor presentación al usuario
                dgvChoferes.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
                dgvChoferes.Columns["NumeroLicencia"].HeaderText = "No. Licencia";
                dgvChoferes.Columns["ID_Chofer"].HeaderText = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento asíncrono para registrar un nuevo chofer en el sistema
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtLicencia.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Envío de datos a la Capa de Negocio asíncronamente
                await objNegocio.InsertarChoferAsync(txtCedula.Text, txtNombre.Text, txtLicencia.Text);

                MessageBox.Show("Chofer guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresco visual asíncrono de la tabla y limpieza de campos
                await MostrarChoferesTablaAsync();
                btnLimpiar.PerformClick(); // Llamamos al botón limpiar para reiniciar todo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LÓGICA VISUAL: CONTROL DE ESTADOS DE LA INTERFAZ ---

        private void BloquearCampos()
        {
            txtCedula.Enabled = false;
            txtNombre.Enabled = false;
            txtLicencia.Enabled = false;
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void HabilitarCampos()
        {
            txtCedula.Enabled = true;
            txtNombre.Enabled = true;
            txtLicencia.Enabled = true;
        }

        // Evento para reiniciar manualmente el formulario al estado de inserción (Botón "Nuevo" o "Limpiar")
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtLicencia.Clear();

            idChofer = 0;

            HabilitarCampos(); // Habilitamos campos para escribir
            txtCedula.Focus();

            // Configuración de botones para el modo "Nuevo Registro"
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false; // Solo se puede eliminar si seleccionas de la tabla

            // 🔥 VOLVER A OCULTAR SI ESTAMOS EN MODO CONSULTA
            if (modoFormulario == "Consulta")
            {
                panel1.Visible = false;
            }
        }

        // Evento para seleccionar un registro de la tabla y prepararlo para edición
        private void dgvChoferes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Extracción del ID y volcado de datos hacia los campos de texto
                idChofer = Convert.ToInt32(dgvChoferes.CurrentRow.Cells["ID_Chofer"].Value);
                txtCedula.Text = dgvChoferes.CurrentRow.Cells["Cedula"].Value.ToString();
                txtNombre.Text = dgvChoferes.CurrentRow.Cells["NombreCompleto"].Value.ToString();
                txtLicencia.Text = dgvChoferes.CurrentRow.Cells["NumeroLicencia"].Value.ToString();

                panel1.Visible = true;

                HabilitarCampos(); // Permitimos que el usuario escriba para editar

                // Configuración de botones para el modo "Edición"
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        // Evento asíncrono para guardar las modificaciones de un chofer existente
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validaciones de selección y campos vacíos
            if (idChofer == 0)
            {
                MessageBox.Show("Por favor, seleccione un chofer de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCedula.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtLicencia.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Envío de la actualización asíncrona a la Capa de Negocio
                await objNegocio.EditarChoferAsync(idChofer, txtCedula.Text, txtNombre.Text, txtLicencia.Text);

                MessageBox.Show("Chofer actualizado correctamente en el sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await MostrarChoferesTablaAsync();
                btnLimpiar.PerformClick();
                BloquearCampos(); // Volvemos a bloquear después de editar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento asíncrono para eliminar permanentemente un chofer del sistema
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validación de selección previa
            if (idChofer == 0)
            {
                MessageBox.Show("Por favor, seleccione el chofer que desea eliminar haciendo clic en la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación de seguridad
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar a este chofer del sistema?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Petición de eliminación asíncrona a la Capa de Negocio
                    await objNegocio.EliminarChoferAsync(idChofer);

                    MessageBox.Show("Chofer eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await MostrarChoferesTablaAsync();
                    btnLimpiar.PerformClick();
                    BloquearCampos(); // Volvemos a bloquear después de eliminar
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para personalizar la apariencia visual de la tabla de datos
        private void AplicarEstiloTabla()
        {
            // Configuración de estructura y bordes
            dgvChoferes.RowHeadersVisible = false;
            dgvChoferes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChoferes.BackgroundColor = Color.White;
            dgvChoferes.BorderStyle = BorderStyle.None;
            dgvChoferes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChoferes.GridColor = Color.Gainsboro;

            // Configuración de colores corporativos para los encabezados
            dgvChoferes.EnableHeadersVisualStyles = false;
            dgvChoferes.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvChoferes.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
            dgvChoferes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChoferes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvChoferes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvChoferes.ColumnHeadersHeight = 40;

            // Configuración visual de las filas y colores de selección
            dgvChoferes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvChoferes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9");
            dgvChoferes.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvChoferes.RowTemplate.Height = 35;
        }

        // Restricciones de teclado (se mantienen igual)
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLicencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}