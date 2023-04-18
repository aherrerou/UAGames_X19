using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace Libreria
{
    class CADProductora
    {
        private String datos;
        private SqlConnection con;
        public CADProductora()
        {
            datos = ConfigurationManager.ConnectionStrings["Database"].ToString();
            con = null;
        }
        public bool readProductora(ENProductora en)
        {
            bool leida = false;
            try
            {
                con = new SqlConnection(datos);
                con.Open();

            }
            return leida;
        }
        public bool readFirstProductora(ENProductora en)
        {

        }
        public bool readNextProductora(ENProductora en)
        {

        }
        public bool readPrevProductora(ENProductora en)
        {

        }
        public bool updateProductora(ENProductora en)
        {
            
        }
        public bool deleteProductora(ENProductora en)
        {

        }

    }
}
