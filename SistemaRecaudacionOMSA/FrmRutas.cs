using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmRutas : Form
    {
        private N_Ruta objNegocio = new N_Ruta();
        private int idRuta = 0;

        // Variables para detectar cambios reales (Memoria)
        private string nombreOriginal = "", tarifaOriginal = "", tiempoOriginal = "", distanciaOriginal = "";

        public FrmRutas()
        {
            InitializeComponent();

            // Estética inicial (Tema Oscuro)
            dgvRutas.BackgroundColor = Color.FromArgb(28, 28, 28);
            dgvRutas.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvRutas.DefaultCellStyle.ForeColor = Color.White;
        }

        private async void FrmRutas_Load(object sender, EventArgs e)
        {
            dgvRutas.Visible = false;
            await MostrarRutasTablaAsync();
            HabilitarCampos(false); // Bloqueo inicial
        }

        // --- LÓGICA DE INTERFAZ (EL CANDADO Y EL OJO) ---

        private void HabilitarCampos(bool estado)
        {
            Color colorLabel = estado ? Color.White : Color.Gray;

            // Labels
            lblNombreRuta.ForeColor = lblTarifa.ForeColor = lblTiempo.ForeColor = lblDistancia.ForeColor = colorLabel;

            // Controles (Asegúrate que estos sean los nombres de tus campos en el diseño)
            txtNombreRuta.Enabled = txtTarifa.Enabled = txtTiempo.Enabled = txtDistancia.Enabled = estado;

            // Botones
            btnGuardar.Enabled = btnActualizar.Enabled = btnEliminar.Enabled = estado;
        }

        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            bool estaAbriendo = !txtNombreRuta.Enabled;
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
                LimpiarCampos();
            }
        }

        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            dgvRutas.Visible = !dgvRutas.Visible;
            btnVerTabla.Text = dgvRutas.Visible ? "Ocultar Tabla" : "Ver Tabla";
            btnVerTabla.ForeColor = dgvRutas.Visible ? Color.Yellow : Color.White;
            btnVerTabla.Image = dgvRutas.Visible ? Properties.Resources.view_off : Properties.Resources.view;
        }

        private bool HayCambiosReales()
        {
            return txtNombreRuta.Text != nombreOriginal || txtTarifa.Text != tarifaOriginal ||
                   txtTiempo.Text != tiempoOriginal || txtDistancia.Text != distanciaOriginal;
        }

        // --- MÉTODOS CRUD ---

        private async Task MostrarRutasTablaAsync()
        {
            try
            {
                dgvRutas.DataSource = await objNegocio.MostrarRutasAsync();

                // Ocultar columnas técnicas
                if (dgvRutas.Columns["ID_Ruta"] != null) dgvRutas.Columns["ID_Ruta"].Visible = false;
                if (dgvRutas.Columns["Estado"] != null) dgvRutas.Columns["Estado"].Visible = false;

                AplicarEstiloTabla();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idRuta != 0)
            {
                if (MessageBox.Show("¿Desea crear un nuevo registro con estos datos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreRuta.Text) || string.IsNullOrWhiteSpace(txtTarifa.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (await objNegocio.VerificarSiExiste(txtNombreRuta.Text))
                {
                    MessageBox.Show("Esta ruta ya existe en el sistema.");
                    return;
                }

                // Mandamos Tiempo y Distancia a la Capa de Negocio
                await objNegocio.InsertarRutaAsync(txtNombreRuta.Text, txtTarifa.Text, txtTiempo.Text, txtDistancia.Text);

                MessageBox.Show("¡Ruta guardada con éxito!", "Éxito");
                await MostrarRutasTablaAsync();
                LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar: " + ex.Message); }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idRuta == 0) return;

            if (!HayCambiosReales())
            {
                MessageBox.Show("No se detectaron cambios para actualizar.", "Aviso");
                return;
            }

            if (MessageBox.Show("¿Desea guardar los cambios realizados?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EditarRutaAsync(idRuta, txtNombreRuta.Text, txtTarifa.Text, txtTiempo.Text, txtDistancia.Text);
                    MessageBox.Show("Ruta actualizada.");
                    await MostrarRutasTablaAsync();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idRuta == 0) return;

            if (MessageBox.Show("¿Está seguro de eliminar esta ruta?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EliminarRutaAsync(idRuta);
                    MessageBox.Show("Ruta eliminada correctamente.");
                    await MostrarRutasTablaAsync();
                    LimpiarCampos();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        // --- EVENTOS DE TABLA Y AUXILIARES ---

        private void dgvRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvRutas.Rows[e.RowIndex];
                idRuta = Convert.ToInt32(fila.Cells["ID_Ruta"].Value);

                txtNombreRuta.Text = nombreOriginal = fila.Cells["NombreRuta"].Value.ToString();
                txtTarifa.Text = tarifaOriginal = fila.Cells["Tarifa"].Value.ToString();

                // Mapeo de las nuevas columnas de la BD
                txtTiempo.Text = tiempoOriginal = fila.Cells["TiempoMinutos"].Value.ToString();
                txtDistancia.Text = distanciaOriginal = fila.Cells["DistanciaKM"].Value.ToString();
            }
        }

        private void AplicarEstiloTabla()
        {
            // 1. Fondo y Bordes Generales
            dgvRutas.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvRutas.BorderStyle = BorderStyle.None;

            // Cuadrícula horizontal sutil (estilo Flat)
            dgvRutas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRutas.GridColor = Color.FromArgb(64, 64, 64);

            // 2. Estilo de la Cabecera (Headers)
            dgvRutas.EnableHeadersVisualStyles = false;
            dgvRutas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRutas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvRutas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRutas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvRutas.ColumnHeadersHeight = 40;

            // 3. Estilo de las Celdas y Filas
            dgvRutas.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvRutas.DefaultCellStyle.ForeColor = Color.White;
            dgvRutas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Azul Windows
            dgvRutas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRutas.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgvRutas.RowTemplate.Height = 35;
            dgvRutas.RowHeadersVisible = false; // Quitar flechita izquierda

            // 4. Configuración de Columnas
            dgvRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRutas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRutas.ReadOnly = true;

            // Renombrar cabeceras según tu nueva base de datos
            if (dgvRutas.Columns["NombreRuta"] != null) dgvRutas.Columns["NombreRuta"].HeaderText = "Nombre de la Ruta";
            if (dgvRutas.Columns["Tarifa"] != null) dgvRutas.Columns["Tarifa"].HeaderText = "Tarifa (RD$)";
            if (dgvRutas.Columns["TiempoMinutos"] != null) dgvRutas.Columns["TiempoMinutos"].HeaderText = "Tiempo (Min)";
            if (dgvRutas.Columns["DistanciaKM"] != null) dgvRutas.Columns["DistanciaKM"].HeaderText = "Distancia (Km)";

            // Ocultar IDs y Estado
            if (dgvRutas.Columns["ID_Ruta"] != null) dgvRutas.Columns["ID_Ruta"].Visible = false;
            if (dgvRutas.Columns["Estado"] != null) dgvRutas.Columns["Estado"].Visible = false;
        }

        private void LimpiarCampos()
        {
            idRuta = 0;
            txtNombreRuta.Clear();
            txtTarifa.Clear();
            txtTiempo.Clear();
            txtDistancia.Clear();
            nombreOriginal = tarifaOriginal = tiempoOriginal = distanciaOriginal = "";
        }

        private void AcomodarCursor_Click(object sender, EventArgs e)
        {
            MaskedTextBox m = sender as MaskedTextBox;
            if (m != null && m.MaskedTextProvider != null)
            {
                int pos = m.MaskedTextProvider.FindUnassignedEditPositionFrom(0, true);
                if (pos != -1 && m.SelectionStart > pos) m.SelectionStart = pos;
            }
        }
    }
}