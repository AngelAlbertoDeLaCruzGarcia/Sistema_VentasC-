using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
namespace Sistema_Ventas
{
    class clsEmpleado:clsConexion
    {
        private string Nombre;
        private string Direccion;
        private string Telefono;
        private string Email;
        private int idPuesto;
        private string usuario;
        private string password;
        private DataTable tablaparacombo;
        

        public string NOMBRE
        {
            set { Nombre = value; }
        }
        public string DIRECCION
        {
            set { Direccion = value; }
        }
        public string TELEFONO
        {
            set { Telefono = value; }
        }
        public string EMAIL
        {
            set { Email = value; }
        }
        public int IDPUESTO
        {
            set { idPuesto = value; }
        }
        public string USUARIO
        {
            set { usuario = value; }
        }
        public string PASSWORD
        {
            set { password = value; }
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
            string sql = "insert into tblempleado (vchNombre,vchDireccion,vchTelefono,vchEmail,intidpuesto,vchUsuario,vchPassword) values ('" + Nombre + "','" + Direccion + "','" + Telefono + "','" + Email + "'," + idPuesto + ",'" + usuario + "','" + password + "')";
            operaciones = new MySqlCommand(sql, con);
            operaciones.ExecuteNonQuery();
        }

        public DataTable buscar()
        {
            string sql = "select * from tblempleado";
            consultas = new MySqlDataAdapter(sql, con);
            tabla = new DataTable();
            consultas.Fill(tabla);
            return tabla;
        }
        public void actualizar(int idemp)
        { 
            string sql="update tblempleado set vchNombre='"+Nombre+"', vchDireccion='"+Direccion+"', vchTelefono='"+Telefono+"', vchEmail='"+Email+"', intidpuesto="+idPuesto+", vchUsuario='"+usuario+"', vchPassword='"+password+"' where intidempleado="+idemp+";";
        }
        public void elimina(int idemp)
        {
            string sql = "delete from tblempleado where="+idemp+";";
            operaciones = new MySqlCommand(sql,con);
            operaciones.ExecuteNonQuery();
        
        }


        public void buscarcargacombo(ComboBox cmbPuesto)
        {
            string sql = "select intIdPuesto, vchDescripcion from tblpuesto";
            consultas = new MySqlDataAdapter(sql, con);
            consultas.SelectCommand.CommandType = CommandType.Text;
            tablaparacombo = new DataTable();
            consultas.Fill(tablaparacombo);
            cmbPuesto.DisplayMember = "vchDescripcion";
            cmbPuesto.ValueMember = "intIdPuesto";
            cmbPuesto.DataSource = tablaparacombo;
        }
    }
}
