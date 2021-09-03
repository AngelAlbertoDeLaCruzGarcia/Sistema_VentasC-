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
    class clsProductos:clsConexion
    {
        private string Nombre;
        private string Codigo;
        private int Marca,prov;
        private float Precio;
        private int Existencia;
        string Proveedor;
        DataTable tablaparacombo, tablaparacombo2;

        public int PROV
        {
            set { prov = value; }
        }
        public string NOMBRE
        {
            set { Nombre = value; }
        }
        public string CODIGO
        {
            set { Codigo = value; }
        }
        public int MARCA
        {
            set { Marca = value; }
        }
        public float PRECIO
        {
            set { Precio = value; }
        }
        public int EXISTENCIA
        {
            set { Existencia  = value; }
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
            string sql = "INSERT INTO `tblproductos` (`vchNombreProd`,`vchCodigo`,`intid_marcas`,`fltPrecio`,`intExistencia`,`intidproveedor`) VALUES ('"+Nombre+"','"+Codigo+"',"+Marca+","+Precio+","+Existencia+","+Proveedor+");";

            operaciones = new MySqlCommand(sql, con);
            operaciones.ExecuteNonQuery();
        }

        public DataTable buscar()
        {
            string sql = "select * from tblproductos";
            consultas = new MySqlDataAdapter(sql, con);
            tabla = new DataTable();
            consultas.Fill(tabla);
            return tabla;
        }
        public void actualizar(int clave)
        {
            string sql = "update tblproductos set vchNombre='" + Nombre + "'vchCodigo'" + Codigo + "', intid_marcas=" + Marca + ", fltPrecio=" + Precio + ", intExistencia=" + Existencia + ",intidproveedor=" + Proveedor + "where intClaveP=" + clave + ";";
        }
        public void elimina(int clave)
        {
            string sql = "delete from tblproductos where=" + clave + ";";
            operaciones = new MySqlCommand(sql, con);
            operaciones.ExecuteNonQuery();

        }
        public void buscarcargacombo(ComboBox cmbProveedor)
        {
            string sql = "select intIdClaveProv, vchNombreProd from tblproveedor";
            consultas = new MySqlDataAdapter(sql, con);
            consultas.SelectCommand.CommandType = CommandType.Text;
            tablaparacombo = new DataTable();
            consultas.Fill(tablaparacombo);
            cmbProveedor.DisplayMember = "vchNombreProd";
            cmbProveedor.ValueMember = "intIdClaveProv";
            cmbProveedor.DataSource = tablaparacombo;
        }
        public void buscarcargacombo2(ComboBox cmbMarcas)
        {
            string sql = "select intid_marcas, vchMarca from tblmarcas";
            consultas = new MySqlDataAdapter(sql, con);
            consultas.SelectCommand.CommandType = CommandType.Text;
            tablaparacombo2 = new DataTable();
            consultas.Fill(tablaparacombo);
            cmbMarcas.DisplayMember = "vchMarca";
            cmbMarcas.ValueMember = "intid_marcas";
            cmbMarcas.DataSource = tablaparacombo2;
        }
    }
}
