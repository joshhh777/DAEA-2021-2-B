using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLab01_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text;
            string apellido = txtApellido.Text;
            string nombre = txtNombre.Text;
            string codigo = lblCodigo.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;
            string fecha = dtpFechaNac.Text;
            string departamento = cmbDepartamento.Text;
            string cargo = cmbCargo.Text;

            dgvDatos.Rows.Add(codigo, dni, nombre, apellido, direccion, telefono, email, fecha, departamento, cargo);
        }
    }
}
