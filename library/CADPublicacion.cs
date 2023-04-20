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
    class CADPublicacion
    {
        private string conexionBBDD;
        private SqlConnection c;

        public CADPublicacion()
        {
            conexionBBDD = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;";
            c = null;
        }

        public bool createPublicacion(ENPublicacion publicacion)
        {
            string query = "Insert into Publicacion (text, temaID, usuarioID) values "
                + "('" + publicacion.text + "','" + publicacion.temaID + "','" + publicacion.usuarioID + "')";
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                com.ExecuteNonQuery();
                c.Close();
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
                if (c != null)
                    c.Close();
            }
            return true;
        }
        public bool readPublicacion(ENPublicacion publicacion) //selecciona una publicacion por su id de usuario
        {
            bool sigue_while = true;
            string query = "Select * from Publicacion where usuarioID = " + publicacion.usuarioID;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["usuarioID"] == publicacion.usuarioID)
                    {
                        sigue_while = false;
                        publicacion.text = dr["text"].ToString();
                        publicacion.temaID = (int)dr["temaID"];
                        publicacion.usuarioID = (int)dr["usuarioID"];
                    }
                }
                if (sigue_while == true)
                {
                    throw new Exception("No se ha encontrado la publicación con la ID de usuario indicada");
                }
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
                if (c != null)
                    c.Close();
            }
            return true;
        }
        public bool readFirstPublicacion(ENPublicacion publicacion) //recoge todas las publicaciones y devuelve la primera
        {
            string query = "Select * from Publicacion";
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                publicacion.text = dr["text"].ToString();
                publicacion.temaID = (int)dr["temaID"];
                publicacion.usuarioID = (int)dr["usuarioID"];
                dr.Close();
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
                if (c != null)
                    c.Close();
            }
            return true;
        }

        public bool readNextPublicacion(ENPublicacion publicacion) //recoge todas las publicaciones y devuelve la siguiente
        {
            bool sigue_while = true;
            string query = "Select * from Publicacion";
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["usuarioID"] == publicacion.usuarioID)
                    {
                        sigue_while = false;
                        bool siguiente = dr.Read(); //pasa al siguiente campo
                        if (siguiente == true)
                        {
                            publicacion.text = dr["text"].ToString();
                            publicacion.temaID = (int)dr["temaID"];
                            publicacion.usuarioID = (int)dr["usuarioID"];
                        }
                        else
                            throw new Exception("No hay siguiente publicación");
                    }
                }
                dr.Close();
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
                if (c != null)
                    c.Close();
            }
            return true;
        }

        public bool readPrevPublicacion(ENPublicacion publicacion) //recoge todas las publicaciones y devuelve la anterior
        {
            bool sigue_while = true;
            string query = "Select * from Publicacion";

            string text = "blank";
            int tid = 0, uid = 0;

            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["usuarioID"] == publicacion.usuarioID)
                    {
                        if (text == "blank")
                            throw new Exception("No se ha encontrado una publicación anterior");
                        sigue_while = false;
                        publicacion.text = text;
                        publicacion.temaID = tid;
                        publicacion.usuarioID = uid;
                    }
                    else
                    {
                        text = dr["text"].ToString();
                        tid = (int)dr["temaID"];
                        uid = (int)dr["usuarioID"];
                    }
                }
                dr.Close();
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
                if (c != null)
                    c.Close();
            }
            return true;
        }

        public bool updatePublicacion(ENPublicacion publicacion) //actualiza los datos de una publicación según su id de usuario
        {
            string query_comprueba = "Select * from Publicacion";
            string query = "Update Publicacion set text = '" + publicacion.text + "' where usuarioID = " + publicacion.usuarioID;
            bool sigue_while = true;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand comprueba = new SqlCommand(query_comprueba, c);
                SqlDataReader dr = comprueba.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["usuarioID"] == publicacion.usuarioID)
                    {
                        sigue_while = false;
                    }
                }
                if (sigue_while == true)
                    throw new Exception("No se ha encontrado una publicación con la id de usuario indicada");
                dr.Close();
                SqlCommand com = new SqlCommand(query, c);
                com.ExecuteNonQuery();
                dr.Close();
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
                if (c != null)
                    c.Close();
            }
            return true;
        }

        public bool deletePublicacion(ENPublicacion publicacion) //elimina la publicación con la id de usuario indicada
        {
            string query_comprueba = "Select * from Publicacion";
            string query = "Delete from Publicacion where usuarioID = " + publicacion.usuarioID;
            bool sigue_while = true;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand comprueba = new SqlCommand(query_comprueba, c);
                SqlDataReader dr = comprueba.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["usuarioID"] == publicacion.usuarioID)
                    {
                        sigue_while = false;
                    }
                }
                if (sigue_while == true)
                    throw new Exception("No se ha encontrado una publicación con la id de usuario indicada");
                dr.Close();
                SqlCommand com = new SqlCommand(query, c);
                com.ExecuteNonQuery();
                dr.Close();
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
                if (c != null)
                    c.Close();
            }
            return true;
        }
    }
}
