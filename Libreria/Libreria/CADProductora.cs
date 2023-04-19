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
                string query = "Select * From Productora Where Id='" + en.Id + "' ";
                SqlCommand consulta = new SqlCommand(query, con);
                SqlDataReader search = consulta.ExecuteReader();


                if (search.Read())
                {
                    en.Id = (int)search["Id"];
                    en.Nombre = (string)search["Nombre"];
                    en.Descripcion = (string)search["Descripcion"];
                    en.Imagen = (string)search["Imagen"];
                    en.Web = (string)search["Web"];
                    leida = true;
                }
                search.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la productora en la base de datos: " + ex.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }

            return leida;
        }


        public void createProductora(ENProductora en)
        {
            try
            {
                con = new SqlConnection(datos);
                con.Open();
                string query = "INSERT INTO Productora (Nombre, Descripcion, Imagen, Web) VALUES (@Nombre, @Descripcion, @Imagen, @Web)";
                SqlCommand consulta = new SqlCommand(query, con);
                consulta.Parameters.AddWithValue("@Nombre", en.Nombre);
                consulta.Parameters.AddWithValue("@Descripcion", en.Descripcion);
                consulta.Parameters.AddWithValue("@Imagen", en.Imagen);
                consulta.Parameters.AddWithValue("@Web", en.Web);
                consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la productora en la base de datos: " + ex.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }

        public bool readFirstProductora(ENProductora en)
        {
            try
            {
                con = new SqlConnection(datos);
                con.Open();
                string query = "SELECT TOP 1 * FROM Productora ORDER BY Id ASC";
                SqlCommand consulta = new SqlCommand(query, con);
                SqlDataReader search = consulta.ExecuteReader();
                if (search.Read())
                {
                    en.Id = int.Parse(search["Id"].ToString());
                    en.Nombre = search["Nombre"].ToString();
                    en.Descripcion = search["Descripcion"].ToString();
                    en.Imagen = search["Imagen"].ToString();
                    en.Web = search["Web"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la primera productora de la base de datos: " + ex.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }


        public bool readNextProductora(ENProductora en)
        {
            try
            {
                con = new SqlConnection(datos);
                con.Open();
                string query = "SELECT TOP 1 * FROM Productora WHERE Id > @Id ORDER BY Id ASC";
                SqlCommand consulta = new SqlCommand(query, con);
                consulta.Parameters.AddWithValue("@Id", en.Id);
                SqlDataReader search = consulta.ExecuteReader();
                if (search.Read())
                {
                    en.Id = int.Parse(search["Id"].ToString());
                    en.Nombre = search["Nombre"].ToString();
                    en.Descripcion = search["Descripcion"].ToString();
                    en.Imagen = search["Imagen"].ToString();
                    en.Web = search["Web"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la productora siguiente de la base de datos: " + ex.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }


        public bool readPrevProductora(ENProductora en)
        {
            try
            {
                con = new SqlConnection(datos);
                con.Open();
                string query = "SELECT TOP 1 * FROM Productora WHERE Id < @Id ORDER BY Id DESC";
                SqlCommand consulta = new SqlCommand(query, con);
                consulta.Parameters.AddWithValue("@Id", en.Id);
                SqlDataReader search = consulta.ExecuteReader();
                if (search.Read())
                {
                    en.Id = int.Parse(search["Id"].ToString());
                    en.Nombre = search["Nombre"].ToString();
                    en.Descripcion = search["Descripcion"].ToString();
                    en.Imagen = search["Imagen"].ToString();
                    en.Web = search["Web"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la productora previa de la base de datos: " + ex.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }



        public bool updateProductora(ENProductora en)
        {
            bool updated = false;
            try
            {
                con = new SqlConnection(datos);
                con.Open();
                string query = "UPDATE Productora SET Nombre=@Nombre, Descripcion=@Descripcion, Imagen=@Imagen, Web=@Web WHERE Id=@Id";
                SqlCommand consulta = new SqlCommand(query, con);
                consulta.Parameters.AddWithValue("@Nombre", en.Nombre);
                consulta.Parameters.AddWithValue("@Descripcion", en.Descripcion);
                consulta.Parameters.AddWithValue("@Imagen", en.Imagen);
                consulta.Parameters.AddWithValue("@Web", en.Web);
                consulta.Parameters.AddWithValue("@Id", en.Id);
                consulta.ExecuteNonQuery();
                updated = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la productora en la base de datos: " + ex.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();

            }
            return updated;




        }
        public bool deleteProductora(ENProductora en)
        {
            bool del = false;
            try
            {
                con = new SqlConnection(datos);
                con.Open();
                string query = "DELETE FROM Productora WHERE Id=@Id";
                SqlCommand consulta = new SqlCommand(query, con);
                consulta.Parameters.AddWithValue("@Id", en.Id);
                consulta.ExecuteNonQuery();
                del = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la productora de la base de datos: " + ex.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return del;
        }


    }
}
