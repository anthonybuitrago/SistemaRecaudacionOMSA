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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Vaciamos las cajas de texto
            txtCedula.Clear();
            txtNombre.Clear();
            txtLicencia.Clear();

            // Ponemos el cursor de vuelta en la primera caja
            txtCedula.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Método vacío para solucionar el error del diseñador
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
    }
}