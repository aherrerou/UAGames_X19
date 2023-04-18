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

        public bool createCesta(ENCesta ces, ENVidejuego videojuego, ENUsuario usuario) {

            try
            {
                this.conect.Open();
                string date = ces.Fecha.ToString("yyyy-MM-dd HH:mm:ss");
                string query = "Insert into Cesta (usuarioID,VideojuegoID,fecha) values" + "(" + usuario.id + "," + videojuego.id + "(convert(datetime, '" + date + "', 120);";
                SqlCommand com = new SqlCommand(query, conect);
                com.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                
                Console.WriteLine("User operation has failed. Error: {0}", sqlex.Message);
                return false;
                
            }

            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                return false;
            }
            
            finally
            {
                this.conect.Close();
            }

            return true;
        }



    }
}
