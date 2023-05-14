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

        public DataTable readReview(ENReview review)
        {
            DataTable dataTable = new DataTable();
            try
            {
                c.Open();
                string query = "SELECT * FROM REVIEW r where r.id = " + review.id + ";";
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader reader = com.ExecuteReader();

                dataTable.Load(reader);

                reader.Close();
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


        public DataTable listarReviews(ENUsuario user)
        {
            DataTable dataTable = new DataTable();
            try
            {
                c.Open();
                string query = "SELECT * FROM REVIEW r where r.usuarioID = " + 1 + ";";
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader reader = com.ExecuteReader();

                dataTable.Load(reader);

                reader.Close();
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
