using CapaNegocios;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Formulario para la gestión (CRUD) de los choferes del sistema
    public partial class FrmChoferes : Form
    {
        private N_Chofer objNegocio = new N_Chofer();

        // Variables de control de estado para el modo edición
        private int idChofer = 0;
        private string cedulaOriginal = "";
        private string nombreOriginal = "";
        private string licenciaOriginal = "";

        public FrmChoferes()
        {
            InitializeComponent();
        }

        private async void FrmChoferes_Load(object sender, EventArgs e)
        {
            dgvChoferes.Visible = false;
            await MostrarChoferesTablaAsync();

            HabilitarCampos(false);
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            AplicarEstiloTabla();
        }

        // Alterna la visibilidad de la tabla de registros
        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            dgvChoferes.Visible = !dgvChoferes.Visible;

            if (dgvChoferes.Visible)
            {
                btnVerTabla.Text = "Ocultar Tabla";
                btnVerTabla.ForeColor = Color.Yellow;
                btnVerTabla.Image = Properties.Resources.view_off;
            }
            else
            {
                btnVerTabla.Text = "Ver Tabla";
                btnVerTabla.ForeColor = Color.White;
                btnVerTabla.Image = Properties.Resources.view;
            }
        }

        // Alterna entre el modo de lectura y el modo de edición de datos
        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            bool habilitar = !txtCedula.Enabled;
            HabilitarCampos(habilitar);

            if (habilitar)
            {
                btnModoEdicion.Text = "Cerrar Edición";
                btnModoEdicion.ForeColor = Color.Tomato;
                btnModoEdicion.Image = Properties.Resources.open_lock;
            }
            else
            {
                btnModoEdicion.Text = "Editar Datos";
                btnModoEdicion.ForeColor = Color.White;
                btnModoEdicion.Image = Properties.Resources.closed_lock;
            }
        }

        // Gestiona el estado visual y funcional de los controles de entrada
        private void HabilitarCampos(bool estado)
        {
            Color colorLabel = estado ? Color.White : Color.Gray;
            Color colorBotonApagado = Color.FromArgb(45, 45, 48);

            lblNombre.ForeColor = colorLabel;
            lblCedula.ForeColor = colorLabel;
            lblTelefono.ForeColor = colorLabel;
            lblLicencia.ForeColor = colorLabel;

            txtNombre.Enabled = estado;
            txtCedula.Enabled = estado;
            txtTelefono.Enabled = estado;
            txtLicencia.Enabled = estado;

            btnGuardar.Enabled = estado;
            btnActualizar.Enabled = estado;
            btnEliminar.Enabled = estado;

            btnGuardar.BackColor = estado ? Color.SeaGreen : colorBotonApagado;
            btnActualizar.BackColor = estado ? Color.Goldenrod : colorBotonApagado;
            btnEliminar.BackColor = estado ? Color.IndianRed : colorBotonApagado;

            btnGuardar.ForeColor = colorLabel;
            btnActualizar.ForeColor = colorLabel;
            btnEliminar.ForeColor = colorLabel;
        }

        // Carga los datos de la fila seleccionada en los campos del formulario
        private void dgvChoferes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvChoferes.Rows[e.RowIndex];

                idChofer = Convert.ToInt32(fila.Cells["ID_Chofer"].Value);
                txtCedula.Text = fila.Cells["Cedula"].Value.ToString();
                txtNombre.Text = fila.Cells["NombreCompleto"].Value.ToString();
                txtLicencia.Text = fila.Cells["NumeroLicencia"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();

                cedulaOriginal = txtCedula.Text;
                nombreOriginal = txtNombre.Text;
                licenciaOriginal = txtLicencia.Text;
            }
        }

        // Consulta la base de datos y refresca la tabla
        private async Task MostrarChoferesTablaAsync()
        {
            try
            {
                dgvChoferes.DataSource = await objNegocio.MostrarChoferesAsync();
                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Procesa el registro de un nuevo chofer
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || !txtCedula.MaskCompleted || !txtTelefono.MaskCompleted || string.IsNullOrWhiteSpace(txtLicencia.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios con el formato correcto.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool yaExiste = await objNegocio.VerificarSiExisteCedula(txtCedula.Text);

                if (yaExiste)
                {
                    MessageBox.Show("Error: Ya existe un chofer registrado con esta cédula.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await objNegocio.InsertarChoferAsync(txtCedula.Text, txtNombre.Text, txtLicencia.Text, txtTelefono.Text);

                MessageBox.Show("Chofer registrado exitosamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await MostrarChoferesTablaAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Procesa la actualización de datos de un chofer seleccionado
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!txtCedula.Enabled)
            {
                MessageBox.Show("Modo de lectura activo. Haga clic en 'Editar Datos' para realizar cambios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (idChofer == 0)
            {
                MessageBox.Show("Debe seleccionar un chofer de la tabla para actualizar sus datos.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCedula.Text == cedulaOriginal && txtNombre.Text == nombreOriginal && txtLicencia.Text == licenciaOriginal && txtTelefono.Text != "") // Se asume verificación simple
            {
                MessageBox.Show("No se han detectado cambios en la información actual.", "Sin Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                await objNegocio.EditarChoferAsync(idChofer, txtCedula.Text, txtNombre.Text, txtLicencia.Text, txtTelefono.Text);

                MessageBox.Show("Datos actualizados correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await MostrarChoferesTablaAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Procesa el borrado lógico de un chofer seleccionado
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idChofer == 0)
            {
                MessageBox.Show("Seleccione en la tabla el chofer que desea eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar definitivamente este chofer?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EliminarChoferAsync(idChofer);
                    MessageBox.Show("El registro ha sido eliminado del sistema.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await MostrarChoferesTablaAsync();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Aplica el diseño visual corporativo a la cuadrícula de datos
        private void AplicarEstiloTabla()
        {
            dgvChoferes.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvChoferes.BorderStyle = BorderStyle.None;
            dgvChoferes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChoferes.GridColor = Color.FromArgb(64, 64, 64);

            dgvChoferes.EnableHeadersVisualStyles = false;
            dgvChoferes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvChoferes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvChoferes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChoferes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvChoferes.ColumnHeadersHeight = 40;

            dgvChoferes.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvChoferes.DefaultCellStyle.ForeColor = Color.White;
            dgvChoferes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvChoferes.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvChoferes.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgvChoferes.RowTemplate.Height = 35;
            dgvChoferes.RowHeadersVisible = false;

            dgvChoferes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChoferes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChoferes.ReadOnly = true;
            dgvChoferes.MultiSelect = false;

            // Organización de columnas
            if (dgvChoferes.Columns["ID_Chofer"] != null) dgvChoferes.Columns["ID_Chofer"].Visible = false;
            if (dgvChoferes.Columns["Estado"] != null) dgvChoferes.Columns["Estado"].Visible = false;
            if (dgvChoferes.Columns["NumeroLicencia"] != null) dgvChoferes.Columns["NumeroLicencia"].Visible = false;

            if (dgvChoferes.Columns["NombreCompleto"] != null)
            {
                dgvChoferes.Columns["NombreCompleto"].HeaderText = "Nombre";
                dgvChoferes.Columns["NombreCompleto"].DisplayIndex = 0;
            }

            if (dgvChoferes.Columns["Telefono"] != null)
            {
                dgvChoferes.Columns["Telefono"].HeaderText = "Teléfono";
                dgvChoferes.Columns["Telefono"].DisplayIndex = 1;
            }

            if (dgvChoferes.Columns["Cedula"] != null)
            {
                dgvChoferes.Columns["Cedula"].HeaderText = "Cédula";
                dgvChoferes.Columns["Cedula"].DisplayIndex = 2;
            }
        }

        // Posiciona el cursor al inicio del área de edición en las máscaras de texto
        private void AcomodarCursor_Click(object sender, EventArgs e)
        {
            MaskedTextBox mascara = sender as MaskedTextBox;

            if (mascara != null)
            {
                int primeraPosicionVacia = mascara.MaskedTextProvider.FindUnassignedEditPositionFrom(0, true);

                if (primeraPosicionVacia != -1 && mascara.SelectionStart > primeraPosicionVacia)
                {
                    mascara.SelectionStart = primeraPosicionVacia;
                }
            }
        }

        private void LimpiarCampos()
        {
            idChofer = 0;
            txtCedula.Clear();
            txtNombre.Clear();
            txtLicencia.Clear();
            txtTelefono.Clear();

            cedulaOriginal = "";
            nombreOriginal = "";
            licenciaOriginal = "";
        }
    }
}