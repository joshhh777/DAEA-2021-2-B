using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab03
{
    public partial class dbCon : Form
    {
        SqlConnection con;
        public dbCon()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            String servidor = txtServidor.Text;
            String bd = txtBDatos.Text;
            String usuario = txtUsuario.Text;
            String password = txtContraseña.Text;

            String str = "Server=" + servidor + ";DataBase=" + bd + ";";
            if (chkAutenticacion.Checked)
            {
                str += "Integrated Security=true";
            }
            else
            {
                str += "User Id=" + usuario + ";Password="+ password +";";
            }
            try
            {
                con = new SqlConnection(str);
                con.Open();
                MessageBox.Show("Conectado Satisfactoriamente");
                btnDesconectar.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al conectar con el servidor: \n" + ex.ToString());
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if(con.State == ConnectionState.Open)
                {
                    MessageBox.Show("Estado del Servidor: "+ con.State + 
                        "\nVersion del Servidor: "+ con.ServerVersion +
                        "\nBase de Datos: "+ con.Database);
                }
                else
                {
                    MessageBox.Show("Estado del Servidor: "+ con.State);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Imposible determinar el estado del Servidor: \n" + ex.ToString());
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                    MessageBox.Show("Conexión cerrada satisfactoriamente");
                    btnDesconectar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("La conexión ya se encuentra cerrada");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cerrar la conexión: \n" + ex.ToString());
            }
        }

        private void chkAutenticacion_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAutenticacion.Checked)
            {
                txtUsuario.Enabled = false;
                txtContraseña.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtContraseña.Enabled = true;
            }
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona(con);
            persona.Show();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos curso = new Cursos(con);
            curso.Show();
        }
    }
}
