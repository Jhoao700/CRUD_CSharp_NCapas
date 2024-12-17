using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto = null;

        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        private void MostrarProductos()
        {
            dgvProductos.DataSource = objetoCN.MostrarProd();
        }

        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            idProducto = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.InsertarProd(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                MessageBox.Show("Producto insertado correctamente");
                MostrarProductos();
                LimpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    // Obtener el ID del producto seleccionado
                    idProducto = dgvProductos.CurrentRow.Cells["Id"].Value.ToString();

                    // Cargar los datos seleccionados en los TextBoxes
                    txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = dgvProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
                    txtMarca.Text = dgvProductos.CurrentRow.Cells["Marca"].Value.ToString();
                    txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
                    txtStock.Text = dgvProductos.CurrentRow.Cells["Stock"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para editar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    idProducto = dgvProductos.CurrentRow.Cells["Id"].Value.ToString();
                    objetoCN.EliminarProd(idProducto);
                    MessageBox.Show("Producto eliminado correctamente");
                    MostrarProductos();
                    LimpiarForm();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarForm(); // Llama al método que limpia los campos del formulario
        }
    }
}
