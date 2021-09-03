using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Sistema_Ventas
{
    class clsConexion
    {
        protected MySqlConnection con;
        protected MySqlDataAdapter consultas;
        protected MySqlCommand operaciones = null;
        protected DataTable tabla;
        string cadena = "Data Source=localhost;Initial Catalog=bdventaspractica;user id=root;password=;";

        public void conectar()
        {
            try
            {
                con = new MySqlConnection(cadena);
                con.Open();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error en la conexión");
            }
        }
        public void cerrar()
        {
            con.Close();
            con.Dispose();
        }

    }
}
