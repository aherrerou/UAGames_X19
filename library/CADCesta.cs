using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
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

        public bool createCesta(ENCesta ces, ENVideojuego videojuego, ENUsuario usuario) {

            try
            {
                this.conect.Open();
                string date = ces.Fecha.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "Insert into Cesta (usuarioID,VideojuegoID,fecha) values " + "('" + usuario.id + "','" + videojuego.Id + "','" + date + "');";
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

        public bool readCesta(ENCesta ces, ENUsuario usuario)
        {
            try
            {
                this.conect.Open();
                string query = "select * from Cesta where usuarioID = '" + usuario.id + "';";
                SqlCommand com = new SqlCommand(query, conect);
                SqlDataReader dataread = com.ExecuteReader();

                if (dataread.Read())
                {
                    usuario.id = int.Parse(dataread["usuarioID"].ToString());
                }
                else
                {
                    return false;
                }
                dataread.Close();

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

        public bool updateCesta(ENCesta ces, ENUsuario usuario, ENVideojuego videojuego)
        {
            try
            {
                this.conect.Open();
                string query = "update Cesta set" + "videojuegoID = '" + videojuego.Id + "' where usuarioID = '" + usuario.id + "';";
                SqlCommand com = new SqlCommand(query, conect);
                com.ExecuteReader();

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

        public bool deleteCesta(ENCesta ces, ENUsuario usuario)
        {
            try
            {
                this.conect.Open();
                string query = "delete from Cesta where usuarioID = '" + usuario.id + "';";
                SqlCommand com = new SqlCommand(query, conect);
                com.ExecuteReader();

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
