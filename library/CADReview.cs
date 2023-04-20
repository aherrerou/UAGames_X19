using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace library
{
    class CADReview
    {
        private string conexionBBDD;
        private SqlConnection c;

        public CADReview()
        {
            conexionBBDD = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;";
            c = new SqlConnection(conexionBBDD);
        }

        public bool createReview(ENReview review, ENUsuario usuario , ENVideoJuego videojuego)
        {
            bool result = true;
            try
            {
                this.c.Open();
                string fechaFormatoCorrecto = review.fecha.ToString("yyyy-MM-dd HH:mm:ss");
                string query = "INSERT INTO Review (puntuacion,comentario,fecha,usuarioID,videojuegoID) VALUES (" + review.puntuacion + ", " + review.comentario + ", " + "CONVERT(datetime, '" + fechaFormatoCorrecto + "', 120)," + usuario.id + ", " + videojuego.id  ");";
                SqlCommand com = new SqlCommand(query, c);
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
                this.c.Close();
            }

            return result;
        }

        public bool deleteReview(ENReview review)
        {
            bool result = true;
            try
            {
                c.Open();
                string query = "DELETE FROM Review WHERE id=" + review.id + ";";
                SqlCommand com = new SqlCommand(query, c);
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
                this.c.Close();
            }
            return result;
        }

        public bool updateReview(ENReview review)
        {
            bool result = true;
            try
            {
                c.Open();
                string query = "UPDATE Review SET " +
                    "puntuacion=" + review.puntuacion + ",comentario=" + review.comentario + ",fecha=" + review.fecha + " WHERE id=" + review.id + ";";
                SqlCommand com = new SqlCommand(query, c);
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
                this.c.Close();
            }
            return result;
        }

        public bool readReview(ENReview review)
        {
            bool result = true;
            try
            {
                this.c.Open();
                string query = "SELECT * FROM Review WHERE id = " + review.id + ";";
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    review.totalCompra = Double.Parse(reader["total"].ToString());
                }
                else
                {
                    result = false;
                }
                reader.Close();
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
                this.c.Close();
            }
            return result;
        }
    }
}
