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
    public partial class frmMarcas : Form
    {
        int intId;
        clsMarcas marcas = new clsMarcas();
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            marcas.MARCAS= txtMarcas.Text;
            marcas.guardar();
            marcas.buscar();
            dgvDatos.DataSource = marcas.TABLA;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            marcas.MARCAS = txtMarcas.Text;
            marcas.actualizar(intId);
            marcas.buscar();
            dgvDatos.DataSource = marcas.TABLA;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = MessageBox.Show("Desea Eliminar este registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    marcas.Eliminar(intId);
                    dgvDatos.DataSource = marcas.buscar();
                }
            }
            catch
            {
                MessageBox.Show("Debe selecionar un registro");
            }

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            intId = int.Parse(dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[0].Value.ToString());
            txtMarcas.Text = (dgvDatos.Rows[dgvDatos.CurrentRow.Index].Cells[1].Value.ToString());

        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            marcas.conectar();
            marcas.buscar();
            dgvDatos.DataSource = marcas.TABLA;
        }
    }
}
