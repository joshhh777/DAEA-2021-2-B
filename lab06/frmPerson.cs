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

namespace Lab06
{
    public partial class frmPerson : Form
    {
        SqlConnection con;
        DataSet ds = new DataSet();
        DataTable tablePerson = new DataTable();
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
            String sql = "SELECT * from Person";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            adapter.Fill(ds, "Person");
            tablePerson = ds.Tables["Person"];
            dgvLista.DataSource = tablePerson;
            dgvLista.Update();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("InsertPerson", con);

            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50, "LastName");
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50, "FirstName");
            cmd.Parameters.Add("@HireDate", SqlDbType.Date).SourceColumn = "HireDate";
            cmd.Parameters.Add("@EnrollmentDate", SqlDbType.Date).SourceColumn = "EnrollmentDate";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = cmd;
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            DataRow fila = tablePerson.NewRow();
            fila["LastName"] = txtLastName.Text;
            fila["FirstName"] = txtFirstName.Text;
            fila["HireDate"] = txtHireDate.Text;
            fila["EnrollmentDate"] = txtEnrollmentDate.Text;

            tablePerson.Rows.Add(fila);
            adapter.Update(tablePerson);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UpdatePerson", con);

            cmd.Parameters.Add("@PersonID", SqlDbType.VarChar).SourceColumn = "PersonID";
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).SourceColumn = "LastName";
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).SourceColumn = "FirstName";
            cmd.Parameters.Add("@HireDate", SqlDbType.Date).SourceColumn = "HireDate";
            cmd.Parameters.Add("@EnrollmentDate", SqlDbType.Date).SourceColumn = "EnrollmentDate";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = cmd;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;

            DataRow[] fila = tablePerson.Select("PersonID= '" + txtPersonID.Text + "'");
            fila[0]["LastName"] = txtLastName.Text;
            fila[0]["FirstName"] = txtFirstName.Text;
            fila[0]["HireDate"] = txtHireDate.Text;
            fila[0]["EnrollmentDate"] = txtEnrollmentDate.Text;

            adapter.Update(tablePerson);
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
                    DataRow[] fila = tablePerson.Select("PersonID= '" + txtPersonID.Text + "'");
                    tablePerson.Rows.Remove(fila[0]);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar: \n" + ex.Errors[0].Number + " - " + ex.Errors[0].ToString());
            }
            con.Close();
        }

        private void btnOrdenarApellido_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.Sort = "LastName ASC";
            dgvLista.DataSource = dv;
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "PersonID = '" + txtPersonID.Text + "'";
            dgvLista.DataSource = dv;
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvLista.SelectedRows.Count > 0)
            {
                txtPersonID.Text = dgvLista.SelectedRows[0].Cells[0].Value.ToString();
                txtFirstName.Text = dgvLista.SelectedRows[0].Cells[2].Value.ToString();
                txtLastName.Text = dgvLista.SelectedRows[0].Cells[1].Value.ToString();

                string hiredate = dgvLista.SelectedRows[0].Cells[3].Value.ToString();
                if (String.IsNullOrEmpty(hiredate))
                    txtHireDate.Checked = false;
                else
                    txtHireDate.Text = hiredate;
                string enrollmentdate = dgvLista.SelectedRows[0].Cells[4].Value.ToString();
                if (String.IsNullOrEmpty(enrollmentdate))
                    txtEnrollmentDate.Checked = false;
                else
                    txtEnrollmentDate.Text = enrollmentdate;
            }
        }

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "FirstName = '" + txtFirstName.Text + "'";
            dgvLista.DataSource = dv;
        }

        private void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(tablePerson);
            dv.RowFilter = "LastName = '" + txtLastName.Text + "'";
            dgvLista.DataSource = dv;
        }
    }
}