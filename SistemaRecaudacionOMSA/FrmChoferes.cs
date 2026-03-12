using CapaNegocios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmChoferes : Form
    {
        // Instancia de la Capa de Negocio
        private N_Chofer objNegocio = new N_Chofer();
        private int idChofer = 0;

        public FrmChoferes()
        {
            InitializeComponent();
            AplicarEstiloTabla(); // ¡La magia ocurre aquí!
        }

        // Evento que se ejecuta al abrir el formulario
        private void FrmChoferes_Load(object sender, EventArgs e)
        {
            MostrarChoferesTabla();
        }

        // Método para refrescar el DataGridView
        private void MostrarChoferesTabla()
        {
            dgvChoferes.DataSource = objNegocio.MostrarChoferes();

            // Mueve las líneas AQUÍ, justo después de que la tabla ya tiene los datos
            dgvChoferes.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
            dgvChoferes.Columns["NumeroLicencia"].HeaderText = "No. Licencia";
            dgvChoferes.Columns["ID_Chofer"].HeaderText = "ID";
        }

        // Lógica del botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtLicencia.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Esto detiene la ejecución del botón y no guarda nada
            }

            try
            {
                // 2. Llamada a la Capa de Negocio
                objNegocio.InsertarChofer(txtCedula.Text, txtNombre.Text, txtLicencia.Text);

                // 3. Respuesta al usuario y actualización
                MessageBox.Show("Chofer guardado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarChoferesTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar la interfaz
        private void LimpiarCampos()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtLicencia.Clear();
            txtCedula.Focus(); // Pone el cursor listo para el siguiente registro
        }

        private void AplicarEstiloTabla()
        {
            // 1. Ocultar la primera columna vacía y ajustar tamaño
            dgvChoferes.RowHeadersVisible = false;
            dgvChoferes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 2. Colores de fondo y bordes
            dgvChoferes.BackgroundColor = Color.White;
            dgvChoferes.BorderStyle = BorderStyle.None;
            dgvChoferes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChoferes.GridColor = Color.Gainsboro; // Un gris muy suave para las líneas

            // 3. Estilo de los encabezados (Verde OMSA)
            dgvChoferes.EnableHeadersVisualStyles = false; // ¡Súper importante para que agarre el color!
            dgvChoferes.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvChoferes.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
            dgvChoferes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChoferes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvChoferes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvChoferes.ColumnHeadersHeight = 40; // Encabezados más altos

            // 4. Estilo de las filas (Texto normal)
            dgvChoferes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvChoferes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9"); // Un verde clarito al seleccionar
            dgvChoferes.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvChoferes.RowTemplate.Height = 35; // Filas más anchas y cómodas
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y la tecla de borrar
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla pulsada
            }
        }

        private void txtLicencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y la tecla de borrar
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla pulsada
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, tecla de borrar y la barra espaciadora
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignora si escriben un número o símbolo
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // 1. Limpiamos las cajas de texto (Asegúrate de que tus TextBox se llamen así)
            txtCedula.Clear();
            txtNombre.Clear();
            txtLicencia.Clear();

            // 2. Reseteamos el ID
            idChofer = 0;

            // 3. Devolvemos el cursor a la primera caja
            txtCedula.Focus();

            // 4. CONTROL VISUAL: Modo "Nuevo Chofer"
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }

        private void dgvChoferes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que se hizo clic en una fila válida
            if (e.RowIndex >= 0)
            {
                // 1. Guardamos el ID (Asegúrate que el nombre de la columna coincida con tu BD, ej: "ID_Chofer" o "ID")
                idChofer = Convert.ToInt32(dgvChoferes.CurrentRow.Cells["ID_Chofer"].Value);

                // 2. Subimos los datos a las cajas blancas (Revisa que los nombres de las columnas coincidan con los tuyos)
                txtCedula.Text = dgvChoferes.CurrentRow.Cells["Cedula"].Value.ToString();
                txtNombre.Text = dgvChoferes.CurrentRow.Cells["NombreCompleto"].Value.ToString();
                txtLicencia.Text = dgvChoferes.CurrentRow.Cells["NumeroLicencia"].Value.ToString();

                // 3. CONTROL VISUAL: Modo "Edición"
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // 1. Validar que seleccionaron a alguien
            if (idChofer == 0)
            {
                MessageBox.Show("Por favor, seleccione un chofer de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que no dejaron la cédula, nombre o licencia en blanco
            if (string.IsNullOrWhiteSpace(txtCedula.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtLicencia.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3. Enviamos los datos a la Capa de Negocio (¡Asegúrate de tener este método creado en N_Chofer!)
                objNegocio.EditarChofer(idChofer, txtCedula.Text, txtNombre.Text, txtLicencia.Text);

                MessageBox.Show("Chofer actualizado correctamente en el sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Refrescar la tabla y usar tu nuevo botón de limpiar
                MostrarChoferesTabla(); // Ajusta el nombre si tu método se llama distinto
                btnLimpiar.PerformClick(); // Esto simula un clic en el botón gris para resetear todo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // 1. Validamos que se haya seleccionado un chofer
            if (idChofer == 0)
            {
                MessageBox.Show("Por favor, seleccione el chofer que desea eliminar haciendo clic en la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Pedimos confirmación por seguridad 
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar a este chofer del sistema?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // 3. Llamamos a la Capa de Negocio
                    objNegocio.EliminarChofer(idChofer);

                    MessageBox.Show("Chofer eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Refrescamos la tabla y limpiamos las cajas
                    MostrarChoferesTabla(); // Asegúrate de que así se llame tu método
                    btnLimpiar.PerformClick(); // Simula un clic en tu botón de limpiar para resetear todo
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}