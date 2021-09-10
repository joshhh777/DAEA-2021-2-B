using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string[] usuarios = {"Cancino", "jose", "carlos"};
            string[] password = {"hola","como","estas"};

            if (usuarios.Contains(txtUsuario.Text) && password.Contains(txtContaseña.Text) && 
                Array.IndexOf(usuarios, txtUsuario.Text) == Array.IndexOf(password, txtContaseña.Text))
            {
                PrincipalMDI principal = new PrincipalMDI();
                principal.Show();
                this.Hide();
                txtContaseña.Text = "";
                txtUsuario.Text = "";
            }
            else
            {
                txtUsuario.Clear();
                txtUsuario.Text = "";
                txtContaseña.Text = "";
            }
        }
    }
}
