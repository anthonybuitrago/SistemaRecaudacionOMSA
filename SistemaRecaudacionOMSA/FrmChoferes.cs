using CapaNegocios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmChoferes : Form
    {
        // Instancia para la comunicación con la Capa de Negocio
        private N_Chofer objNegocio = new N_Chofer();

        // Variable para almacenar temporalmente el ID del chofer seleccionado
        private int idChofer = 0;

        // Constructor que inicializa los componentes y aplica el diseño visual
        public FrmChoferes()
        {
            InitializeComponent();
            AplicarEstiloTabla();
        }

        // Evento que carga los datos en la tabla al abrir la ventana
        private void FrmChoferes_Load(object sender, EventArgs e)
        {
            MostrarChoferesTabla();
        }

        // Método para solicitar y mostrar la lista actualizada de choferes
        private void MostrarChoferesTabla()
        {
            dgvChoferes.DataSource = objNegocio.MostrarChoferes();

            // Renombramiento de las cabeceras para una mejor presentación al usuario
            dgvChoferes.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
            dgvChoferes.Columns["NumeroLicencia"].HeaderText = "No. Licencia";
            dgvChoferes.Columns["ID_Chofer"].HeaderText = "ID";
        }

        // Evento para registrar un nuevo chofer en el sistema
        private void btnGuardar_Click(object sender, EventArgs e)
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
                // Envío de datos a la Capa de Negocio
                objNegocio.InsertarChofer(txtCedula.Text, txtNombre.Text, txtLicencia.Text);

                MessageBox.Show("Chofer guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresco visual de la tabla y limpieza de campos
                MostrarChoferesTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para vaciar los campos de texto y reiniciar el estado visual
        private void LimpiarCampos()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtLicencia.Clear();
            txtCedula.Focus();
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

        // Restricción para permitir únicamente la entrada de números
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Restricción para permitir únicamente la entrada de números
        private void txtLicencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Restricción para permitir únicamente letras y espacios
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Evento para reiniciar manualmente el formulario al estado de inserción
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtLicencia.Clear();

            idChofer = 0;
            txtCedula.Focus();

            // Configuración de botones para el modo "Nuevo Registro"
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
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

                // Configuración de botones para el modo "Edición"
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
            }
        }

        // Evento para guardar las modificaciones de un chofer existente
        private void btnActualizar_Click(object sender, EventArgs e)
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
                // Envío de la actualización a la Capa de Negocio
                objNegocio.EditarChofer(idChofer, txtCedula.Text, txtNombre.Text, txtLicencia.Text);

                MessageBox.Show("Chofer actualizado correctamente en el sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarChoferesTabla();
                btnLimpiar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para eliminar permanentemente un chofer del sistema
        private void btnEliminar_Click(object sender, EventArgs e)
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
                    // Petición de eliminación a la Capa de Negocio
                    objNegocio.EliminarChofer(idChofer);

                    MessageBox.Show("Chofer eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MostrarChoferesTabla();
                    btnLimpiar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}