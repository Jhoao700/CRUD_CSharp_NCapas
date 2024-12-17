using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Conexion
    {
        // Configura tu cadena de conexión (ajústala a tu servidor SQL Server)
        private SqlConnection Conexion = new SqlConnection("Server=DESKTOP-PTGHP4D;Database=Practica;Integrated Security=True");

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
