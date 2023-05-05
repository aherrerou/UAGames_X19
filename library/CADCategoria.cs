﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
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

        public bool deleteCategoria(ENCategoria categoria)
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

        public DataTable readCategoriasNombre()
        {
            SqlConnection connection = null;
            DataTable categorias = new DataTable();

            try
            {
                connection = new SqlConnection(conexionBBDD);
                connection.Open();

                string sentence = "SELECT nombre, id FROM [Categoria];";
                SqlDataAdapter adapter = new SqlDataAdapter(sentence, connection);
                adapter.Fill(categorias);

            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Reading categorias operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reading categorias operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return categorias;
        }
    }
}
