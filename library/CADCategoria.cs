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
        
        private string conexionBBDD;


        public CADCategoria()
        {
            conexionBBDD = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
            
        }

        public bool createCategoria(ENCategoria categoria)
        {

            bool crear = false;
            SqlConnection conect = null;
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
            SqlConnection conect = null;
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

        public DataTable readCategorias()
        {
            SqlConnection conect = null;
            DataTable categorias = new DataTable();

            try
            {
                conect = new SqlConnection(conexionBBDD);
                conect.Open();

                string sentence = "SELECT * from Categoria;";
                SqlDataAdapter adapter = new SqlDataAdapter(sentence, conect);
                adapter.Fill(categorias);


            }
            catch (SqlException sqlex)
            {

                Console.WriteLine("Reading ofertas operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Reading ofertas operation has failed.Error: {0}", ex.Message);
            }
            finally
            {

                if (conect != null) conect.Close(); // Se asegura de cerrar la conexión.
            }
            return categorias;
        }

        public bool updateCategoria(ENCategoria categoria)
        {

            SqlConnection conect = null;

            try
            {
                
                conect.Open();
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
                conect.Close();
            }

            return true;
        }

        public bool deleteCategoria(ENCategoria categoria)
        {
            bool controlador = false;
            SqlConnection conect = null;
            string query = "delete from Categoria where id = @id;";

            try
            {
                conect = new SqlConnection(conexionBBDD);
                conect.Open();
                

                
                SqlCommand com = new SqlCommand(query, conect);
                com.Parameters.AddWithValue("@id", categoria.id);
                com.ExecuteReader();

                controlador = true;
            }

            catch (SqlException sqlex)
            {
                controlador = false;
                Console.WriteLine("User operation has failed. Error: {0}", sqlex.Message);
                
            }

            catch (Exception ex)
            {
                controlador = false;
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                
            }

            finally
            {
                conect.Close();
            }

            return controlador ;
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
    }
}
