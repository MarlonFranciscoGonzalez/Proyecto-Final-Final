using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_Final
{
    internal class Persistencia
    {
        private readonly string _connectionString;

        public Persistencia(string connectionString)
        {
            _connectionString = connectionString;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
            CREATE TABLE IF NOT EXISTS empleado (
                Idempleado INTEGER PRIMARY KEY,
                Puesto TEXT NOT NULL,
                Cedula TEXT NOT NULL,
                Nombre TEXT NOT NULL,
                Apellido TEXT NOT NULL,
                Edad INTEGER NOT NULL,
                Telefono TEXT NOT NULL,
                Salario NUMERIC NOT NULL,
                Cuentabanco INTEGER NOT NULL
            );
        ";
            command.ExecuteNonQuery();

            command.CommandText =
            @"
            CREATE TABLE IF NOT EXISTS registrolaboral (
                Idempleado INTEGER PRIMARY KEY,
                HorasTrabajadas INTEGER NOT NULL,
                Tarifa NUMERIC NOT NULL
            );
        ";
            command.ExecuteNonQuery();

            command.CommandText =
            @"
            CREATE TABLE IF NOT EXISTS nomina (
                Idempleado INTEGER PRIMARY KEY,
                Fecha TEXT NOT NULL,
                Cedula TEXT NOT NULL,
                Salario NUMERIC NOT NULL,
                HorasTrabajadas INTEGER NOT NULL,
                Cuentabanco INTEGER NOT NULL
            );
        ";
            command.ExecuteNonQuery();
        }

        public List<Empleado> GetEmpleado()
        {
            var empleados = new List<Empleado>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM empleado;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var empleado = new Empleado
                {
                    Idempleado = reader.GetInt32(0),
                    Puesto = reader.GetString(1),
                    Cedula = reader.GetString(2),
                    Nombre = reader.GetString(3),
                    Apellido = reader.GetString(4),
                    Edad = reader.GetInt32(5),
                    Telefono = reader.GetString(6),
                    Salario = reader.GetDouble(7),
                    Cuentabanco = reader.GetInt32(8)
                };
                empleados.Add(empleado);
            }

            return empleados;
        }

        public void GuardarEmpleado(Empleado empleado)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO empleado " +
                "(Puesto, Cedula, Nombre, Apellido, Edad, Telefono, Salario, Cuentabanco) VALUES " +
                "(@puesto, @cedula, @nombre, @apellido, @edad, @telefono, @salario, @cuentabanco);";
            command.Parameters.AddWithValue("@puesto", empleado.Puesto);
            command.Parameters.AddWithValue("@cedula", empleado.Cedula);
            command.Parameters.AddWithValue("@nombre", empleado.Nombre);
            command.Parameters.AddWithValue("@apellido", empleado.Apellido);
            command.Parameters.AddWithValue("@edad", empleado.Edad);
            command.Parameters.AddWithValue("@telefono", empleado.Telefono);
            command.Parameters.AddWithValue("@salario", empleado.Salario);
            command.Parameters.AddWithValue("@cuentabanco", empleado.Cuentabanco);
            command.ExecuteNonQuery();
        }

        public void ActualizarEmpleado(int idempleado, string puesto, string cedula, string nombre, string apellido, int edad, string telefono, double salario)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "UPDATE empleado SET Puesto = @puesto, Cedula = @cedula, Nombre = @nombre, Apellido = @apellido, Edad = @edad, Telefono = @telefono, Salario = @salario WHERE Idempleado = idempleado;";
            command.Parameters.AddWithValue("@idempleado", idempleado);
            command.Parameters.AddWithValue("@puesto", puesto);
            command.Parameters.AddWithValue("@cedula", cedula);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@apellido", apellido);
            command.Parameters.AddWithValue("@edad", edad);
            command.Parameters.AddWithValue("@telefono", telefono);
            command.Parameters.AddWithValue("@salario", salario);
            command.ExecuteNonQuery();
        }

        public void EliminarEmpleado(int idempleado)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM empleado WHERE Idempleado = @idempleado;";
            command.Parameters.AddWithValue("@idempleado", idempleado);
            command.ExecuteNonQuery();
        }

        public void EliminarEmpleado(Empleado empleado)
        {
            EliminarEmpleado(empleado.Idempleado);
        }

        public List<RegistroLaboral> GetRegistroLaboral()
        {
            var registrolaborales = new List<RegistroLaboral>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM registrolaboral;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var registrolaboral = new RegistroLaboral
                {
                    Idempleado = reader.GetInt32(0),
                    Horastrabajadas = reader.GetInt32(1),
                    Tarifa = reader.GetDouble(2)
                };
                registrolaborales.Add(registrolaboral);
            }

            return registrolaborales;
        }

        public void GuardarRegistroLaboral(RegistroLaboral registroLaboral)
        {
            using var connection = new SqliteConnection(_connectionString); 
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO registrolaboral (Horastrabajadas, Tarifa)" +
                                  " VALUES (@horastrabajadas, @tarifa);";
            command.Parameters.AddWithValue("@horastrabajadas", registroLaboral.Horastrabajadas);
            command.Parameters.AddWithValue("@tarifa", registroLaboral.Tarifa);
            command.ExecuteNonQuery();
        }

        public void ActualizarRegistroLaboral(int idempleado, int horastrabajadas, double tarifa)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "UPDATE registrolaboral SET Horastrabajadas = @horastrabajadas, Tarifa = @tarifa WHERE Idempleado = @idempleado";
            command.Parameters.AddWithValue("@idempleado", idempleado);
            command.Parameters.AddWithValue("@horastrabajadas", horastrabajadas);
            command.Parameters.AddWithValue("@tarifa", tarifa);
            command.ExecuteNonQuery();
        }

        public void EliminarRegistroLaboral(int idempleado)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM registrolaboral WHERE Idempleado = @idempleado;";
            command.Parameters.AddWithValue("@idempleado", idempleado);
            command.ExecuteNonQuery();
        }

        public void EliminarRegistroLaboral(RegistroLaboral registroLaboral)
        {
            EliminarEmpleado(registroLaboral.Idempleado);
        }

        public void GuardarNomina(DetalleNomina nomina)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO nomina (Fecha, Cedula, Salario, Horastrabajadas, Cuentabanco) VALUES (@fecha, @cedula, @salario, @horastrabajadas, @cuentabanco);";
            command.Parameters.AddWithValue("@fecha", nomina.Fecha);
            command.Parameters.AddWithValue("@cedula", nomina.Cedula);
            command.Parameters.AddWithValue("@salario", nomina.Salario);
            command.Parameters.AddWithValue("@horastrabajadas", nomina.Horastrabajadas);
            command.Parameters.AddWithValue("@cuentabanco", nomina.Cuentabanco);
            command.ExecuteNonQuery();
        }

        public List<DetalleNomina> GetNomina()
        {
            var nominas = new List<DetalleNomina>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM nomina;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var nomina = new DetalleNomina()
                {
                    Idempleado = reader.GetInt32(0),
                    Fechaguardada = reader.GetString(1),
                    Cedula = reader.GetString(2),
                    Salario = reader.GetDouble(3),
                    Horastrabajadas = reader.GetInt32(4),
                    Cuentabanco = reader.GetInt32(5)
                };
                nominas.Add(nomina);
            }
            return nominas;
        }

        public void EliminarNomina(int idempleado)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM nomina WHERE Idempleado = @idempleado;";
            command.Parameters.AddWithValue("@idempleado", idempleado);
            command.ExecuteNonQuery();
        }
    }
}