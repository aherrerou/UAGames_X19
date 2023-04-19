using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class CADCategoria
    {
        private SqlConnection conect;
        private string conexionBBDD;


        public CADCategoria()
        {
            conexionBBDD = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;";
            conect = new SqlConnection(conexionBBDD);
        }

        public bool createCategoria(ENCategoria categoria)
        {

            try
            {
                this.conect.Open();
                string query = "Insert into Categoria (id,nombre,descripcion) values " + "('" + categoria.id + "','" + categoria.nombre + "','" + categoria.descripcion + "');";
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

        public bool readCategoria(ENCategoria categoria)
        {
            try
            {
                this.conect.Open();
                string query = "select * from Categoria where id = '" + categoria.id + "';";
                SqlCommand com = new SqlCommand(query, conect);
                SqlDataReader dataread = com.ExecuteReader();

                if (dataread.Read())
                {
                    categoria.id = int.Parse(dataread["id"].ToString());
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

        public bool updateCategoria(ENCategoria categoria)
        {
            try
            {
                this.conect.Open();
                string query = "update Categoria set nombre = '" + categoria.id + "', descripcion = '"+ categoria.descripcion  + "'where id = '" + categoria.id + "';";
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

        public bool deleteCesta(ENCategoria categoria)
        {
            try
            {
                this.conect.Open();
                string query = "delete from Categoria where id = '" + categoria.id + "';";
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
