using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CochesCutres.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NIF { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }

    public class MantenimientoClientes
    {
        private SqlConnection connection;
        
        private void Conectar()
        {
            string strCon = ConfigurationManager.ConnectionStrings["cochesCutres"].ToString();
            connection = new SqlConnection(strCon);
        }

        public int Alta(Cliente cliente)
        {
            Conectar();

            string sentencia = "INSERT INTO Clientes(NIF, Nombre, Apellidos, Telefono, Direccion, Email)" +
                " VALUES(@NIF, @Nombre, @Apellidos, @Telefono, @Direccion, @Email)";

            SqlCommand command = new SqlCommand(sentencia, connection);

            command.Parameters.Add("@NIF",SqlDbType.VarChar);
            command.Parameters.Add("@Nombre",SqlDbType.VarChar);
            command.Parameters.Add("@Apellidos",SqlDbType.VarChar);
            command.Parameters.Add("@Telefono",SqlDbType.Int);
            command.Parameters.Add("@Direccion",SqlDbType.VarChar);
            command.Parameters.Add("@Email",SqlDbType.VarChar);

            command.Parameters["@NIF"].Value = cliente.NIF;
            command.Parameters["@Nombre"].Value = cliente.Nombre;
            command.Parameters["@Apellidos"].Value = cliente.Apellidos;
            command.Parameters["@Telefono"].Value = cliente.Telefono;
            command.Parameters["@Direccion"].Value = cliente.Direccion;
            command.Parameters["@Email"].Value = cliente.Email;

            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }


        public int Modificar(Cliente cliente)
        {
            Conectar();

            string sentencia = "UPDATE Clientes " +
                "SET NIF = @NIF, Nombre = @Nombre, Apellidos = @Apellidos, " +
                "Telefono = @Telefono, Direccion = @Direccion, Email = @Email " +
                "WHERE IdCliente = @IdCliente";

            SqlCommand command = new SqlCommand(sentencia, connection);

            command.Parameters.Add("@NIF", SqlDbType.VarChar);
            command.Parameters.Add("@Nombre", SqlDbType.VarChar);
            command.Parameters.Add("@Apellidos", SqlDbType.VarChar);
            command.Parameters.Add("@Telefono", SqlDbType.Int);
            command.Parameters.Add("@Direccion", SqlDbType.VarChar);
            command.Parameters.Add("@Email", SqlDbType.VarChar);
            command.Parameters.Add("@IdCliente", SqlDbType.Int);

            command.Parameters["@NIF"].Value = cliente.NIF;
            command.Parameters["@Nombre"].Value = cliente.Nombre;
            command.Parameters["@Apellidos"].Value = cliente.Apellidos;
            command.Parameters["@Telefono"].Value = cliente.Telefono;
            command.Parameters["@Direccion"].Value = cliente.Direccion;
            command.Parameters["@Email"].Value = cliente.Email;
            command.Parameters["@IdCliente"].Value = cliente.IdCliente;

            connection.Open();
            int res = command.ExecuteNonQuery();
            connection.Close();

            return res;
        }

        public Cliente Obtener(int IdCliente)
        {
            Conectar();

            Cliente cliente = new Cliente();

            string sentencia = "SELECT * FROM Clientes WHERE IdCliente = @IdCliente";
            SqlCommand command = new SqlCommand(sentencia, connection);

            command.Parameters.Add("@IdCliente", SqlDbType.Int);

            command.Parameters["@IdCliente"].Value = IdCliente;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {

                cliente.IdCliente = IdCliente;
                cliente.NIF = reader["NIF"].ToString();
                cliente.Nombre = reader["Nombre"].ToString();
                cliente.Apellidos = reader["Apellidos"].ToString();
                cliente.Direccion = reader["Direccion"].ToString();
                cliente.Telefono = int.Parse(reader["Telefono"].ToString());
                cliente.Email = reader["Email"].ToString();
            }

            connection.Close();

            return cliente;
        }


        public List<Cliente> Listar()
        {
            Conectar();

            List<Cliente> clientes = new List<Cliente>();

            string sentencia = "SELECT * FROM Clientes";

            SqlCommand command = new SqlCommand(sentencia, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();

                cliente.IdCliente = int.Parse(reader["IdCliente"].ToString());
                cliente.NIF = reader["NIF"].ToString();
                cliente.Nombre = reader["Nombre"].ToString();
                cliente.Apellidos = reader["Apellidos"].ToString();
                cliente.Telefono = int.Parse(reader["Telefono"].ToString());
                cliente.Direccion = reader["Direccion"].ToString();
                cliente.Email = reader["Email"].ToString();

                clientes.Add(cliente);
            }

            connection.Close();

            return clientes;
        }
    }
}