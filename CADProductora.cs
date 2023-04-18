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
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Web { get; set; }
        public string constring;
        public CADProductora()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }
            }
}
