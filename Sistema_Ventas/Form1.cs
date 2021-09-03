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
    public partial class frmLogin : Form
    {
        public bool res;
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            clsLogin login = new clsLogin();
            
            login.conectar();
            login.USUARIO = txtusuario.Text;
            login.PASSW = txtpassword.Text;
            login.acceso();
            res = login.RESPUESTA;
            if (res == true)
            {
                MessageBox.Show("Bienvenido "+txtusuario.Text);
                Dispose();
                
            }
        }
    }
}
