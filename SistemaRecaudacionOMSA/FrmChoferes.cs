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

        private int idChofer = 0;
        private string cedulaOriginal = "";
        private string nombreOriginal = "";
        private string licenciaOriginal = "";

        public FrmChoferes()
        {
            InitializeComponent();

            // Estética inicial de la tabla (Igual que en Viajes)
            dgvChoferes.BackgroundColor = Color.FromArgb(28, 28, 28);
            dgvChoferes.BorderStyle = BorderStyle.None;
            dgvChoferes.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvChoferes.DefaultCellStyle.ForeColor = Color.White;

            AplicarEstiloTabla();
        }

        private async void FrmChoferes_Load(object sender, EventArgs e)
        {
            // Ocultamos la tabla al inicio
            dgvChoferes.Visible = false;

            await MostrarChoferesTablaAsync();

            // Bloqueamos los campos y apagamos los botones al inicio
            HabilitarCampos(false);
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false; // Este es tu botón Eliminar
            AplicarEstiloTabla();
        }

        // --- LÓGICA DE INTERFAZ (EL CANDADO Y EL OJO) ---

        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            dgvChoferes.Visible = !dgvChoferes.Visible;

            if (dgvChoferes.Visible)
            {
                btnVerTabla.Text = "Ocultar Tabla";
                btnVerTabla.ForeColor = Color.Yellow; // Un amarillo brillante y vivo
                btnVerTabla.Image = Properties.Resources.view_off;
            }
            else
            {
                btnVerTabla.Text = "Ver Tabla";
                btnVerTabla.ForeColor = Color.White;
                btnVerTabla.Image = Properties.Resources.view;
            }
        }

        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            bool estaAbriendo = !txtCedula.Enabled;
            HabilitarCampos(estaAbriendo);

            if (estaAbriendo)
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

                // ¡LA MAGIA AQUÍ! Al cerrar edición, se limpia lo que estaba escrito
            }
        }

        private bool HayCambiosReales()
        {
            // Compara lo que está escrito ahora con la foto original
            return (txtCedula.Text != cedulaOriginal) ||
                   (txtNombre.Text != nombreOriginal) ||
                   (txtLicencia.Text != licenciaOriginal);
        }

        private void HabilitarCampos(bool estado)
        {
            // 1. Color para los Labels (Blanco si activo, Gris si apagado)
            Color colorLabel = estado ? Color.White : Color.Gray;

            // Ajusta los nombres de tus labels aquí (asumo que se llaman así):
            lblNombre.ForeColor = colorLabel;
            lblCedula.ForeColor = colorLabel;
            lblTelefono.ForeColor = colorLabel;
            lblLicencia.ForeColor = colorLabel;

            // 2. Control de los campos (Incluyendo el Teléfono)
            txtNombre.Enabled = estado;
            txtCedula.Enabled = estado;
            txtTelefono.Enabled = estado; // Aquí corregimos lo del teléfono
            txtLicencia.Enabled = estado;

            // 3. Control de los botones CRUD
            btnGuardar.Enabled = estado;
            btnActualizar.Enabled = estado;
            btnEliminar.Enabled = estado;
        }

        // --- EVENTOS DE LA TABLA Y EL DETECTOR ---

        private void dgvChoferes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Evita errores al tocar el encabezado
            {
                DataGridViewRow fila = dgvChoferes.Rows[e.RowIndex];

                // Revisa estos nombres en tu BD. Si se llaman distinto, cámbialos aquí:
                idChofer = Convert.ToInt32(fila.Cells["ID_Chofer"].Value);
                txtCedula.Text = fila.Cells["Cedula"].Value.ToString();
                txtNombre.Text = fila.Cells["NombreCompleto"].Value.ToString();
                txtLicencia.Text = fila.Cells["NumeroLicencia"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();

                // Guardamos la memoria para saber si luego el usuario cambia algo
                cedulaOriginal = txtCedula.Text;
                nombreOriginal = txtNombre.Text;
                licenciaOriginal = txtLicencia.Text;
            }
        }

        // --- MÉTODOS CRUD ASÍNCRONOS ---

        private async Task MostrarChoferesTablaAsync()
        {
            try
            {
                dgvChoferes.DataSource = await objNegocio.MostrarChoferesAsync();

                // Orden de las columnas
                if (dgvChoferes.Columns["NombreCompleto"] != null) dgvChoferes.Columns["NombreCompleto"].DisplayIndex = 0;
                if (dgvChoferes.Columns["Telefono"] != null) dgvChoferes.Columns["Telefono"].DisplayIndex = 1;
                if (dgvChoferes.Columns["Cedula"] != null) dgvChoferes.Columns["Cedula"].DisplayIndex = 2;
                if (dgvChoferes.Columns["Estado"] != null) dgvChoferes.Columns["Estado"].Visible = false;

                // Renombrar
                if (dgvChoferes.Columns["NombreCompleto"] != null) dgvChoferes.Columns["NombreCompleto"].HeaderText = "Nombre";

                // Ocultar
                if (dgvChoferes.Columns["ID_Chofer"] != null) dgvChoferes.Columns["ID_Chofer"].Visible = false;
                if (dgvChoferes.Columns["NumeroLicencia"] != null) dgvChoferes.Columns["NumeroLicencia"].Visible = false;

                AplicarEstiloTabla();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // ... validaciones de campos vacíos que ya tienes ...

            try
            {
                // EL FILTRO ANTIDUPLICADOS:
                bool yaExiste = await objNegocio.VerificarSiExisteCedula(txtCedula.Text);

                if (yaExiste)
                {
                    MessageBox.Show("¡Error! Ya existe un chofer registrado con esta cédula.",
                                    "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Detiene el proceso, no guarda nada
                }

                // Si no existe, procedemos a guardar normal
                await objNegocio.InsertarChoferAsync(txtCedula.Text, txtNombre.Text, txtLicencia.Text, txtTelefono.Text);

                MessageBox.Show("¡Chofer guardado exitosamente!");
                await MostrarChoferesTablaAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!txtCedula.Enabled)
            {
                MessageBox.Show("Modo de lectura activo. Haga clic en 'Editar Datos' para realizar cambios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (idChofer == 0)
            {
                MessageBox.Show("Debe seleccionar un chofer de la tabla para poder actualizar sus datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtCedula.Text == cedulaOriginal && txtNombre.Text == nombreOriginal && txtLicencia.Text == licenciaOriginal)
            {
                MessageBox.Show("No se ha realizado ningún cambio en los datos actuales.", "Sin Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // --- AQUÍ VA LA LÓGICA CON EL AWAIT ---
            try
            {
                // El 'await' manda el ID y los 4 datos modificados
                await objNegocio.EditarChoferAsync(idChofer, txtCedula.Text, txtNombre.Text, txtLicencia.Text, txtTelefono.Text);

                MessageBox.Show("¡Datos actualizados correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargamos la tabla para ver los cambios
                await MostrarChoferesTablaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e) // Recomiendo cambiarle el nombre en diseño a btnEliminar
        {
            // 1. Si intenta eliminar sin haber seleccionado a nadie
            if (idChofer == 0)
            {
                MessageBox.Show("Seleccione en la tabla el chofer que desea eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Desea eliminar definitivamente este chofer?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EliminarChoferAsync(idChofer);
                    MessageBox.Show("¡Eliminado del sistema!");
                    await MostrarChoferesTablaAsync();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        // --- ESTILO Y RESTRICCIONES ---

        private void AplicarEstiloTabla()
        {
            // 1. Colores de fondo y bordes generales
            dgvChoferes.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvChoferes.BorderStyle = BorderStyle.None;

            // Cambiamos el estilo de celda a solo horizontal (quita las líneas verticales blancas)
            dgvChoferes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChoferes.GridColor = Color.FromArgb(64, 64, 64); // Un gris oscuro para las líneas

            // 2. Estilo de la Cabecera (Headers)
            dgvChoferes.EnableHeadersVisualStyles = false; // Permite personalizar el color
            dgvChoferes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvChoferes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvChoferes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChoferes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvChoferes.ColumnHeadersHeight = 40;

            // 3. Estilo de las Celdas y Filas
            dgvChoferes.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvChoferes.DefaultCellStyle.ForeColor = Color.White;
            dgvChoferes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // El azul de Windows
            dgvChoferes.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvChoferes.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgvChoferes.RowTemplate.Height = 35;
            dgvChoferes.RowHeadersVisible = false; // Quita la flechita de la izquierda

            // 4. Comportamiento y Ajuste
            dgvChoferes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChoferes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChoferes.ReadOnly = true;
            dgvChoferes.MultiSelect = false;

            // 5. Gestión de Columnas (Ocultar y Renombrar)
            if (dgvChoferes.Columns["ID_Chofer"] != null) dgvChoferes.Columns["ID_Chofer"].Visible = false;
            if (dgvChoferes.Columns["Estado"] != null) dgvChoferes.Columns["Estado"].Visible = false;
            if (dgvChoferes.Columns["NumeroLicencia"] != null) dgvChoferes.Columns["NumeroLicencia"].Visible = false;

            if (dgvChoferes.Columns["NombreCompleto"] != null)
                dgvChoferes.Columns["NombreCompleto"].HeaderText = "Nombre";

            if (dgvChoferes.Columns["Telefono"] != null)
                dgvChoferes.Columns["Telefono"].HeaderText = "Teléfono";

            if (dgvChoferes.Columns["Cedula"] != null)
                dgvChoferes.Columns["Cedula"].HeaderText = "Cédula";
        }

        private void AcomodarCursor_Click(object sender, EventArgs e)
        {
            MaskedTextBox mascara = sender as MaskedTextBox;

            if (mascara != null)
            {
                // Esto busca automáticamente cuál es el primer espacio que el usuario no ha llenado
                int primeraPosicionVacia = mascara.MaskedTextProvider.FindUnassignedEditPositionFrom(0, true);

                // Si encontró un espacio vacío, y el usuario hizo clic más adelante de ese espacio,
                // lo regresamos a donde debe ir.
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

            // Devolvemos las variables de control a blanco
            cedulaOriginal = "";
            nombreOriginal = "";
            licenciaOriginal = "";
        }
    }
}