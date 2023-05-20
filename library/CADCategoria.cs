﻿using System;
using System.Collections.Generic;
using System.Configuration;
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
            conexionBBDD = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
            conect = null;
        }

        public bool createCategoria(ENCategoria categoria)
        {

            bool crear = false;
            string query = "INSERT INTO [Categoria]" + "(nombre,descripcion)" + "VALUES (@nombre, @descripcion);";
            try
            {
                conect = new SqlConnection(conexionBBDD);
                conect.Open();
                SqlCommand com = new SqlCommand(query, conect);

                com.Parameters.AddWithValue("@nombre", categoria.nombre);
                com.Parameters.AddWithValue("@descripcion", categoria.descripcion);

                com.ExecuteNonQuery();
                crear = true;
                
            }
            catch (SqlException sqlex)
            {

                Console.WriteLine("User operation has failed. Error: {0}", sqlex.Message);
                crear = false;

            }

            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                crear = false;
            }

            finally
            {
                if (conect != null)
                {
                    conect.Close();
                }
            }

            return crear;
        }

        public bool readCategoria(ENCategoria categoria)
        {
            string query = "select * from Categoria where id = " + categoria.id + ";";
            bool controlador = true;
            try
            {
                conect = new SqlConnection(conexionBBDD);
                conect.Open();
                SqlCommand com = new SqlCommand(query, conect);
                SqlDataReader dataread = com.ExecuteReader();

                while (dataread.Read() && controlador == true)
                {
                    if ((int)dataread["id"] == categoria.id)
                    {
                        controlador = false;
                        categoria.nombre = dataread["nombre"].ToString();
                        categoria.descripcion = dataread["descripcion"].ToString();
                    }
                }

                if (controlador == true)
                {
                    throw new Exception("No se ha encontrado un foro con la id indicada");
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
                if (conect != null)
                {
                    conect.Close();
                }
            }

            return true;
        }

        public bool updateCategoria(ENCategoria categoria)
        {
            try
            {
                this.conect.Open();
                string query = "update Categoria set nombre = " + categoria.id + ", descripcion = '"+ categoria.descripcion  + "'where id = '" + categoria.id + "';";
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
                string query = "delete from Categoria where id = " + categoria.id + ";";
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

        /*public DataSet listas()
        {
            DataSet bdvirtual = new DataSet();

            SqlConnection c = new SqlConnection(conexionBBDD);
            SqlDataAdapter Database = new SqlDataAdapter("select * from Categoria", c);
            database.Fill(bdvirtual, "Categoria");
            return bdvirtual;
        }*/
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

        public bool readCategoriaNombre(ENCategoria en)
        {

            bool leida = false;
            SqlConnection connection = null;
            SqlDataReader dr = null;
            try
            {
                connection = new SqlConnection(conexionBBDD);
                connection.Open();
                string sentence = "SELECT * FROM [Categoria] WHERE nombre = @nombre";
                SqlCommand com = new SqlCommand(sentence, connection);
                com.Parameters.AddWithValue("@nombre", en.nombre);
                //Se obtiene cursor
                dr = com.ExecuteReader();

                //Se lee primer elemento
                if (dr.Read())
                {
                    en.id = Int32.Parse(dr["id"].ToString());
                    en.descripcion = dr["descripcion"].ToString();  
                    leida = true;
                }

            }
            catch (SqlException sqlex)
            {
                leida = false;
                Console.WriteLine("Reading categoria operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leida = false;
                Console.WriteLine("Reading categoria operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leida;
        }
    }
}
