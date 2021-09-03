
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Sistema_Ventas
{
    class clsPuestos : clsConexion
    {
        private string descripcionpuesto;
        public string DESCRIPCIONPUESTO
        {
            set
            {
                descripcionpuesto = value;
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
            string sql = "insert into tblpuesto (vchDescripcion) values ('" + descripcionpuesto + "')";
            operaciones = new MySqlCommand(sql, con);
            operaciones.ExecuteNonQuery();
        }

        public DataTable buscar()
        {
           
            string sql = "select * from tblpuesto";

            consultas = new MySqlDataAdapter(sql, con);
             tabla = new DataTable();
            consultas.Fill(tabla);
            return tabla;
        }
        public void actualizar(int intId)
        {
            string sql = "UPDATE `tblpuesto` SET vchDescripcion='"+descripcionpuesto+"' WHERE `intIdPuesto`="+intId+";";
            
            operaciones = new MySqlCommand(sql, con);
            operaciones.ExecuteNonQuery();
        }
        public void Eliminar(int intId)
        {

            string sql = "DELETE FROM `tblpuesto` WHERE `intIdPuesto` ="+intId+";";
            operaciones = new MySqlCommand(sql, con);
            operaciones.ExecuteNonQuery();            
        }
    }
}
