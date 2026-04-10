using CapaNegocios;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Formulario para la gestión (CRUD) de las rutas de transporte
    public partial class FrmRutas : Form
    {
        // Instancia de la capa de negocios
        private N_Ruta objNegocio = new N_Ruta();
        private int idRuta = 0;

        // Control de estado para validación de modificaciones
        private string nombreOriginal = "";
        private string tarifaOriginal = "";
        private string tiempoOriginal = "";
        private string distanciaOriginal = "";

        public FrmRutas()
        {
            InitializeComponent();
        }

        // Evento de inicialización del formulario
        private async void FrmRutas_Load(object sender, EventArgs e)
        {
            dgvRutas.Visible = false;

            // Carga asíncrona del catálogo de rutas
            await MostrarRutasTablaAsync();

            HabilitarCampos(false);
        }

        // ==========================================================
        // GESTIÓN VISUAL Y DE INTERFAZ
        // ==========================================================

        // Controla la disponibilidad de los campos y botones según el modo
        private void HabilitarCampos(bool estado)
        {
            Color colorLabel = estado ? Color.White : Color.Gray;
            Color colorBotonApagado = Color.FromArgb(45, 45, 48);

            lblNombreRuta.ForeColor = lblTarifa.ForeColor = lblTiempo.ForeColor = lblDistancia.ForeColor = colorLabel;
            txtNombreRuta.Enabled = txtTarifa.Enabled = txtTiempo.Enabled = txtDistancia.Enabled = estado;

            btnGuardar.Enabled = btnActualizar.Enabled = btnEliminar.Enabled = estado;

            btnGuardar.BackColor = estado ? Color.SeaGreen : colorBotonApagado;
            btnActualizar.BackColor = estado ? Color.Goldenrod : colorBotonApagado;
            btnEliminar.BackColor = estado ? Color.IndianRed : colorBotonApagado;

            btnGuardar.ForeColor = btnActualizar.ForeColor = btnEliminar.ForeColor = colorLabel;
        }

        // Alterna entre modo de visualización protegida y edición activa
        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            bool habilitar = !txtNombreRuta.Enabled;
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
                LimpiarCampos();
            }
        }

        // Muestra u oculta la cuadrícula de datos
        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            dgvRutas.Visible = !dgvRutas.Visible;

            if (dgvRutas.Visible)
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

        // ==========================================================
        // LÓGICA DE VALIDACIÓN Y CONTROL
        // ==========================================================

        // Verifica si el usuario ha modificado los datos cargados de la tabla
        private bool HayCambiosReales()
        {
            return txtNombreRuta.Text != nombreOriginal ||
                   txtTarifa.Text != tarifaOriginal ||
                   txtTiempo.Text != tiempoOriginal ||
                   txtDistancia.Text != distanciaOriginal;
        }

        // Restablece los controles a su estado inicial
        private void LimpiarCampos()
        {
            idRuta = 0;
            txtNombreRuta.Clear();
            txtTarifa.Clear();
            txtTiempo.Clear();
            txtDistancia.Clear();
            nombreOriginal = tarifaOriginal = tiempoOriginal = distanciaOriginal = "";
        }

        // Posiciona correctamente el cursor en máscaras de texto
        private void AcomodarCursor_Click(object sender, EventArgs e)
        {
            MaskedTextBox mascara = sender as MaskedTextBox;
            if (mascara != null && mascara.MaskedTextProvider != null)
            {
                int posicionVisible = mascara.MaskedTextProvider.FindUnassignedEditPositionFrom(0, true);
                if (posicionVisible != -1 && mascara.SelectionStart > posicionVisible)
                {
                    mascara.SelectionStart = posicionVisible;
                }
            }
        }

        // ==========================================================
        // OPERACIONES DE BASE DE DATOS (CRUD)
        // ==========================================================

        // Consulta y renderiza el listado de rutas disponibles
        private async Task MostrarRutasTablaAsync()
        {
            try
            {
                dgvRutas.DataSource = await objNegocio.MostrarRutasAsync();
                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las rutas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Procesa la creación de un nuevo registro de ruta
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idRuta != 0)
            {
                if (MessageBox.Show("¿Desea crear un registro nuevo utilizando estos datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(txtNombreRuta.Text) || string.IsNullOrWhiteSpace(txtTarifa.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Validación de registro único
                if (await objNegocio.VerificarSiExiste(txtNombreRuta.Text))
                {
                    MessageBox.Show("Esta ruta ya se encuentra registrada en el sistema.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await objNegocio.InsertarRutaAsync(txtNombreRuta.Text, txtTarifa.Text, txtTiempo.Text, txtDistancia.Text);

                MessageBox.Show("Ruta registrada exitosamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await MostrarRutasTablaAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la ruta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Guarda las modificaciones realizadas sobre un registro existente
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idRuta == 0) return;

            if (!HayCambiosReales())
            {
                MessageBox.Show("No se han detectado cambios en la información para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea guardar los cambios realizados en esta ruta?", "Confirmar Actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EditarRutaAsync(idRuta, txtNombreRuta.Text, txtTarifa.Text, txtTiempo.Text, txtDistancia.Text);

                    MessageBox.Show("Ruta actualizada correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await MostrarRutasTablaAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la ruta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Ejecuta la baja lógica del registro en el sistema
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idRuta == 0) return;

            if (MessageBox.Show("¿Está seguro de que desea eliminar esta ruta del sistema?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EliminarRutaAsync(idRuta);

                    MessageBox.Show("Ruta eliminada correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await MostrarRutasTablaAsync();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la ruta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================================
        // EVENTOS DE CONTROLES VISUALES
        // ==========================================================

        // Transfiere los datos de la fila seleccionada a los controles de edición
        private void dgvRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvRutas.Rows[e.RowIndex];

                idRuta = Convert.ToInt32(fila.Cells["ID_Ruta"].Value);
                txtNombreRuta.Text = nombreOriginal = fila.Cells["NombreRuta"].Value.ToString();
                txtTarifa.Text = tarifaOriginal = fila.Cells["Tarifa"].Value.ToString();
                txtTiempo.Text = tiempoOriginal = fila.Cells["TiempoMinutos"].Value.ToString();
                txtDistancia.Text = distanciaOriginal = fila.Cells["DistanciaKM"].Value.ToString();
            }
        }

        // Aplica el diseño visual corporativo (Dark Mode) a la cuadrícula
        private void AplicarEstiloTabla()
        {
            dgvRutas.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvRutas.BorderStyle = BorderStyle.None;
            dgvRutas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRutas.GridColor = Color.FromArgb(64, 64, 64);

            dgvRutas.EnableHeadersVisualStyles = false;
            dgvRutas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRutas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvRutas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRutas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvRutas.ColumnHeadersHeight = 40;

            dgvRutas.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvRutas.DefaultCellStyle.ForeColor = Color.White;
            dgvRutas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvRutas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRutas.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvRutas.RowTemplate.Height = 35;
            dgvRutas.RowHeadersVisible = false;

            dgvRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRutas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRutas.ReadOnly = true;

            // Formato de cabeceras (Renombrar y ocultar)
            if (dgvRutas.Columns["NombreRuta"] != null)
                dgvRutas.Columns["NombreRuta"].HeaderText = "Nombre de la Ruta";

            if (dgvRutas.Columns["Tarifa"] != null)
                dgvRutas.Columns["Tarifa"].HeaderText = "Tarifa (RD$)";

            if (dgvRutas.Columns["TiempoMinutos"] != null)
                dgvRutas.Columns["TiempoMinutos"].HeaderText = "Tiempo (Min)";

            if (dgvRutas.Columns["DistanciaKM"] != null)
                dgvRutas.Columns["DistanciaKM"].HeaderText = "Distancia (Km)";

            if (dgvRutas.Columns["ID_Ruta"] != null)
                dgvRutas.Columns["ID_Ruta"].Visible = false;

            if (dgvRutas.Columns["Estado"] != null)
                dgvRutas.Columns["Estado"].Visible = false;
        }
    }
}