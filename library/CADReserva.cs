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
    class CADReserva
    {
        private string conexionBBDD;
        private SqlConnection c;

        public CADReserva()
        {
            conexionBBDD = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;";
            c = new SqlConnection(conexionBBDD);
        }

        public bool createReserva(ENReserva Reserva, ENUsuario usuario, ENVideoJuego videojuego)
        {
            bool result = true;
            try
            {
                this.c.Open();
                Reserva.fecha.ToString("yyyy-MM-dd HH:mm:ss");
                string query = "INSERT INTO Reserva(fecha , fechaEntrega , pagado , usuarioID , videojuegoID) VALUES ( CONVERT(datetime, '" + Reserva.fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', 120)," + "CONVERT(datetime, '" + Reserva.fechaEntrega.ToString("yyyy-MM-dd HH:mm:ss") + "', 120)," + usuario.id + ", " + videojuego.id  ");";
                SqlCommand com = new SqlCommand(query, c);
                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            finally
            {
                this.c.Close();
            }

            return result;
        }

        public bool deleteReserva(ENReserva Reserva)
        {
            bool result = true;
            try
            {
                c.Open();
                string query = "DELETE FROM Reserva WHERE id=" + Reserva.id + ";";
                SqlCommand com = new SqlCommand(query, c);
                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            finally
            {
                this.c.Close();
            }
            return result;
        }

        public bool updateReserva(ENReserva Reserva)
        {
            bool result = true;
            try
            {
                c.Open();
                string query = "UPDATE Reserva SET " +
                    "fechaEntrega=" + Reserva.fechaEntrega + ", fechaReserva=" + fechaReserva + ", pagado=" + Reserva.pagado " WHERE id=" + Reserva.id + ";";
                SqlCommand com = new SqlCommand(query, c);
                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            finally
            {
                this.c.Close();
            }
            return result;
        }

        public bool readReserva(ENReserva Reserva)
        {
            bool result = true;
            try
            {
                this.c.Open();
                string query = "SELECT * FROM Reserva WHERE id = " + Reserva.id + ";";
                SqlCommand com = new SqlCommand(query, c);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    Reserva.pagado = Double.Parse(reader["pagado"].ToString());
                    // Si queremos saber el cliente y la fecha del pedido añadir aqui
                }
                else
                {
                    result = false;
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                result = false;
            }
            finally
            {
                this.c.Close();
            }
            return result;
        }
    }
}
