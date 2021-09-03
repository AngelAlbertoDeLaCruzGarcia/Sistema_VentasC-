using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Sistema_Ventas
{
    class clsProveedor:clsConexion
    {
        private string Nombre;
        private string Direccion;
        private string Telefono;
        private string Email;
        private string Empresa;



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
        public string EMPRESA
        {
            set { Empresa = value; }
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
            string sql = "insert into tblproveedor (vchNombre,vchEmpresa,vchDireccion,vchTelefono,vchEmail) values ('" + Nombre + "','"+Empresa+"','" +Direccion + "','" + Telefono + "','" + Email + "')";
            operaciones = new MySqlCommand(sql, con);
            operaciones.ExecuteNonQuery();
        }

        public DataTable buscar()
        {
            string sql = "select * from tblproveedor";
            consultas = new MySqlDataAdapter(sql, con);
            tabla = new DataTable();
            consultas.Fill(tabla);
            return tabla;
        }
        public void actualizar(int idprove)
        {
            string sql = "update tblproveedor set vchNombre='" + Nombre +"'vchEmpresa'"+Empresa+ "', vchDireccion='" + Direccion + "', vchTelefono='" + Telefono + "', vchEmail='" + Email + "' where intIdClaveProv="+idprove+";";
        }
        public void elimina(int idprove)
        {
            string sql = "delete from tblproveedor where=" + idprove + ";";
            operaciones = new MySqlCommand(sql, con);
            operaciones.ExecuteNonQuery();

        }
    }
}
