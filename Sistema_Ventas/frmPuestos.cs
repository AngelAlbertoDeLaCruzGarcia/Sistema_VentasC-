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
    public partial class frmPuestos : Form
    {
        clsPuestos puesto = new clsPuestos();
        public int idpuestos;
        public frmPuestos()
        {
            InitializeComponent();
        }

        private void frmPuestos_FormClosed(object sender, FormClosedEventArgs e)
        {
            puesto.cerrar();
        }

        private void frmPuestos_Load(object sender, EventArgs e)
        {
            puesto.conectar();
            puesto.buscar();
            dgvDatos.DataSource = puesto.TABLA;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPuestos.Text = dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[1].Value.ToString();
            idpuestos = int.Parse(dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[0].Value.ToString());
            

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            puesto.DESCRIPCIONPUESTO = txtPuestos.Text;
            puesto.guardar();
            puesto.buscar();
            dgvDatos.DataSource = puesto.TABLA;

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
             try
            {
                DialogResult resp = MessageBox.Show("Desea Eliminar este registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    puesto.Eliminar(idpuestos);
                    dgvDatos.DataSource = puesto.buscar();
                }
            }
             catch
             {
                 MessageBox.Show("Debe selecionar un registro");
             }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            puesto.DESCRIPCIONPUESTO = txtPuestos.Text;
            puesto.actualizar(idpuestos);
            dgvDatos.DataSource = puesto.buscar();
        }


 
    }
}
