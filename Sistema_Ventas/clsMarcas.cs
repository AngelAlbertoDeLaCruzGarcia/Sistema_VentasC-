using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Sistema_Ventas
{
    class clsMarcas:clsConexion
    {
        private string marcas;
        public string MARCAS
        {
            set
            {
                marcas = value;
            }
        }
        public DataTable TABLA
        {
            get
            {
                return tabla;
            }
        }

        public void guardar()
        {
            string sql = "insert into tblmarcas (vchMarca) values ('" + marcas + "');";
            operaciones = new MySqlCommand(sql, con);
            operaciones.ExecuteNonQuery();
        }

        public DataTable buscar()
        {

            string sql = "select * from tblmarcas";

            consultas = new MySqlDataAdapter(sql, con);
            tabla = new DataTable();
            consultas.Fill(tabla);
            return tabla;
        }
        public void actualizar(int intId)
        {
            string sql = "UPDATE `tblmarcas` SET vchMarca='" + marcas + "' WHERE `intid_marcas`=" + intId + ";";

            operaciones = new MySqlCommand(sql, con);
            operaciones.ExecuteNonQuery();
        }
        public void Eliminar(int intId)
        {

            string sql = "DELETE FROM `tblmarcas` WHERE `intid_marcas` =" + intId + ";";
            operaciones = new MySqlCommand(sql, con);
            operaciones.ExecuteNonQuery();
        }
    }
}
