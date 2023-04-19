using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class CADNoticia
    {
        private string cadenaConexion;
       
        public CADNoticia()
        {

            cadenaConexion = "Data Source=SERVIDOR;Initial Catalog=BASEDEDATOS;Integrated Security=True";
        }
        public bool createNoticia(ENNoticia noticia)
        {
            bool creada = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Noticias (Titulo, FechaPublicacion, Contenido, ProductoraID) VALUES (@Titulo, @FechaPublicacion, @Contenido, @ProductoraID)";
                comando.Parameters.AddWithValue("@Titulo", noticia.Titulo);
                comando.Parameters.AddWithValue("@FechaPublicacion", noticia.FechaPublicacion);
                comando.Parameters.AddWithValue("@Contenido", noticia.Contenido);
                comando.Parameters.AddWithValue("@ProductoraID", noticia.ProductoraID);
                comando.Connection = conexion;

                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    creada = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la noticia: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return creada;
        }

        public bool readNoticia(ENNoticia noticia)
        {
            bool leida = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT Id, Titulo, FechaPublicacion, Contenido, ProductoraID FROM Noticias WHERE Id = @Id";
                comando.Parameters.AddWithValue("@Id", noticia.Id);
                comando.Connection = conexion;

                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    noticia.Id = Convert.ToInt32(lector["Id"]);
                    noticia.Titulo = lector["Titulo"].ToString();
                    noticia.FechaPublicacion = Convert.ToDateTime(lector["FechaPublicacion"]);
                    noticia.Contenido = lector["Contenido"].ToString();
                    noticia.ProductoraID = Convert.ToInt32(lector["ProductoraID"]);
                    leida = true;
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer la noticia: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return leida;
        }
        public bool readNextNoticia(ENNoticia noticia)
        {
            bool leida = false;

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT TOP 1 Id, Titulo, FechaPublicacion, Contenido, ProductoraID FROM Noticias WHERE FechaPublicacion > @FechaActual ORDER BY FechaPublicacion";
                comando.Parameters.AddWithValue("@FechaActual", noticia.FechaPublicacion);
                comando.Connection = conexion;

                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    noticia.Id = Convert.ToInt32(lector["Id"]);
                    noticia.Titulo = lector["Titulo"].ToString();
                    noticia.FechaPublicacion = Convert.ToDateTime(lector["FechaPublicacion"]);
                    noticia.Contenido = lector["Contenido"].ToString();
                    noticia.ProductoraID = Convert.ToInt32(lector["ProductoraID"]);
                    leida = true;
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer la noticia: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return leida;
        }



        public bool readFirstNoticia(ENNoticia noticia)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            string query = "SELECT TOP 1 * FROM Noticias ORDER BY id ASC";

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    noticia.Id = Convert.ToInt32(reader["id"]);
                    noticia.Titulo = reader["titulo"].ToString();
                    noticia.FechaPublicacion = Convert.ToDateTime(reader["fecha_public"]);
                    noticia.Contenido = reader["contenido"].ToString();
                    noticia.ProductoraID = Convert.ToInt32(reader["productoraID"]);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
        public bool readPrevNoticia(ENNoticia noticia)
        {
            bool leida = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT TOP 1 Id, Titulo, FechaPublicacion, Contenido, ProductoraID FROM Noticias WHERE FechaPublicacion < @FechaPublicacion ORDER BY FechaPublicacion DESC";
                comando.Parameters.AddWithValue("@FechaPublicacion", noticia.FechaPublicacion);
                comando.Connection = conexion;

                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    noticia.Id = Convert.ToInt32(lector["Id"]);
                    noticia.Titulo = lector["Titulo"].ToString();
                    noticia.FechaPublicacion = Convert.ToDateTime(lector["FechaPublicacion"]);
                    noticia.Contenido = lector["Contenido"].ToString();
                    noticia.ProductoraID = Convert.ToInt32(lector["ProductoraID"]);
                    leida = true;
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer la noticia: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return leida;
        }

        public bool updateNoticia(ENNoticia noticia)
        {
            bool actualizada = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Noticias SET Titulo = @Titulo, FechaPublicacion = @FechaPublicacion, Contenido = @Contenido, ProductoraID = @ProductoraID WHERE Id = @Id";
                comando.Parameters.AddWithValue("@Titulo", noticia.Titulo);
                comando.Parameters.AddWithValue("@FechaPublicacion", noticia.FechaPublicacion);
                comando.Parameters.AddWithValue("@Contenido", noticia.Contenido);
                comando.Parameters.AddWithValue("@ProductoraID", noticia.ProductoraID);
                comando.Parameters.AddWithValue("@Id", noticia.Id);
                comando.Connection = conexion;

                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    actualizada = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la noticia: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return actualizada;
        }

        public bool deleteNoticia(ENNoticia noticia)
        {
            bool eliminada = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "DELETE FROM Noticias WHERE Id = @Id";
                comando.Parameters.AddWithValue("@Id", noticia.Id);
                comando.Connection = conexion;

                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    eliminada = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la noticia: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return eliminada;
        }


    }
}
