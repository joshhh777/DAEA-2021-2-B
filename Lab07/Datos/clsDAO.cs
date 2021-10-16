using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class clsDAO
    {
        public SqlConnection con;
        public clsDAO()
        {
            string str = "Server=LAPTOP-4M108N9M\\SQLEXPRESS;DataBase=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }

    }
}
