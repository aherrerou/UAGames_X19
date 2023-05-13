﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace library
{
    public class CADOferta
    {
        private String constring;

        public CADOferta()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        //Crear oferta
        public bool addOferta(ENOferta en)
        {
            bool creado = false;
            SqlConnection connection = null;
            /*String sentence = "INSERT INTO [Oferta] " +
                "(nombre, descuento, fecha_inicio, fecha_fin, productoraID, videojuegoID) " +
                "VALUES (@nombre, @descuento, @fecha_inicio, @fecha_fin, @productoraID, @videojuegoID);";*/


            try
            {
                CADProductora productora = new CADProductora();
                productora.readProductora(en.Productora);

                CADVideojuego videojuego= new CADVideojuego();
                videojuego.readVideojuego(en.Videojuego);

                String sentence = "INSERT INTO [Oferta] (nombre, descuento, fecha_inicio, fecha_fin, productoraID, videojuegoID) " +
                   "VALUES ('" + en.Nombre + "', '" + en.Descuento + "', '" + en.FechaInicio.ToString("yyyy-MM-dd") + "', '" + en.FechaFin.ToString("yyyy-MM-dd")
               + "', '" + en.Productora.Id + "', '" + en.Videojuego.Id
               + "' );";

                connection = new SqlConnection(constring);
                connection.Open();

                SqlCommand com = new SqlCommand(sentence, connection);

                /*com.Parameters.AddWithValue("@nombre", en.Nombre);
                com.Parameters.AddWithValue("@descuento", en.Descuento);
                com.Parameters.AddWithValue("@fecha_inicio", en.FechaInicio.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
                com.Parameters.AddWithValue("@fecha_fin", en.FechaFin.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
                com.Parameters.AddWithValue("@productoraID", en.Productora.Id);
                com.Parameters.AddWithValue("@videojuegoID", en.Videojuego.Id);*/

                com.ExecuteNonQuery();
                creado = true;
            }
            catch (SqlException e)
            {
                creado = false;
                Console.WriteLine("Creating oferta operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                creado = false;
                Console.WriteLine("Creating oferta operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return creado;

        }

        //Leer oferta
        public bool readOferta(ENOferta en)
        {
            bool leido = false;
            SqlConnection connection = null;
            SqlDataReader dr = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();


                string sentence = "SELECT * FROM [Oferta] WHERE nombre = @nombre";
                SqlCommand com = new SqlCommand(sentence, connection);
                com.Parameters.AddWithValue("@nombre", en.Nombre);
                //Se obtiene cursor
                dr = com.ExecuteReader();

                //Se lee primer elemento
                if (dr.Read())
                {
                    en.Id = Int32.Parse(dr["id"].ToString());
                    en.Descuento = Double.Parse(dr["descuento"].ToString());
                    en.FechaInicio = DateTime.Parse(dr["fecha_inicio"].ToString());
                    en.FechaFin = DateTime.Parse(dr["fecha_fin"].ToString()); 

                    //Lectura de la productora
                    en.Productora.Id = Int32.Parse(dr["productoraID"].ToString());

                    CADProductora prod = new CADProductora();
                    prod.readProductora(en.Productora);

                    //Lectura del videojuego
                    ENVideojuego videojuego = new ENVideojuego();
                    en.Videojuego.Id = Int32.Parse(dr["videojuegoID"].ToString());


                    //Se lee el videojuego a partir de su ID
                    CADVideojuego cad = new CADVideojuego();
                    cad.readVideojuegoId(videojuego);

                    en.Videojuego = videojuego;

                    leido = true;
                }

            }
            catch (SqlException sqlex)
            {
                leido = false;
                Console.WriteLine("Reading oferta operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leido = false;
                Console.WriteLine("Reading oferta operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leido;
        }

        public bool readOfertaId(ENOferta en)
        {
            bool leido = false;
            SqlConnection connection = null;
            SqlDataReader dr = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();


                string sentence = "SELECT * FROM [Oferta] WHERE id = @id";
                SqlCommand com = new SqlCommand(sentence, connection);
                com.Parameters.AddWithValue("@id", en.Id);
                //Se obtiene cursor
                dr = com.ExecuteReader();

                //Se lee primer elemento
                if (dr.Read())
                {
                    en.Nombre = dr["nombre"].ToString();
                    en.Descuento = Double.Parse(dr["descuento"].ToString());
                    en.FechaInicio = DateTime.Parse(dr["fecha_inicio"].ToString());
                    en.FechaFin = DateTime.Parse(dr["fecha_fin"].ToString());

                    //Lectura de la productora
                    en.Productora.Id = Int32.Parse(dr["productoraID"].ToString());

                    CADProductora prod = new CADProductora();
                    prod.readProductora(en.Productora);

                    //Lectura del videojuego
                    ENVideojuego videojuego = new ENVideojuego();
                    en.Videojuego.Id = Int32.Parse(dr["videojuegoID"].ToString());


                    //Se lee el videojuego a partir de su ID
                    CADVideojuego cad = new CADVideojuego();
                    cad.readVideojuegoId(videojuego);

                    en.Videojuego = videojuego;

                    leido = true;
                }

            }
            catch (SqlException sqlex)
            {
                leido = false;
                Console.WriteLine("Reading oferta operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leido = false;
                Console.WriteLine("Reading oferta operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leido;
        }


        //Leer todos las ofertas
        public DataTable readOfertas()
        {
            SqlConnection connection = null;
            DataTable ofertas = new DataTable();

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string sentence = "SELECT o.nombre, o.id, o.descuento, o.fecha_inicio, o.fecha_fin, " +
                    "p.nombre AS productora, v.titulo AS videojuego FROM [Oferta] o " +
                    "JOIN [Productora] p ON o.productoraID = p.id " +
                    "JOIN [Videojuego] v ON o.videojuegoID = v.id;";
                SqlDataAdapter adapter = new SqlDataAdapter(sentence, connection);
                adapter.Fill(ofertas);


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

                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return ofertas;
        }

        //ToDo rehacer
        public bool readOfertasProductora(List<ENOferta> listaVideojuegos, string prod)
        {
            bool leidos = false;
            SqlConnection connection = null;
            SqlDataReader dr = null;
            DataSet ofertas = null;
            ENOferta oferta = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string sentence = "SELECT id FROM [Productora] WHERE nombre = " + prod + ";";
                //Se obtiene Id de la productora
                SqlCommand com = new SqlCommand(sentence, connection);
                dr = com.ExecuteReader();

                //Se lee resultado de buscar la productora por nombre
                if (dr.Read())
                {
                    ENProductora productora = new ENProductora();
                    productora.Id = Int32.Parse(dr["id"].ToString());
                    productora.Nombre = prod;
                    productora.Descripcion = dr["descripcion"].ToString();
                    productora.Imagen = dr["imagen"].ToString();
                    productora.Web = dr["web"].ToString();


                    //Lectura de las ofertas
                    sentence = "SELECT * FROM [Oferta] WHERE productoraID = " + productora.Id + ";";

                    SqlDataAdapter adapter = new SqlDataAdapter(sentence, connection);
                    adapter.Fill(ofertas, "Oferta");
                    DataTable tablaOferta = ofertas.Tables["Oferta"];
                    DataRow[] rowsOfertas= tablaOferta.Select();

                    for (int i = 0; i < rowsOfertas.Length; i++)
                    {
                        oferta = new ENOferta();
                        oferta.Id = Int32.Parse(rowsOfertas[i]["id"].ToString());
                        oferta.Nombre = rowsOfertas[i]["nombre"].ToString();
                        oferta.FechaInicio = DateTime.Parse(rowsOfertas[i]["fecha_inicio"].ToString());
                        oferta.FechaFin = DateTime.Parse(rowsOfertas[i]["fecha_fin"].ToString());
                        oferta.Descuento = Double.Parse(rowsOfertas[i]["descuento"].ToString());

                        oferta.Productora = productora;

                        //Lectura del videojuego
                        ENVideojuego videojuego = new ENVideojuego();
                        videojuego.Id = Int32.Parse(dr["videojuegoID"].ToString());

                        //Se lee la videojuego a partir de su ID
                        sentence = "SELECT * FROM [Videojuego] WHERE id = " + videojuego.Id + ";";
                        //Se obtiene Id de la productora
                        com = new SqlCommand(sentence, connection);
                        dr = com.ExecuteReader();

                        if (dr.Read())
                        {
                            videojuego.Titulo = dr["titulo"].ToString();
                            videojuego.Descripcion = dr["descripcion"].ToString();
                            videojuego.FechaLanzamiento = DateTime.Parse(dr["fecha_lanzamiento"].ToString());
                            videojuego.Plataforma = dr["plataforma"].ToString();
                            videojuego.Precio = Double.Parse(dr["precio"].ToString());
                            videojuego.Imagen = dr["imagen"].ToString();
                            videojuego.Productora = productora;

                            //Lectura de la categoria
                            ENCategoria cat = new ENCategoria();
                            cat.id = Int32.Parse(dr["categoriaID"].ToString());

                            //Se lee la categoria a partir de su ID
                            sentence = "SELECT * FROM [Categoria] WHERE id = " + cat.id + ";";
                            //Se obtiene Id de la productora
                            com = new SqlCommand(sentence, connection);
                            dr = com.ExecuteReader();

                            if (dr.Read())
                            {
                                cat.nombre = dr["nombre"].ToString(); ;
                                cat.descripcion = dr["descripcion"].ToString();
                            }

                            videojuego.Categoria = cat;

                        }

                        oferta.Videojuego = videojuego;

                    }

                    leidos = true;
                }


            }
            catch (SqlException sqlex)
            {
                leidos = false;
                Console.WriteLine("Reading ofertas and productora operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leidos = false;
                Console.WriteLine("Reading ofertas and productora operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leidos;
        }

        public bool updateOferta(ENOferta en)
        {
            bool actualizado = false;
            SqlConnection connection = null;
            /*String sentence = "UPDATE [Oferta] SET " +
                "nombre = @nombre, fecha_inicio = @fecha_inicio," +
                "fecha_fin = @fecha_fin, descuento = @descuento, productoraID = @productoraID, videojuegoID = @videojuegoID) " +
                "WHERE id = @id;";*/


            try
            {
                CADProductora productora = new CADProductora();
                productora.readProductoraNombre(en.Productora);

                CADVideojuego videojuego = new CADVideojuego();
                videojuego.readVideojuego(en.Videojuego);

                String sentence = "UPDATE [Oferta] SET nombre='" + en.Nombre + "', fecha_inicio='" + en.FechaInicio.ToString("yyyy-MM-dd")
                + "', fecha_fin='" + en.FechaFin.ToString("yyyy-MM-dd") + "', descuento='" + en.Descuento
                + "', productoraID='" + en.Productora.Id + "', videojuegoID='" + en.Videojuego.Id
                + "' WHERE id = '" + en.Id + "';";

                connection = new SqlConnection(constring);
                connection.Open();

                SqlCommand com = new SqlCommand(sentence, connection);

                /*com.Parameters.AddWithValue("@nombre", en.Nombre);
                com.Parameters.AddWithValue("@fecha_inicio", en.FechaInicio.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
                com.Parameters.AddWithValue("@fecha_fin", en.FechaFin.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
                com.Parameters.AddWithValue("@descuento", en.Descuento);
                com.Parameters.AddWithValue("@productoraID", en.Productora.Id);
                com.Parameters.AddWithValue("@videojuegoID", en.Videojuego.Id);
                com.Parameters.AddWithValue("@id", en.Id);*/

                com.ExecuteNonQuery();

                actualizado = true;
            }
            catch (SqlException e)
            {
                actualizado = false;
                Console.WriteLine("Updating oferta operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                actualizado = false;
                Console.WriteLine("Updating oferta operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return actualizado;

        }


        public bool deleteOferta(ENOferta en)
        {
            bool eliminado = false;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string sentence = "DELETE FROM [Oferta] " +
                    "where id = @id;";
                SqlCommand com = new SqlCommand(sentence, connection);
                com.Parameters.AddWithValue("@id", en.Id);
                com.ExecuteNonQuery();

                eliminado = true;
            }
            catch (SqlException e)
            {
                eliminado = false;
                Console.WriteLine("Deleting oferta operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                eliminado = false;
                Console.WriteLine("Deleting oferta operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return eliminado;
        }
    }
}
