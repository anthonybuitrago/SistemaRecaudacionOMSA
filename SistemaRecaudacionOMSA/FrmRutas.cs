using System;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmRutas : Form
    {
        // Instancia para la comunicación con la Capa de Negocio
        private N_Ruta objNegocio = new N_Ruta();

        // Variable para almacenar temporalmente el ID de la ruta seleccionada
        private int idRuta = 0;

        // Constructor que inicializa los componentes de la ventana
        public FrmRutas()
        {
            InitializeComponent();
        }

        // Evento que carga los datos y prepara la interfaz al abrir la ventana
        private void FrmRutas_Load(object sender, EventArgs e)
        {
            MostrarRutasTabla();
            LimpiarCampos();
        }

        // Método para solicitar y mostrar la lista actualizada de rutas
        private void MostrarRutasTabla()
        {
            dgvRutas.DataSource = objNegocio.MostrarRutas();
            AplicarEstiloTabla();
        }

        // Evento para registrar una nueva ruta verificando que no existan duplicados
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombreRuta.Text) || string.IsNullOrWhiteSpace(txtTarifa.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Aviso");
                return;
            }

            // Verificación de duplicados recorriendo la tabla actual
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
                // Envío de datos a la Capa de Negocio
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

        // Evento para guardar las modificaciones de una ruta existente
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Validaciones de selección y campos vacíos
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
                // Envío de la actualización a la Capa de Negocio
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

        // Evento para reiniciar manualmente el formulario al estado de inserción
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Método para vaciar los campos de texto y reiniciar el estado visual de los botones
        private void LimpiarCampos()
        {
            txtNombreRuta.Clear();
            txtTarifa.Clear();

            idRuta = 0;
            txtNombreRuta.Focus();

            // Configuración de botones para el modo "Nueva Ruta"
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
        }

        // Evento para seleccionar un registro de la tabla y prepararlo para edición
        private void dgvRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Extracción del ID y volcado de datos hacia los campos de texto
                idRuta = Convert.ToInt32(dgvRutas.CurrentRow.Cells["ID_Ruta"].Value);
                txtNombreRuta.Text = dgvRutas.CurrentRow.Cells["NombreRuta"].Value.ToString();
                txtTarifa.Text = dgvRutas.CurrentRow.Cells["TarifaPasaje"].Value.ToString();

                // Configuración de botones para el modo "Edición"
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
            }
        }

        // Evento para eliminar permanentemente una ruta del sistema tras confirmar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validación de selección previa
            if (idRuta == 0)
            {
                MessageBox.Show("Seleccione una ruta.", "Aviso");
                return;
            }

            // Confirmación de seguridad
            DialogResult respuesta = MessageBox.Show("¿Eliminar esta ruta?", "Confirmar", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Petición de eliminación a la Capa de Negocio
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

        // Restricción para permitir únicamente la entrada de números y un solo separador decimal
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

        // Método para personalizar la apariencia visual y corporativa de la tabla de datos
        private void AplicarEstiloTabla()
        {
            // Configuración de estructura y bordes
            dgvRutas.RowHeadersVisible = false;
            dgvRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRutas.BackgroundColor = Color.White;
            dgvRutas.BorderStyle = BorderStyle.None;
            dgvRutas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRutas.GridColor = Color.Gainsboro;

            // Configuración de colores corporativos para los encabezados
            dgvRutas.EnableHeadersVisualStyles = false;
            dgvRutas.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvRutas.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
            dgvRutas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRutas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvRutas.ColumnHeadersHeight = 40;
            dgvRutas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Configuración visual de las filas y colores de selección
            dgvRutas.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvRutas.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9");
            dgvRutas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvRutas.RowTemplate.Height = 35;

            // Renombramiento y visibilidad de las cabeceras
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