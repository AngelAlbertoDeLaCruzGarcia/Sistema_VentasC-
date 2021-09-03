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
    public partial class frmProveedor : Form
    {
        public int idprove;
        clsProveedor proveedor = new clsProveedor();
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            proveedor.NOMBRE = txtNombre.Text;
            proveedor.DIRECCION = txtDireccion.Text;
            proveedor.TELEFONO = txtTelefono.Text;
            proveedor.EMAIL = txtEmail.Text;
            proveedor.EMPRESA = txtEmpresa.Text;
            proveedor.guardar();
            dgvDatos.DataSource = proveedor.TABLA;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            proveedor.NOMBRE = txtNombre.Text;
            proveedor.DIRECCION = txtDireccion.Text;
            proveedor.TELEFONO = txtTelefono.Text;
            proveedor.EMAIL = txtEmail.Text;
            proveedor.EMPRESA = txtEmpresa.Text;
            proveedor.actualizar(idprove);
            dgvDatos.DataSource = proveedor.buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = MessageBox.Show("Desea Eliminar este registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    proveedor.elimina(idprove);
                    dgvDatos.DataSource = proveedor.buscar();
                }
            }
            catch
            {
                MessageBox.Show("Debe selecionar un registro");
            }
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            proveedor.conectar();
            proveedor.buscar();
            dgvDatos.DataSource = proveedor.TABLA;

        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idprove = int.Parse(dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[0].Value.ToString());
            txtNombre.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[1].Value.ToString());
            txtDireccion.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[3].Value.ToString());
            txtTelefono.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[4].Value.ToString());
            txtEmail.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[5].Value.ToString());
            txtEmpresa.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[2].Value.ToString());

        }
    }
}
