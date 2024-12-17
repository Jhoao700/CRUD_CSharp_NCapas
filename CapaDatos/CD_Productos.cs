using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();
        private SqlCommand comando = new SqlCommand();
        private SqlDataReader leer;
        private DataTable tabla = new DataTable();

        // Método para mostrar productos
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;

            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;
        }

        // Método para insertar un producto
        public void Insertar(string nombre, string descripcion, string marca, double precio, int stock)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsetarProductos";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descrip", descripcion);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método para editar un producto
        public void Editar(string nombre, string descripcion, string marca, double precio, int stock, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descrip", descripcion);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método para eliminar un producto
        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idpro", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
