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
    public class CADUsuario
    {
        private string conexionBBDD;
        private SqlConnection c;

        public CADUsuario()
        {
            conexionBBDD = ConfigurationManager.ConnectionStrings["UAGames"].ToString();
            c = null;
        }

        public bool createUsuario(ENUsuario usuario)
        {
            string fechaFormatoCorrecto = usuario.fecha_nac.ToString("yyyy-MM-dd");
            string query = "Insert into Usuario (nick, nombre, apellidos, email, password, fecha_nacimiento, telefono, rol) values " +
                "('" + usuario.nick + "','" + usuario.nombre + "','" + usuario.apellidos + "','" + usuario.email + "','" + usuario.password 
                + "','" + fechaFormatoCorrecto + "','" + usuario.telef + "','" + usuario.rol + "')";
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
        public bool readUsuario(ENUsuario usuario) //busca un usuario por su nick, que es único
        {
            bool sigue_while = true;
            string query = "Select * from Usuario where nick = " + usuario.nick;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if (dr["nick"].ToString() == usuario.nick)
                    {
                        sigue_while = false;
                        usuario.nombre = dr["nombre"].ToString();
                        usuario.apellidos = dr["apellidos"].ToString();
                        usuario.email = dr["email"].ToString();
                        usuario.password = dr["password"].ToString();
                        usuario.fecha_nac = (DateTime)dr["fecha_nacimiento"];
                        usuario.telef = dr["telefono"].ToString();
                        usuario.rol = dr["rol"].ToString();
                    }
                }
                if (sigue_while == true)
                {
                    throw new Exception("No se ha encontrado el usuario");
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
        public bool readFirstUsuario(ENUsuario usuario) //recoge todos los usuarios y devuelve el primero
        {
            string query = "Select * from Usuario";
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                usuario.nick = dr["nick"].ToString();
                usuario.nombre = dr["nombre"].ToString();
                usuario.apellidos = dr["apellidos"].ToString();
                usuario.email = dr["email"].ToString();
                usuario.password = dr["password"].ToString();
                usuario.fecha_nac = (DateTime)dr["fecha_nacimiento"];
                usuario.telef = dr["telefono"].ToString();
                usuario.rol = dr["rol"].ToString();
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

        public bool readNextUsuario(ENUsuario usuario) //recoge todos los usuarios y devuelve el siguiente
        {
            bool sigue_while = true;
            string query = "Select * from Usuario";
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if (dr["nick"].ToString() == usuario.nick)
                    {
                        sigue_while = false;
                        bool siguiente = dr.Read(); //pasa al siguiente campo
                        if (siguiente == true)
                        {
                            usuario.nick = dr["nick"].ToString();
                            usuario.nombre = dr["nombre"].ToString();
                            usuario.apellidos = dr["apellidos"].ToString();
                            usuario.email = dr["email"].ToString();
                            usuario.password = dr["password"].ToString();
                            usuario.fecha_nac = (DateTime)dr["fecha_nacimiento"];
                            usuario.telef = dr["telefono"].ToString();
                            usuario.rol = dr["rol"].ToString();
                        }
                        else
                            throw new Exception("No hay siguiente usuario");
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

        public bool readPrevUsuario(ENUsuario usuario) //recoge todos los usuarios y devuelve el anterior
        {
            bool sigue_while = true;
            string query = "Select * from Usuario";

            string nick = "blank";
            string nom = "blank";
            string apellidos = "blank";
            string email = "blank";
            string password = "blank";
            DateTime fecha_nac = DateTime.Now;
            string telef = "blank";
            string rol = "blank";

            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if (dr["nick"].ToString() == usuario.nick)
                    {
                        if (nick == "blank")
                            throw new Exception("No se ha encontrado un usuario anterior");
                        sigue_while = false;
                        usuario.nick = nick;
                        usuario.nombre = nom;
                        usuario.apellidos = apellidos;
                        usuario.email = email;
                        usuario.password = password;
                        usuario.fecha_nac =fecha_nac;
                        usuario.telef = telef;
                        usuario.rol = rol;
                    }
                    else
                    {
                        nick = dr["nick"].ToString();
                        nom = dr["nombre"].ToString();
                        apellidos = dr["apellidos"].ToString();
                        email = dr["email"].ToString();
                        password = dr["password"].ToString();
                        fecha_nac = (DateTime)dr["fecha_nacimiento"];
                        telef = dr["telefono"].ToString();
                        rol = dr["rol"].ToString();
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

        public bool updateUsuario(ENUsuario usuario) //actualiza los datos de un usuario según su email, ya que el nick puede cambiar
        {
            string fechaFormatoCorrecto = usuario.fecha_nac.ToString("yyyy-MM-dd");
            string query_comprueba = "Select * from Usuario";
            string query = "Update Usuario set nick = '" + usuario.nick + "', nombre = '" + usuario.nombre + "', apellidos = '" + usuario.apellidos + "', password = '" + usuario.password
                 + "', fecha_nacimiento = '" + fechaFormatoCorrecto + "', telefono = '" + usuario.telef + "', rol = '" + usuario.rol + "' where email = '" + usuario.email + "'";
            bool sigue_while = true;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand comprueba = new SqlCommand(query_comprueba, c);
                SqlDataReader dr = comprueba.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if (dr["email"].ToString() == usuario.email)
                    {
                        sigue_while = false;
                    }
                }
                if (sigue_while == true)
                    throw new Exception("No se ha encontrado un usuario con el mismo email");
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

        public bool deleteUsuario(ENUsuario usuario) //elimina el usuario con el nick indicado
        {
            string query_comprueba = "Select * from Usuario";
            string query = "Delete from Usuario where nick = " + usuario.nick;
            bool sigue_while = true;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand comprueba = new SqlCommand(query_comprueba, c);
                SqlDataReader dr = comprueba.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if (dr["nick"].ToString() == usuario.nick)
                    {
                        sigue_while = false;
                    }
                }
                if (sigue_while == true)
                    throw new Exception("No se ha encontrado un usuario con el mismo nick");
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
