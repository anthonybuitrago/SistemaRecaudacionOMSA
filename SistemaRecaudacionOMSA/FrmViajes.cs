using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmViajes : Form
    {
        private N_Viaje objViaje = new N_Viaje();
        private N_Chofer objChofer = new N_Chofer();
        private N_Ruta objRuta = new N_Ruta();
        private N_Vehiculo objVehiculo = new N_Vehiculo();

        private int idViaje = 0;
        private string modoFormulario;
        private string choferOriginal = "";
        private string rutaOriginal = "";
        private string vehiculoOriginal = "";
        private DateTime fechaOriginal;

        public FrmViajes()
        {
            InitializeComponent();

            // Estética inicial
            dgvViajes.BackgroundColor = Color.FromArgb(28, 28, 28);
            dgvViajes.BorderStyle = BorderStyle.None;
            dgvViajes.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvViajes.DefaultCellStyle.ForeColor = Color.White;

            AplicarEstiloTabla();
        }

        private async void FrmViajes_Load(object sender, EventArgs e)
        {
            dtpFecha.MinDate = DateTime.Today;
            dgvViajes.Visible = false;

            await CargarListasDesplegablesAsync();
            await MostrarViajesTablaAsync();

            HabilitarCampos(false);

            // DESHABILITAR EL BOTÓN AL INICIO
            btnLimpiar.Enabled = false;
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private async Task CargarListasDesplegablesAsync()
        {
            try
            {
                cmbChofer.DataSource = await objChofer.MostrarChoferesAsync();
                cmbChofer.DisplayMember = "NombreCompleto";
                cmbChofer.ValueMember = "ID_Chofer";

                cmbRuta.DataSource = await objRuta.MostrarRutasAsync();
                cmbRuta.DisplayMember = "NombreRuta";
                cmbRuta.ValueMember = "ID_Ruta";

                cmbVehiculo.DataSource = await objVehiculo.MostrarVehiculosAsync();
                cmbVehiculo.DisplayMember = "Ficha";
                cmbVehiculo.ValueMember = "ID_Vehiculo";

                cmbChofer.SelectedIndex = -1;
                cmbRuta.SelectedIndex = -1;
                cmbVehiculo.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Error listas: " + ex.Message); }
        }

        private void HabilitarCampos(bool estado)
        {
            // Campos
            cmbChofer.Enabled = estado;
            dtpFecha.Enabled = estado;
            cmbRuta.Enabled = estado;
            cmbVehiculo.Enabled = estado;

            // Botones CRUD (Se ponen grises automáticamente si Enabled = false)
            btnGuardar.Enabled = estado;
            btnActualizar.Enabled = false; // Solo se activa al tocar la tabla
            btnCancelar.Enabled = estado;
            btnLimpiar.Enabled = true; // Limpiar siempre debería estar activo

            // Colores de Labels
            Color colorTexto = estado ? Color.White : Color.Gray;
            lblChofer.ForeColor = colorTexto;
            lblRuta.ForeColor = colorTexto;
            lblVehiculo.ForeColor = colorTexto;
            lblFecha.ForeColor = colorTexto;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbChofer.SelectedValue == null || cmbRuta.SelectedValue == null)
            {
                MessageBox.Show("Faltan datos.");
                return;
            }

            try
            {
                await objViaje.InsertarViajeAsync(
    cmbChofer.SelectedValue.ToString(),
    cmbRuta.SelectedValue.ToString(),
    cmbVehiculo.SelectedValue.ToString(),
    dtpFecha.Value,
    "Activo" // <--- Aquí enviamos el estado por debajo de la mesa
);

                MessageBox.Show("¡Guardado!");
                await MostrarViajesTablaAsync();
                btnLimpiar.PerformClick();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idViaje == 0) return;
            try
            {
                // Añadimos "Activo" al final antes de cerrar el paréntesis
                await objViaje.EditarViajeAsync(
                    idViaje.ToString(),
                    cmbChofer.SelectedValue.ToString(),
                    cmbRuta.SelectedValue.ToString(),
                    cmbVehiculo.SelectedValue.ToString(),
                    dtpFecha.Value,
                    "Activo" // <--- Este es el parámetro que faltaba
                );

                MessageBox.Show("¡Actualizado!");
                await MostrarViajesTablaAsync();
                btnLimpiar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvViajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // REGLA DE ORO: Si el candado está cerrado, ignoramos el clic para el formulario
            if (cmbChofer.Enabled == false) return;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvViajes.Rows[e.RowIndex];

                // Solo si llegamos aquí (porque el candado está abierto), cargamos los datos
                idViaje = Convert.ToInt32(fila.Cells["ID"].Value);
                // (Dentro de dgvViajes_CellClick, después de asignar los combos)
                cmbChofer.Text = fila.Cells["Chofer"].Value.ToString();
                cmbRuta.Text = fila.Cells["Ruta"].Value.ToString();
                cmbVehiculo.Text = fila.Cells["Ficha del Vehículo"].Value.ToString();

                // GUARDAMOS LA FOTO ORIGINAL:
                choferOriginal = cmbChofer.Text;
                rutaOriginal = cmbRuta.Text;
                vehiculoOriginal = cmbVehiculo.Text;

                dtpFecha.MinDate = new DateTime(1900, 1, 1);
                if (fila.Cells["Fecha y Hora"].Value != DBNull.Value)
                {
                    dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha y Hora"].Value);
                    fechaOriginal = dtpFecha.Value; // Guardamos la fecha original
                }

                // Habilitamos los botones de acción porque estamos en modo edición
                btnActualizar.Enabled = true;
                btnCancelar.Enabled = true;
                btnLimpiar.Enabled = true;
                btnGuardar.Enabled = false; // No se puede guardar uno nuevo si seleccionaste uno viejo
                                            // 1. GUARDAMOS LA MEMORIA PRIMERO (Directo desde la fila)
                choferOriginal = fila.Cells["Chofer"].Value.ToString();
                rutaOriginal = fila.Cells["Ruta"].Value.ToString();
                vehiculoOriginal = fila.Cells["Ficha del Vehículo"].Value.ToString();

                dtpFecha.MinDate = new DateTime(1900, 1, 1);
                if (fila.Cells["Fecha y Hora"].Value != DBNull.Value)
                {
                    fechaOriginal = Convert.ToDateTime(fila.Cells["Fecha y Hora"].Value);
                }

                // 2. LUEGO ASIGNAMOS A LOS CONTROLES
                // (Ahora, si los controles disparan el evento de cambio, la memoria ya los está esperando)
                cmbChofer.Text = choferOriginal;
                cmbRuta.Text = rutaOriginal;
                cmbVehiculo.Text = vehiculoOriginal;
                dtpFecha.Value = fechaOriginal;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // 1. Vaciamos los datos de los controles
            idViaje = 0; // Importante resetear el ID a 0 para que sea un "Nuevo Viaje"
            cmbChofer.SelectedIndex = -1;
            cmbRuta.SelectedIndex = -1;
            cmbVehiculo.SelectedIndex = -1;

            // Reseteamos la fecha a hoy (ajustando MinDate para evitar el error de rango)
            dtpFecha.MinDate = new DateTime(1900, 1, 1);
            dtpFecha.Value = DateTime.Now;
            dtpFecha.MinDate = DateTime.Today;

            // 2. ¡LA CORRECCIÓN! 
            // NO llamamos a HabilitarCampos(false). 
            // Los campos se quedan como están (si estaban habilitados, siguen habilitados).

            // 3. Ajustamos los botones de acción
            // Como ahora todo está limpio, es un registro nuevo:
            btnGuardar.Enabled = true;     // Se habilita para poder guardar lo nuevo
            btnActualizar.Enabled = false; // Se apaga porque no hay nada viejo que actualizar
            btnCancelar.Enabled = false;   // Se apaga porque no hay nada seleccionado

            // Quitamos la selección azul de la tabla para que se vea visualmente "limpio"
            dgvViajes.ClearSelection();
        }

        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            bool estaAbriendo = !cmbChofer.Enabled;
            HabilitarCampos(estaAbriendo);

            // (Dentro de btnModoEdicion_Click)
            if (estaAbriendo)
            {
                btnLimpiar.Enabled = true;

                if (idViaje > 0)
                {
                    // OBLIGAMOS AL VIGILANTE A REVISAR AHORA MISMO
                    VerificarSiHayCambios(null, null);
                }
                else
                {
                    btnGuardar.Enabled = true;
                }
            }
        }

        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            dgvViajes.Visible = !dgvViajes.Visible;
            btnVerTabla.Text = dgvViajes.Visible ? "Ocultar" : "Ver";
            // Si la tabla se oculta, hacemos que el panel de arriba use más espacio si quieres
        }

        private async Task MostrarViajesTablaAsync()
        {
            dgvViajes.DataSource = await objViaje.MostrarViajesAsync();
            // 1. Ocultar la columna ID (El despachador no necesita ver esto)
            if (dgvViajes.Columns["ID"] != null)
            {
                dgvViajes.Columns["ID"].Visible = false;
            }

            // 2. Formatear la Fecha y Hora para que sea más limpia
            if (dgvViajes.Columns["Fecha y Hora"] != null)
            {
                // Formato de 12 horas con AM/PM (ej: 03/04/2026 09:14 PM)
                dgvViajes.Columns["Fecha y Hora"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

                // Centramos el texto de la fecha para que se vea más ordenado
                dgvViajes.Columns["Fecha y Hora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 3. Opcional: Darle más espacio a columnas importantes
            if (dgvViajes.Columns["Chofer"] != null) dgvViajes.Columns["Chofer"].FillWeight = 150;
            if (dgvViajes.Columns["Ruta"] != null) dgvViajes.Columns["Ruta"].FillWeight = 150;
            if (dgvViajes.Columns["Estado"] != null) dgvViajes.Columns["Estado"].FillWeight = 80;
            AplicarEstiloTabla();
        }

        private void AplicarEstiloTabla()
        {
            // 1. Alineación y Simetría
            dgvViajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViajes.RowHeadersVisible = false; // Quita la columna gris de la izquierda
            dgvViajes.BorderStyle = BorderStyle.None;

            // 2. Tipografía (Cambia "Segoe UI" por el nombre exacto de tu Google Font)
            Font fuenteGoogle = new Font("Segoe UI", 10); // <-- Pon aquí el nombre de tu fuente
            Font fuenteGoogleBold = new Font("Segoe UI", 10, FontStyle.Bold);

            // 3. Estilo de Celdas
            dgvViajes.DefaultCellStyle.Font = fuenteGoogle;
            dgvViajes.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvViajes.DefaultCellStyle.ForeColor = Color.White;
            dgvViajes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Azul moderno

            // 4. Estilo de Encabezados (Para que no sean blancos brillantes)
            dgvViajes.EnableHeadersVisualStyles = false;
            dgvViajes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgvViajes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvViajes.ColumnHeadersDefaultCellStyle.Font = fuenteGoogleBold;
            dgvViajes.ColumnHeadersHeight = 40;
        }

        // Eventos vacíos que puedes borrar si no los usas
        private void label2_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            // Si no hay un viaje seleccionado, no hace nada
            if (idViaje == 0) return;

            // Preguntamos para confirmar, porque cancelar es delicado
            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea cancelar este viaje?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Llamamos a tu capa de negocios para cancelar
                    await objViaje.CancelarViajeAsync(idViaje.ToString());

                    MessageBox.Show("El viaje ha sido cancelado exitosamente.", "Sistema OMSA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargamos la tabla para que se vea el cambio
                    await MostrarViajesTablaAsync();

                    // Volvemos el formulario a su estado original
                    btnLimpiar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cancelar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void VerificarSiHayCambios(object sender, EventArgs e)
        {
            // Si no estamos en modo edición o es un viaje nuevo, apagamos y abortamos
            if (idViaje == 0 || cmbChofer.Enabled == false)
            {
                btnActualizar.Enabled = false;
                return;
            }

            // Comparamos los textos (Usamos variables booleanas para que sea más fácil leer el código)
            bool cambioChofer = (cmbChofer.Text != choferOriginal);
            bool cambioRuta = (cmbRuta.Text != rutaOriginal);
            bool cambioVehiculo = (cmbVehiculo.Text != vehiculoOriginal);

            // Comparamos fecha y hora (ignorando los segundos y milisegundos)
            bool cambioFecha = (dtpFecha.Value.ToString("yyyy-MM-dd HH:mm") != fechaOriginal.ToString("yyyy-MM-dd HH:mm"));

            // Si CUALQUIERA de estas cosas es verdadera, se enciende. Si todas son falsas, se apaga.
            btnActualizar.Enabled = (cambioChofer || cambioRuta || cambioVehiculo || cambioFecha);
        }

        private void dgvViajes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificamos que la fila y la columna sean válidas
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Revisamos si la columna que se está dibujando es la de "Estado"
                if (dgvViajes.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
                {
                    string estado = e.Value.ToString();

                    // Si el viaje está Cancelado -> Texto Rojo (Salmon para que no lastime la vista en fondo oscuro)
                    if (estado == "Cancelado")
                    {
                        e.CellStyle.ForeColor = Color.LightCoral;
                        e.CellStyle.SelectionForeColor = Color.LightCoral; // Para que siga rojo si lo seleccionas

                        // Efecto PRO: Tachar toda la fila si está cancelado (Opcional, pero se ve genial)
                        // dgvViajes.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(dgvViajes.Font, FontStyle.Strikeout);
                    }
                    // Si el viaje está Activo -> Texto Verde brillante
                    else if (estado == "Activo")
                    {
                        e.CellStyle.ForeColor = Color.LightGreen;
                        e.CellStyle.SelectionForeColor = Color.LightGreen;
                        e.CellStyle.Font = new Font(dgvViajes.Font, FontStyle.Bold); // Letra en negrita
                    }
                }
            }
        }
    }
}