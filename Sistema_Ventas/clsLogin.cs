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
    class clsLogin : clsConexion
    {
        private string usuario;
        private string password;
        private bool respuesta;
        public string USUARIO
        {
            set
            {
                usuario = value;
            }
        }
        public string PASSW
        {
            set
            {
                password = value;
            }
        }
        public bool RESPUESTA
        {
            get
            {
                return respuesta;
            }
        }
        public void acceso()
        {
            tabla = new DataTable();
            string sql = "select vchusuario, vchpassword from tblempleado where vchusuario='" + usuario + "' and vchpassword='" + password + "';";
            consultas = new MySqlDataAdapter(sql, con);
            consultas.Fill(tabla);
            if (tabla.Rows.Count > 0)
            {
                respuesta = true;
            }
            else
            {
                respuesta = false;
                System.Windows.Forms.MessageBox.Show("El usuario no existe");
            }
        }

    }
}
