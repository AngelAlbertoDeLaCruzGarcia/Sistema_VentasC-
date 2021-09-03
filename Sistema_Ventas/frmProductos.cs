using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Ventas
{
    public partial class frmProductos : Form
    {
        clsProductos prod = new clsProductos();
        public frmProductos()
        {
            
            InitializeComponent();
            prod.conectar();
            prod.buscar();
            prod.buscarcargacombo(cmbProveedor);
            prod.buscarcargacombo2(cmbMarcas);
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            prod.conectar();
            prod.buscar();
            dgvDatos.DataSource = prod.TABLA;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            prod.NOMBRE = txtNombre.Text;
            prod.CODIGO = txtCodigo.Text;
            prod.EXISTENCIA = int.Parse(txtExistencia.Text);
            prod.PRECIO = float.Parse(txtPrecio.Text);
            prod.MARCA = int.Parse(cmbMarcas.SelectedValue.ToString());
            prod.PROV = int.Parse(cmbProveedor.SelectedValue.ToString());
            prod.guardar();
            dgvDatos.DataSource = prod.TABLA;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
