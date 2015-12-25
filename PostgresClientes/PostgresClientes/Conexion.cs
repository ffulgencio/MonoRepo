using System;
using System.Data;
using Npgsql;
using Gtk;

namespace PostgresClientes
{
	public class PgConnexion
	{

		public static NpgsqlConnection pcon=new NpgsqlConnection("Server=localhost;port=5432;Database=prueba;User ID=postgres;Password=;Pooling=false;");

		public static void conectar()
		{
			//pcon.ConnectionString = "Server=localhost;port=5432;Database=prueba;User ID=postgres;Password=postgres;Pooling=false;";

			try {
				if (pcon.State==ConnectionState.Closed) {
					pcon.Open();
					//MessageBox.Show("Conexion exitosa!");
					//win.Title= ("Conexion exitosa!");
				}
			} catch (Exception ex) {
				MessageBox.Show("Error de conexion!");

			}
		}
	}
}
