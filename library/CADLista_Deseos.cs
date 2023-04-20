﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace library
{
    class CADLista_Deseos
    {
        private string conexionBBDD;
        private SqlConnection c;

        public CADLista_Deseos()
        {
            conexionBBDD = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;";
            c = null;
        }

        public bool createLista(ENLista_Deseos lista)
        {
            string query = "Insert into ListaDeseos (nombre, descripcion, usuarioID) values " + "('" + lista.nombre + "','" + lista.descripcion + "'," + lista.usuarioID + ")";
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
        public bool readLista(ENLista_Deseos lista) //selecciona la lista de un usuario indicado por su id
        {
            bool sigue_while = true;
            string query = "Select * from ListaDeseos where usuarioID = " + lista.usuarioID;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["usuarioID"] == lista.usuarioID)
                    {
                        sigue_while = false;
                        lista.nombre = dr["nombre"].ToString();
                        lista.descripcion = dr["descripcion"].ToString();
                    }
                }
                if (sigue_while == true)
                {
                    throw new Exception("No se ha encontrado la lista con la ID de usuario indicada");
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
        public bool readFirstLista(ENLista_Deseos lista) //recoge todas las listas y devuelve la primera
        {
            string query = "Select * from ListaDeseos";
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                lista.nombre = dr["nombre"].ToString();
                lista.descripcion = dr["descripcion"].ToString();
                lista.usuarioID = (int)dr["usuarioID"];
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

        public bool readNextLista(ENLista_Deseos lista) //recoge todas las listas y devuelve la siguiente
        {
            bool sigue_while = true;
            string query = "Select * from ListaDeseos";
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["usuarioID"] == lista.usuarioID)
                    {
                        sigue_while = false;
                        bool siguiente = dr.Read(); //pasa al siguiente campo
                        if (siguiente == true)
                        {
                            lista.nombre = dr["nombre"].ToString();
                            lista.descripcion = dr["decripcion"].ToString();
                            lista.usuarioID = (int)dr["usuarioID"];
                        }
                        else
                            throw new Exception("No hay siguiente lista");
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

        public bool readPrevLista(ENLista_Deseos lista) //recoge todas las listas y devuelve la anterior
        {
            bool sigue_while = true;
            string query = "Select * from ListaDeseos";

            string nom = "blank";
            string desc = "blank";
            int id = 0;

            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["usuarioID"] == lista.usuarioID)
                    {
                        if (nom == "blank")
                            throw new Exception("No se ha encontrado una lista anterior");
                        sigue_while = false;
                        lista.nombre = nom;
                        lista.descripcion = desc;
                        lista.usuarioID = id;
                    }
                    else
                    {
                        nom = dr["nombre"].ToString();
                        desc = dr["descripcion"].ToString();
                        id = (int)dr["usuarioID"];
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

        public bool updateLista(ENLista_Deseos lista) //actualiza los datos de una lista según su id de usuario
        {
            string query_comprueba = "Select * from ListaDeseos";
            string query = "Update ListaDeseos set nombre = '" + lista.nombre + "', descripcion = '" + lista.descripcion + "' where usuarioID = " + lista.usuarioID;
            bool sigue_while = true;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand comprueba = new SqlCommand(query_comprueba, c);
                SqlDataReader dr = comprueba.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["usuarioID"] == lista.usuarioID)
                    {
                        sigue_while = false;
                    }
                }
                if (sigue_while == true)
                    throw new Exception("No se ha encontrado una lista con la id de usuario indicada");
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

        public bool deleteLista(ENLista_Deseos lista) //elimina la lista con la id de usuario indicada
        {
            string query_comprueba = "Select * from ListaDeseos";
            string query = "Delete from ListaDeseos where usuarioID = " + lista.usuarioID;
            bool sigue_while = true;
            try
            {
                c = new SqlConnection(conexionBBDD);
                c.Open();
                SqlCommand comprueba = new SqlCommand(query_comprueba, c);
                SqlDataReader dr = comprueba.ExecuteReader();
                while (dr.Read() && sigue_while == true)
                {
                    if ((int)dr["usuarioID"] == lista.usuarioID)
                    {
                        sigue_while = false;
                    }
                }
                if (sigue_while == true)
                    throw new Exception("No se ha encontrado una lista con la id de usuario indicada");
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