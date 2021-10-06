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

namespace Lab05
{
    public partial class frmPerson : Form
    {
        SqlConnection con;
        public frmPerson()
        {
            InitializeComponent();
        }
        private void frmPerson_Load(object sender, EventArgs e)
        {
            String str = "Server=LAPTOP-4M108N9M\\SQLEXPRESS;DataBase=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = "SELECT * from Person";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dgvLista.DataSource = dt;
            dgvLista.Refresh();
            con.Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "InsertPerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);

            int codigo = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show("Se ha registrado nueva persona con el código: " + codigo);

            con.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "UpdatePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);

            int resultado = cmd.ExecuteNonQuery();
            if (resultado > 0)
            {
                MessageBox.Show("Se ha registrado modificado el registro correctamente");
            }

            con.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "DeletePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);

            try
            {
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    MessageBox.Show("Se ha eliminado el registro correctamente");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar: \n" + ex.Errors[0].Number + " - " + ex.Errors[0].ToString());
            }
            con.Close();
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                String PersonID = txtPersonID.Text;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "BuscarPersonaID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@PersonID";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Value = PersonID;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvLista.DataSource = dt;
                dgvLista.Refresh();
            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
            con.Close();
        }

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                String FirstName = txtFirstName.Text;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "BuscarPersonaNombre";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@FirstName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Value = FirstName;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvLista.DataSource = dt;
                dgvLista.Refresh();
            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
            con.Close();
        }

        private void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                String LastName = txtLastName.Text;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "BuscarPersonaApellido";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@LastName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Value = LastName;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvLista.DataSource = dt;
                dgvLista.Refresh();
            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
            con.Close();
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvLista.SelectedRows.Count > 0)
            {
                txtPersonID.Text = dgvLista.SelectedRows[0].Cells[0].Value.ToString();
                txtLastName.Text = dgvLista.SelectedRows[0].Cells[1].Value.ToString();
                txtFirstName.Text = dgvLista.SelectedRows[0].Cells[2].Value.ToString();
                txtHireDate.Text = dgvLista.SelectedRows[0].Cells[3].Value.ToString();
                txtEnrollmentDate.Text = dgvLista.SelectedRows[0].Cells[4].Value.ToString();
            }
        }
    }
}
