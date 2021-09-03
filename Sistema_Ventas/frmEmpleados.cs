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
    public partial class frmEmpleados : Form
    {
        clsEmpleado emp = new clsEmpleado();
        public int idemp;
        public frmEmpleados()
        {
            InitializeComponent();
            emp.conectar();
            emp.buscar();
            emp.buscarcargacombo(cmbPuestos);
        }


        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            emp.conectar();
            emp.buscar();
            dgvDatos.DataSource = emp.TABLA;
           
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            emp.NOMBRE = txtNombre.Text;
            emp.DIRECCION = txtDireccion.Text;
            emp.TELEFONO = txtTelefono.Text;
            emp.EMAIL = txtEmail.Text;
            emp.IDPUESTO = int.Parse(cmbPuestos.SelectedValue.ToString());
            emp.USUARIO = txtUser.Text;
            emp.PASSWORD = txtPassword.Text;
            emp.guardar();
            dgvDatos.DataSource = emp.TABLA;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            emp.NOMBRE = txtNombre.Text;
            emp.DIRECCION = txtDireccion.Text;
            emp.TELEFONO = txtTelefono.Text;
            emp.EMAIL = txtEmail.Text;
            emp.IDPUESTO = int.Parse(cmbPuestos.SelectedValue.ToString());
            emp.USUARIO = txtUser.Text;
            emp.PASSWORD = txtPassword.Text;
            emp.elimina(idemp);
            emp.buscar();
            dgvDatos.DataSource=emp.buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = MessageBox.Show("Desea Eliminar este registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    emp.elimina(idemp);
                    dgvDatos.DataSource = emp.buscar();
                }
            }
            catch
            {
                MessageBox.Show("Debe selecionar un registro");
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idemp = int.Parse(dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[0].Value.ToString());
            txtNombre.Text=(dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[1].Value.ToString());
            txtDireccion.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[2].Value.ToString());
            txtTelefono.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[3].Value.ToString());
            txtEmail.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[4].Value.ToString());
            cmbPuestos.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[5].Value.ToString());
            txtUser.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[6].Value.ToString());
            txtPassword.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[7].Value.ToString());

        }
    }
}
