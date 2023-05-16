using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data;

namespace library
{
    public class CADReview
    {
        private string conexionBBDD;
        private SqlConnection c;

        public CADReview()
        {
            conexionBBDD = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
            c = new SqlConnection(conexionBBDD);
        }

        public bool createReview(ENReview review)
        {
            bool result = true;
            try
            {
                c.Open();
                string query = "INSERT INTO Review (puntuacion, comentario, fecha, usuarioID, videojuegoID) VALUES (@puntuacion, @comentario, @fecha, @usuarioID, @videojuegoID);";
                SqlCommand com = new SqlCommand(query, c);
                com.Parameters.AddWithValue("@puntuacion", review.puntuacion);
                com.Parameters.AddWithValue("@comentario", review.comentario);
                com.Parameters.AddWithValue("@fecha", review.fecha.ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@usuarioID", review.usuario.id);
                com.Parameters.AddWithValue("@videojuegoID", review.videojuego.Id);
                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            finally
            {
                c.Close();
            }
            return result;
        }

        public bool deleteReview(int id)
        {
            bool result = true;
            try
            {
                c.Open();
                string query = "DELETE FROM Review WHERE id = @id;";
                SqlCommand com = new SqlCommand(query, c);
                com.Parameters.AddWithValue("@id", id);
                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            finally
            {
                c.Close();
            }
            return result;
        }

        public bool updateReview(ENReview review)
        {
            bool result = true;
            try
            {
                c.Open();
                string query = "UPDATE Review SET puntuacion = @puntuacion, comentario = @comentario, fecha = @fecha WHERE id = @id;";
                SqlCommand com = new SqlCommand(query, c);
                com.Parameters.AddWithValue("@puntuacion", review.puntuacion);
                com.Parameters.AddWithValue("@comentario", review.comentario);
                com.Parameters.AddWithValue("@fecha", review.fecha.ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@id", review.id);
                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            finally
            {
                c.Close();
            }
            return result;
        }

        public bool readReview(ENReview review)
        {
            bool leido = false;
            SqlConnection connection = null;
            SqlConnection conProductora = null;
            SqlConnection conCategoria = null;
            SqlDataReader dr = null;
            try
            {
                connection.Open();
                conProductora.Open();
                conCategoria.Open();
                string sentence = "SELECT * FROM Review WHERE id = @id";
                SqlCommand com = new SqlCommand(sentence, connection);
                com.Parameters.AddWithValue("@id", review.id);
                //Se obtiene cursor
                dr = com.ExecuteReader();

                //Se lee primer elemento
                if (dr.Read())
                {
                    review.id = Convert.ToInt32(dr["id"].ToString());
                    review.fecha = DateTime.Parse(dr["fecha_lanzamiento"].ToString());
                    review.comentario = dr["comentario"].ToString();
                    review.puntuacion = Convert.ToInt32(dr["puntuacion"].ToString());

                    //Lectura del videojuego
                    ENVideojuego v= new ENVideojuego();
                    v.Id = Int32.Parse(dr["videojuegoID"].ToString());

                    v.readVideojuego();

                    //Lectura del usuario
                    ENUsuario u = new ENUsuario();
                    u.readUsuario();

                    leido = true;
                }

            }
            catch (SqlException sqlex)
            {
                leido = false;
                Console.WriteLine("Reading videojuego operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leido = false;
                Console.WriteLine("Reading videojuego operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leido;
        }

        public DataTable listarReviews(ENReview review)
        {
            DataTable dataTable = new DataTable();
            try
            {
                c.Open();
                string query = "SELECT r.* , v.Imagen as imagen , v.Titulo as nombrejuego, u.nombre as nombreUsuario" +
                    " FROM Review r , videojuego v , usuario u " +
                    "where v.Id = r.videojuegoID and r.usuarioID = u.id;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, c);
                adapter.Fill(dataTable);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                c.Close();
            }
            return dataTable;
        }
    }
}
