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
    public partial class frmPrincipal : Form
    {
        frmPuestos vistapuestos;
        frmEmpleados vistaemp;
        frmMarcas vistamarcas;
        frmProductos vistaprod;
        frmProveedor vistaprov;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(vistapuestos==null)
            {
                vistapuestos = new frmPuestos();
                vistapuestos.Disposed += new EventHandler(cierravistapuestos);
                vistapuestos.MdiParent = this;
                vistapuestos.Show();
            }
        }
        private void cierravistapuestos(object sender, EventArgs e)
        {
            vistapuestos = null;
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin frmlogin = new frmLogin();
            frmlogin.ShowDialog();
            if (frmlogin.res == true)
            {
                mnsMenu.Enabled = true;

            }
            else
                mnsMenu.Enabled = false;
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vistaemp == null)
            {
                vistaemp = new frmEmpleados();
                vistaemp.Disposed += new EventHandler(cierravistaemp);
                vistaemp.MdiParent = this;
                vistaemp.Show();

            }
        }      

        private void cierravistaemp(object sender, EventArgs e)
        {
            vistaemp = null;
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vistamarcas == null)
            {
                vistamarcas = new frmMarcas();
                vistamarcas.Disposed += new EventHandler(cierravistamarcas);
                vistamarcas.MdiParent = this;
                vistamarcas.Show();
            }
        }
        private void cierravistamarcas(object sender, EventArgs e)
        {
            vistamarcas = null;
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vistaprod == null)
            {
                vistaprod = new frmProductos();
                vistaprod.Disposed += new EventHandler(cierravistaprod);
                vistaprod.MdiParent = this;
                vistaprod.Show();
            }
        }
        private void cierravistaprod(object sender, EventArgs e)
        {
            vistaprod = null;
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vistaprov == null)
            {
                vistaprov = new frmProveedor();
                vistaprov.Disposed += new EventHandler(cierravistaprov);
                vistaprov.MdiParent = this;
                vistaprov.Show();            
            }
        }
        private void cierravistaprov(object sender, EventArgs e)
        {
            vistaprov = null;
        }

    }
}

