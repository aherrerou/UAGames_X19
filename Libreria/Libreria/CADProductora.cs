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
       
        public CADProductora()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

            }
}
