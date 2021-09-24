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
    public partial class Cursos : Form
    {
        SqlConnection con;
        public Cursos(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                String sql = "SELECT * FROM Course";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dvgLista.DataSource = dt;
                dvgLista.Refresh();
            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                String FirstName = txtCurso.Text;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "BuscarCurso";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@NameCourse";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Value = FirstName;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dvgLista.DataSource = dt;
                dvgLista.Refresh();
            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
        }
    }
}
