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
    class CADTema
    {
        private string conexionBBDD;
        private SqlConnection c;

        public CADTema()
        {
            conexionBBDD = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;";
            c = null;
        }

        public bool createTema(ENTema tema)
        {
            string query = "Insert into Tema (titulo, foroID) values " + "('" + tema.titulo + "'," + tema.foro.id + ")";
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
        public bool readTema(ENTema tema) //selecciona un tema indicado por su id de foro
        {
            bool sigue_while = true;
            string query = "Select * from Tema where foroID = " + tema.foro.id;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["foroID"] == tema.foro.id)
                    {
                        sigue_while = false;
                        tema.titulo = dr["titulo"].ToString();
                        tema.foro.id = (int)dr["foroID"];
                    }
                }
                if (sigue_while == true)
                {
                    throw new Exception("No se ha encontrado el tema con la ID de foro indicada");
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
        public bool readFirstTema(ENTema tema) //recoge todos los temas y devuelve el primero
        {
            string query = "Select * from Tema";
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                tema.titulo = dr["titulo"].ToString();
                tema.foro.id = (int)dr["foroID"];
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

        public bool readNextTema(ENTema tema) //recoge todos los temas y devuelve el siguiente
        {
            bool sigue_while = true;
            string query = "Select * from Tema";
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["foroID"] == tema.foro.id)
                    {
                        sigue_while = false;
                        bool siguiente = dr.Read(); //pasa al siguiente campo
                        if (siguiente == true)
                        {
                            tema.titulo = dr["titulo"].ToString();
                            tema.foro.id = (int)dr["foroID"];
                        }
                        else
                            throw new Exception("No hay siguiente tema");
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

        public bool readPrevTema(ENTema tema) //recoge todos los temas y devuelve el anterior
        {
            bool sigue_while = true;
            string query = "Select * from Tema";

            string titulo = "blank";
            int id = 0;

            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["foroID"] == tema.foro.id)
                    {
                        if (titulo == "blank")
                            throw new Exception("No se ha encontrado un tema anterior");
                        sigue_while = false;
                        tema.titulo = titulo;
                        tema.foro.id = id;
                    }
                    else
                    {
                        titulo = dr["titulo"].ToString();
                        id = (int)dr["foroID"];
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

        public bool updateTema(ENTema tema) //actualiza los datos de un tema según su id de foro
        {
            string query_comprueba = "Select * from Tema";
            string query = "Update Tema set titulo = '" + tema.titulo + "' where foroID = " + tema.foro.id;
            bool sigue_while = true;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand comprueba = new SqlCommand(query_comprueba, c);
                SqlDataReader dr = comprueba.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["foroID"] == tema.foro.id)
                    {
                        sigue_while = false;
                    }
                }
                if (sigue_while == true)
                    throw new Exception("No se ha encontrado un tema con la id de foro indicada");
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

        public bool deleteTema(ENTema tema) //elimina el tema con la id de foro indicada
        {
            string query_comprueba = "Select * from Tema";
            string query = "Delete from Tema where foroID = " + tema.foro.id;
            bool sigue_while = true;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand comprueba = new SqlCommand(query_comprueba, c);
                SqlDataReader dr = comprueba.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["foroID"] == tema.foro.id)
                    {
                        sigue_while = false;
                    }
                }
                if (sigue_while == true)
                    throw new Exception("No se ha encontrado un tema con la id de foro indicada");
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
