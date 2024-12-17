using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        // Método para mostrar productos
        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        // Método para insertar un producto
        public void InsertarProd(string nombre, string descripcion, string marca, string precio, string stock)
        {
            objetoCD.Insertar(nombre, descripcion, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }

        // Método para editar un producto
        public void EditarProd(string nombre, string descripcion, string marca, string precio, string stock, string id)
        {
            objetoCD.Editar(nombre, descripcion, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }

        // Método para eliminar un producto
        public void EliminarProd(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
