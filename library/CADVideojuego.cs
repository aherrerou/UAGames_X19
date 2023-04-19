using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace library
{
    public class CADVideojuego
    {
        private String constring;

        public CADVideojuego()
        {
            constring = ConfigurationManager.ConnectionStrings["UAGames"].ToString();
        }

        //Crear videojuego
        public bool addVideojuego(ENVideojuego en)
        {
            bool creado = false;
            SqlConnection connection = null;
            String sentence = "INSERT INTO [Videojuego] " +
                "(titulo, descripcion, fecha_lanzamiento, plataforma, precio, imagen, productoraID, categoriaID) " +
                "VALUES (@titulo, @descripcion, @fecha_lanzamiento, @plataforma, @precio, @imagen, @productoraID, @categoriaID);";


            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                SqlCommand com = new SqlCommand(sentence, connection);

                com.Parameters.AddWithValue("@titulo", en.Titulo);
                com.Parameters.AddWithValue("@descripcion", en.Descripcion);
                com.Parameters.AddWithValue("@fecha_lanzamiento", en.FechaLanzamiento.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
                com.Parameters.AddWithValue("@plataforma", en.Plataforma);
                com.Parameters.AddWithValue("@precio", en.Precio);
                com.Parameters.AddWithValue("@imagen", en.Imagen);
                com.Parameters.AddWithValue("@productoraID", en.Productora.Id);
                com.Parameters.AddWithValue("@categoriaID", en.Categoria.Id);

                com.ExecuteNonQuery();
                creado = true;
            }
            catch (SqlException e)
            {
                creado = false;
                Console.WriteLine("Creating videogame operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                creado = false;
                Console.WriteLine("Creating videogame operation has failed.Error: {0}", e.Message);
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

        //Leer videojuego
        public bool readVideojuego(ENVideojuego en)
        {
            bool leido = false;
            SqlConnection connection = null;
            SqlDataReader dr = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();
                string sentence = "SELECT * FROM [Videojuego] WHERE titulo = @titulo";
                SqlCommand com = new SqlCommand(sentence, connection);
                com.Parameters.AddWithValue("@titulo", en.Titulo);
                //Se obtiene cursor
                dr = com.ExecuteReader();

                //Se lee primer elemento
                if (dr.Read())
                {
                    en.Id = Int32.Parse(dr["id"].ToString());
                    en.Descripcion = dr["descripcion"].ToString();
                    en.FechaLanzamiento = DateTime.Parse(dr["fecha_lanzamiento"].ToString());
                    en.Plataforma = dr["plataforma"].ToString();
                    en.Imagen = dr["imagen"].ToString();
                    en.Precio = Double.Parse(dr["precio"].ToString());

                    //Lectura de la productora
                    ENProductora productora = new ENProductora();
                    productora.Id = Int32.Parse(dr["productoraID"].ToString());

                    /*
                    sentence = "SELECT * FROM [Productora] WHERE id = " + productora.Id + ";";
                    com = new SqlCommand(sentence, connection);
                    dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        productora.Nombre = dr["nombre"].ToString(); ;
                        productora.Descripcion = dr["descripcion"].ToString();
                        productora.Imagen = dr["imagen"].ToString();
                        productora.Web = dr["web"].ToString();
                    }*/

                    en.Productora = productora;

                    //Lectura de la categoria
                    ENCategoria cat = new ENCategoria();
                    cat.Id = Int32.Parse(dr["categoriaID"].ToString());

                    /*
                    //Se lee la categoria a partir de su ID
                    sentence = "SELECT * FROM [Categoria] WHERE id = " + cat.Id + ";";
                    //Se obtiene Id de la productora
                    com = new SqlCommand(sentence, connection);
                    SqlDataReader dr2 = com.ExecuteReader();

                    if (dr.Read())
                    {
                        cat.Nombre = dr2["nombre"].ToString(); ;
                        cat.Descripcion = dr2["descripcion"].ToString();
                    }*/

                    en.Categoria = cat;

                    leido = true;
                }

            }
            catch (SqlException sqlex)
            {
                leido = false;
                Console.WriteLine("Reading videojuego operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leido = false;
                Console.WriteLine("Reading videojuego operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leido;
        }

        //Leer todos los videojuegos
        public bool readVideojuegos(List<ENVideojuego> listaVideojuegos)
        {
            bool leidos = false;
            SqlConnection connection = null;
            DataSet videojuegos = null;
            ENVideojuego videojuego = null;
            SqlDataReader dr = null;
            SqlCommand com = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string sentence = "SELECT * FROM [Videojuego];";
                SqlDataAdapter adapter = new SqlDataAdapter(sentence, connection);
                adapter.Fill(videojuegos, "Videojuego");
                DataTable tableVideojuego = videojuegos.Tables["Videojuego"];
                DataRow[] rowsVideojuegos = tableVideojuego.Select();

                for(int i = 0; i < rowsVideojuegos.Length; i++)
                {
                    videojuego = new ENVideojuego();
                    videojuego.Id = Int32.Parse(rowsVideojuegos[i]["id"].ToString());
                    videojuego.Descripcion = rowsVideojuegos[i]["descripcion"].ToString();
                    videojuego.FechaLanzamiento = DateTime.Parse(rowsVideojuegos[i]["fecha_lanzamiento"].ToString());
                    videojuego.Plataforma = rowsVideojuegos[i]["plataforma"].ToString();
                    videojuego.Imagen = rowsVideojuegos[i]["imagen"].ToString();
                    videojuego.Precio = Double.Parse(rowsVideojuegos[i]["precio"].ToString());

                    //Lectura de la productora
                    ENProductora productora = new ENProductora();
                    productora.Id = Int32.Parse(rowsVideojuegos[i]["productoraID"].ToString());

                    sentence = "SELECT * FROM [Productora] WHERE id = " + productora.Id + ";";
                    com = new SqlCommand(sentence, connection);
                    dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        productora.Nombre = dr["nombre"].ToString(); ;
                        productora.Descripcion = dr["descripcion"].ToString();
                        productora.Imagen = dr["imagen"].ToString();
                        productora.Web = dr["Web"].ToString();
                    }

                    videojuego.Productora = productora;

                    //Lectura de la categoria
                    ENCategoria cat = new ENCategoria();
                    cat.Id = Int32.Parse(rowsVideojuegos[i]["categoriaID"].ToString());

                    //Se lee la categoria a partir de su ID
                    sentence = "SELECT * FROM [Categoria] WHERE id = " + cat.Id + ";";
                    //Se obtiene Id de la productora
                    com = new SqlCommand(sentence, connection);
                    dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        cat.Nombre = dr["nombre"].ToString(); ;
                        cat.Descripcion = dr["descripcion"].ToString();
                    }

                    videojuego.Categoria = cat;

                }

                leidos = true;
            
            }
            catch (SqlException sqlex)
            {
                leidos = false;
                Console.WriteLine("Reading videojuegos operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leidos = false;
                Console.WriteLine("Reading videojuegos operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leidos;
        }

        //Leer videojuegos especificos de una productora
        public bool readVideojuegosProductora(List<ENVideojuego> listaVideojuegos, string prod)
        {
            bool leidos = false;
            SqlConnection connection = null;
            SqlDataReader dr = null;
            DataSet videojuegos = null;
            ENVideojuego videojuego = null;

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


                    //Lectura de los videojuegos
                    sentence = "SELECT * FROM [Videojuego] WHERE productoraID = " + productora.Id + ";";

                    SqlDataAdapter adapter = new SqlDataAdapter(sentence, connection);
                    adapter.Fill(videojuegos, "Videojuego");
                    DataTable tableVideojuego = videojuegos.Tables["Videojuego"];
                    DataRow[] rowsVideojuegos = tableVideojuego.Select();

                    for (int i = 0; i < rowsVideojuegos.Length; i++)
                    {
                        videojuego = new ENVideojuego();
                        videojuego.Id = Int32.Parse(rowsVideojuegos[i]["id"].ToString());
                        videojuego.Descripcion = rowsVideojuegos[i]["descripcion"].ToString();
                        videojuego.FechaLanzamiento = DateTime.Parse(rowsVideojuegos[i]["fecha_lanzamiento"].ToString());
                        videojuego.Plataforma = rowsVideojuegos[i]["plataforma"].ToString();
                        videojuego.Imagen = rowsVideojuegos[i]["imagen"].ToString();
                        videojuego.Precio = Double.Parse(rowsVideojuegos[i]["precio"].ToString());

                        videojuego.Productora = productora;

                        //Lectura de la categoria
                        ENCategoria cat = new ENCategoria();
                        cat.Id = Int32.Parse(rowsVideojuegos[i]["categoriaID"].ToString());

                        //Se lee la categoria a partir de su ID
                        sentence = "SELECT * FROM [Categoria] WHERE id = " + cat.Id + ";";
                        //Se obtiene Id de la productora
                        com = new SqlCommand(sentence, connection);
                        dr = com.ExecuteReader();

                        if (dr.Read())
                        {
                            cat.Nombre = dr["nombre"].ToString(); ;
                            cat.Descripcion = dr["descripcion"].ToString();
                        }

                        videojuego.Categoria = cat;

                    }

                    leidos = true;
                }


            }
            catch (SqlException sqlex)
            {
                leidos = false;
                Console.WriteLine("Reading videojuegos and productora operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leidos = false;
                Console.WriteLine("Reading videojuegos and productora operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leidos;
        }

        //Leer videojuegos especificos de una categoria
        public bool readVideojuegosCategoria(List<ENVideojuego> listaVideojuegos, string cat)
        {
            bool leidos = false;
            SqlConnection connection = null;
            SqlDataReader dr = null;
            DataSet videojuegos = null;
            ENVideojuego videojuego = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string sentence = "SELECT id FROM [Categoria] WHERE nombre = " + cat + ";";
                //Se obtiene Id de la productora
                SqlCommand com = new SqlCommand(sentence, connection);
                dr = com.ExecuteReader();

                //Se lee resultado de buscar la productora por nombre
                if (dr.Read())
                {
                    ENCategoria categoria = new ENCategoria();
                    categoria.Id = Int32.Parse(dr["id"].ToString());
                    categoria.Nombre = cat;
                    categoria.Descripcion = dr["descripcion"].ToString();

                    //Lectura de los videojuegos
                    sentence = "SELECT * FROM [Videojuego] WHERE productoraID = " + categoria.Id + ";";

                    SqlDataAdapter adapter = new SqlDataAdapter(sentence, connection);
                    adapter.Fill(videojuegos, "Videojuego");
                    DataTable tableVideojuego = videojuegos.Tables["Videojuego"];
                    DataRow[] rowsVideojuegos = tableVideojuego.Select();

                    for (int i = 0; i < rowsVideojuegos.Length; i++)
                    {
                        videojuego = new ENVideojuego();
                        videojuego.Id = Int32.Parse(rowsVideojuegos[i]["id"].ToString());
                        videojuego.Descripcion = rowsVideojuegos[i]["descripcion"].ToString();
                        videojuego.FechaLanzamiento = DateTime.Parse(rowsVideojuegos[i]["fecha_lanzamiento"].ToString());
                        videojuego.Plataforma = rowsVideojuegos[i]["plataforma"].ToString();
                        videojuego.Imagen = rowsVideojuegos[i]["imagen"].ToString();
                        videojuego.Precio = Double.Parse(rowsVideojuegos[i]["precio"].ToString());

                        videojuego.Categoria = categoria;

                        //Lectura de la productora
                        ENProductora productora = new ENProductora();
                        productora.Id = Int32.Parse(rowsVideojuegos[i]["productoraID"].ToString());

                        sentence = "SELECT * FROM [Productora] WHERE id = " + productora.Id + ";";
                        //Se obtiene Id de la productora
                        com = new SqlCommand(sentence, connection);
                        dr = com.ExecuteReader();

                        if (dr.Read())
                        {
                            productora.Nombre = dr["nombre"].ToString(); ;
                            productora.Descripcion = dr["descripcion"].ToString();
                            productora.Imagen = dr["imagen"].ToString();
                            productora.Web = dr["web"].ToString();
                        }

                        videojuego.Productora = productora;

                    }

                    leidos = true;
                }


            }
            catch (SqlException sqlex)
            {
                leidos = false;
                Console.WriteLine("Reading videojuegos and categoria operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                leidos = false;
                Console.WriteLine("Reading videojuegos and categoria operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (connection != null) connection.Close(); // Se asegura de cerrar la conexión.
            }
            return leidos;
        }



        //Actualizar videojuego
        public bool updateVideojuego(ENVideojuego en)
        {
            bool actualizado = false;
            SqlConnection connection = null;
            String sentence = "UPDATE [Videojuego] SET " +
                "titulo = @titulo, descripcion = @descripcion, fecha_lanzamiento = @fecha_lanzamiento," +
                "plataforma = @plataforma, precio = @precio, imagen = @imagen, productoraID = @productoraID, categoriaID = @categoriaID) " +
                "WHERE id = @id;";


            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                SqlCommand com = new SqlCommand(sentence, connection);

                com.Parameters.AddWithValue("@titulo", en.Titulo);
                com.Parameters.AddWithValue("@descripcion", en.Descripcion);
                com.Parameters.AddWithValue("@fecha_lanzamiento", en.FechaLanzamiento.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
                com.Parameters.AddWithValue("@plataforma", en.Plataforma);
                com.Parameters.AddWithValue("@precio", en.Precio);
                com.Parameters.AddWithValue("@imagen", en.Imagen);
                com.Parameters.AddWithValue("@productoraID", en.Productora.Id);
                com.Parameters.AddWithValue("@categoriaID", en.Categoria);
                com.Parameters.AddWithValue("@id", en.Id);

                com.ExecuteNonQuery();

                actualizado = true;
            }
            catch (SqlException e)
            {
                actualizado = false;
                Console.WriteLine("Updating videogame operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                actualizado = false;
                Console.WriteLine("Updating videogame operation has failed.Error: {0}", e.Message);
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

        //Eliminar videojuego
        public bool deleteVideojuego(ENVideojuego en)
        {
            bool eliminado = false;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string sentence = "DELETE FROM [Videojuego] " +
                    "where id = @id;";
                SqlCommand com = new SqlCommand(sentence, connection);
                com.Parameters.AddWithValue("@id", en.Id);
                com.ExecuteNonQuery();

                eliminado = true;
            }
            catch (SqlException e)
            {
                eliminado = false;
                Console.WriteLine("Deleting videogame operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                eliminado = false;
                Console.WriteLine("Deleting videogame operation has failed.Error: {0}", e.Message);
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
