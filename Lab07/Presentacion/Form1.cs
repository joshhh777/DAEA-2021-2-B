using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            ClsNegPerson np = new ClsNegPerson();
            dt = np.GetAll();

            dgvDatos.DataSource = dt;
            dgvDatos.Refresh();
        }

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            String firstname = txtFirstName.Text;
            DataTable dt = new DataTable();
            ClsNegPerson np = new ClsNegPerson();
            dt = np.Buscar(firstname);

            dgvDatos.DataSource = dt;
            dgvDatos.Refresh();
        }
    }
}
