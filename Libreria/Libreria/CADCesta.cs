using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class CADCesta
    {
        private SqlConnection conect;
        private string conexionBBDD;
        

        public CADCesta()
        {
            conexionBBDD = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;";
            conect = new SqlConnection(conexionBBDD);
        }

        public bool createCesta(ENCesta ces) {

            bool res = true;

        

            }



    }
}
