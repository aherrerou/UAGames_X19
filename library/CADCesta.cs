using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class CADCesta
    {
        private string conexionBBDD;
        

        public CADCesta()
        {
            conexionBBDD = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        public bool addVideojuego(ENCesta ces,int videojuegoID)
        {
            bool añadir = false;
            SqlConnection connection = null;

            try
            {
                CADVideojuego videojuego = new CADVideojuego();
                videojuego.readVideojuego(ces.videojuegoID);

                CADUsuario usuario = new CADUsuario();
                usuario.readUsuario(ces.usuarioID);


                String sentence = "INSERT INTO [CestaCompra] (usuarioID,videojuegoID,fecha) " +
                    "VALUES (" + ces.usuarioID.id + ", " + videojuegoID + ", '" + ces.fecha.ToString("yyyy/MM/dd") + " ');";

                connection = new SqlConnection(conexionBBDD);
                connection.Open();

                SqlCommand com = new SqlCommand(sentence, connection);
                com.ExecuteNonQuery();
                añadir = true;
            }
            catch (SqlException e)
            {
                añadir = false;
                Console.WriteLine("Creating videogame operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                añadir = false;
                Console.WriteLine("Creating videogame operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return añadir;

        }

        public bool createCesta(ENCesta ces, ENVideojuego videojuego, ENUsuario usuario) 
        {
            bool crear = false;
            SqlConnection conect = null;
            string query = "INSERT INTO [Cesta]" + "(usuarioID,videojuegoID,fecha)" + "VALUES (@usuarioID, @videojuegoID,@fecha);";

            try
            {
                conect = new SqlConnection(conexionBBDD);
                conect.Open();
                SqlCommand com = new SqlCommand(query, conect);

                com.Parameters.AddWithValue("@usuarioID", ces.usuarioID.id);
                com.Parameters.AddWithValue("@videojuegoID", ces.videojuegoID.Id);
                com.Parameters.AddWithValue("@fecha", ces.fecha);

                com.ExecuteNonQuery();
                crear = true;
            }
            catch (SqlException sqlex)
            {
                
                Console.WriteLine("User operation has failed. Error: {0}", sqlex.Message);
                crear = false;

            }

            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                crear = false;
            }
            
            finally
            {
                if (conect != null)
                {
                    conect.Close();
                }
            }

            return crear;
        }

        public bool readCesta(ENCesta ces)
        {
            bool controlador = false;
            SqlConnection conect = null;
            string query = "SELECT * FROM [Cesta] WHERE usuarioID = @usuarioID";

            SqlDataReader dr = null;

            try
            {
                conect = new SqlConnection(conexionBBDD);
                conect.Open();

                SqlCommand com = new SqlCommand(query, conect);
                com.Parameters.AddWithValue("@usuarioID", ces.usuarioID);

                dr = com.ExecuteReader();

                if (dr.Read())
                {
                    ENUsuario usu = new ENUsuario();
                    usu.id = Int32.Parse(dr["usuarioID"].ToString());

                    ENVideojuego vid = new ENVideojuego();
                    vid.Id = Int32.Parse(dr["viedeojuegoID"].ToString());

                    ces.fecha = DateTime.Parse(dr["fecha"].ToString());

                    controlador = true;
                }             
            }

            catch (SqlException sqlex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", sqlex.Message);
                controlador = false;
            }

            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                controlador = false;
            }

            finally
            {
                if (dr != null) dr.Close();
                if (conect != null) conect.Close();
            }

            return controlador;
        }

        public DataTable readCestas(ENCesta cesta)
        {   
            SqlConnection conect = null;
            DataTable cestas = new DataTable();

            try
            {
                conect = new SqlConnection(conexionBBDD);
                conect.Open();

                ENUsuario usuaurio = new ENUsuario();


                string query = "SELECT c.usuarioID, c.videojuegoID, v.titulo, c.fecha, v.precio FROM Usuario u " +
               "INNER JOIN CestaCompra c ON u.id = c.usuarioID " +
               "INNER JOIN Videojuego v ON c.videojuegoID = v.id " +
               "WHERE u.id ='" + cesta.usuarioID.id + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conect);
                adapter.Fill(cestas);
            }
            catch (SqlException sqlex)
            {

                Console.WriteLine("Reading ofertas operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Reading ofertas operation has failed.Error: {0}", ex.Message);
            }
            finally
            {

                if (conect != null) conect.Close(); // Se asegura de cerrar la conexión.
            }
            return cestas;
        }

        public bool updateCesta(ENCesta ces, ENUsuario usuario, ENVideojuego videojuego)
        {
            SqlConnection conect = null;

            try
            {
                conect.Open();
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
                conect.Close();
            }

            return true;
        }

        public bool deleteCesta(ENCesta ces)
        {
            bool controlador = false;
            SqlConnection conect = null;
            string query = "DELETE FROM CestaCompra WHERE usuarioID = @usuarioID AND videojuegoID = @videojuegoID";

            try
            {
                conect = new SqlConnection(conexionBBDD);
                conect.Open();
                SqlCommand com = new SqlCommand(query, conect);
                com.Parameters.AddWithValue("@usuarioID", ces.usuarioID.id);
                com.Parameters.AddWithValue("@videojuegoID", ces.videojuegoID.Id);
                com.ExecuteReader();
                controlador = true;

            }

            catch (SqlException sqlex)
            {
                controlador = false;
                Console.WriteLine("User operation has failed. Error: {0}", sqlex.Message);

            }

            catch (Exception ex)
            {
                controlador = false;
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }

            finally
            {
                conect.Close();
            }

            return controlador;
        }
    }
}
