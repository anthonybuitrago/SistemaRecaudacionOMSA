using System;
using System.Drawing;
using System.Threading.Tasks; // Obligatorio para Task
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmViajes : Form
    {
        // Instancias para acceder a la lógica de todas las entidades relacionadas
        private N_Viaje objViaje = new N_Viaje();
        private N_Chofer objChofer = new N_Chofer();
        private N_Ruta objRuta = new N_Ruta();
        private N_Vehiculo objVehiculo = new N_Vehiculo();

        // Variable para identificar el viaje seleccionado en la tabla
        private int idViaje = 0;
        private string modoFormulario;

        // Constructor del formulario
        public FrmViajes()
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
                dgvViajes.Dock = DockStyle.Fill;
            }
            else
            {
                dgvViajes.Visible = false;
                BloquearCampos();
            }
        }

        // Evento ASÍNCRONO inicial
        private async void FrmViajes_Load(object sender, EventArgs e)
        {
            txtEstado.Text = "Activo";
            txtEstado.ReadOnly = true;

            // Carga de información asíncrona
            await CargarListasDesplegablesAsync();
            await MostrarViajesTablaAsync();

            BloquearCampos(); // Los campos arrancan desactivados
        }

        // Método ASÍNCRONO para llenar los ComboBox
        private async Task CargarListasDesplegablesAsync()
        {
            try
            {
                // Cargamos cada lista esperando la respuesta de la Capa de Negocio
                cmbChofer.DataSource = await objChofer.MostrarChoferesAsync();
                cmbChofer.DisplayMember = "NombreCompleto";
                cmbChofer.ValueMember = "ID_Chofer";

                cmbRuta.DataSource = await objRuta.MostrarRutasAsync();
                cmbRuta.DisplayMember = "NombreRuta";
                cmbRuta.ValueMember = "ID_Ruta";

                cmbVehiculo.DataSource = await objVehiculo.MostrarVehiculosAsync();
                cmbVehiculo.DisplayMember = "Ficha";
                cmbVehiculo.ValueMember = "ID_Vehiculo";

                // Limpieza de selecciones automáticas al iniciar
                cmbChofer.SelectedIndex = -1;
                cmbRuta.SelectedIndex = -1;
                cmbVehiculo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento ASÍNCRONO para registrar un nuevo viaje
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbChofer.SelectedValue == null || cmbRuta.SelectedValue == null || cmbVehiculo.SelectedValue == null)
            {
                MessageBox.Show("Por favor, asegúrese de seleccionar Chofer, Ruta y Vehículo.", "Aviso OMSA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idChof = cmbChofer.SelectedValue.ToString();
                string idRut = cmbRuta.SelectedValue.ToString();
                string idVeh = cmbVehiculo.SelectedValue.ToString();
                DateTime fechaViaje = dtpFecha.Value;
                string estado = txtEstado.Text;

                await objViaje.InsertarViajeAsync(idChof, idRut, idVeh, fechaViaje, estado);

                MessageBox.Show("¡Viaje registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await MostrarViajesTablaAsync();
                btnLimpiar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método ASÍNCRONO para refrescar los datos de la tabla
        private async Task MostrarViajesTablaAsync()
        {
            try
            {
                dgvViajes.DataSource = await objViaje.MostrarViajesAsync();
                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LÓGICA DE INTERFAZ: BLOQUEO Y HABILITACIÓN ---

        private void BloquearCampos()
        {
            cmbChofer.Enabled = false;
            cmbRuta.Enabled = false;
            cmbVehiculo.Enabled = false;
            dtpFecha.Enabled = false;
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void HabilitarCampos()
        {
            cmbChofer.Enabled = true;
            cmbRuta.Enabled = true;
            cmbVehiculo.Enabled = true;
            dtpFecha.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbChofer.SelectedIndex = -1;
            cmbRuta.SelectedIndex = -1;
            cmbVehiculo.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            txtEstado.Text = "Activo";
            idViaje = 0;

            HabilitarCampos();
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = false;

            if (modoFormulario.Equals("Consulta", StringComparison.OrdinalIgnoreCase))
            {
                panel1.Visible = false; // Se esconde al terminar
            }
        }

        private void dgvViajes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idViaje = Convert.ToInt32(dgvViajes.Rows[e.RowIndex].Cells["ID"].Value);
                cmbChofer.Text = dgvViajes.Rows[e.RowIndex].Cells["Chofer"].Value.ToString();
                cmbRuta.Text = dgvViajes.Rows[e.RowIndex].Cells["Ruta"].Value.ToString();
                cmbVehiculo.Text = dgvViajes.Rows[e.RowIndex].Cells["Ficha del Vehículo"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(dgvViajes.Rows[e.RowIndex].Cells["Fecha y Hora"].Value);
                txtEstado.Text = dgvViajes.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

                panel1.Visible = true; // Aparece el cajón para editar

                HabilitarCampos();
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        // Evento ASÍNCRONO para realizar el borrado lógico (Cancelación)
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            if (idViaje == 0) return;

            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea cancelar este viaje?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await objViaje.CancelarViajeAsync(idViaje.ToString());
                    MessageBox.Show("El viaje ha sido cancelado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await MostrarViajesTablaAsync();
                    btnLimpiar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cancelar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento ASÍNCRONO para actualizar
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idViaje == 0) return;

            try
            {
                string idChof = cmbChofer.SelectedValue.ToString();
                string idRut = cmbRuta.SelectedValue.ToString();
                string idVeh = cmbVehiculo.SelectedValue.ToString();
                DateTime fecha = dtpFecha.Value;
                string estado = txtEstado.Text;

                await objViaje.EditarViajeAsync(idViaje.ToString(), idChof, idRut, idVeh, fecha, estado);
                MessageBox.Show("¡Viaje actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await MostrarViajesTablaAsync();
                btnLimpiar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarEstiloTabla()
        {
            dgvViajes.AllowUserToAddRows = false;
            dgvViajes.RowHeadersVisible = false;
            dgvViajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViajes.BackgroundColor = Color.White;
            dgvViajes.BorderStyle = BorderStyle.None;
            dgvViajes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvViajes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvViajes.GridColor = Color.Gainsboro;
            dgvViajes.EnableHeadersVisualStyles = false;
            dgvViajes.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
            dgvViajes.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvViajes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvViajes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvViajes.ColumnHeadersHeight = 40;
            dgvViajes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvViajes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9");
            dgvViajes.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvViajes.RowTemplate.Height = 35;

            if (dgvViajes.Columns.Count > 0)
            {
                dgvViajes.Columns["ID"].Width = 40;
            }
        }
    }
}