using System;
using System.Data;
using Npgsql;
using Gtk;


namespace PostgresClientes
{
	public class Auxiliares
	{
		public Auxiliares ()
		{
		}
	}

	public class MessageBox{
		public static void Show(string mens){
			MessageDialog md;
			md = new MessageDialog (null, DialogFlags.Modal,MessageType.Info,ButtonsType.Ok,mens);
			md.Run ();
			md.Destroy ();
		}
	}

	public  static class DataSource{
		public static NpgsqlCommand sc;
		public static NpgsqlDataReader dr;
		public static int numCol;
		public static ListStore lsClientes;

		public static void GenerarDataReader (string q){
			PgConnexion.conectar ();
			sc = new	NpgsqlCommand (q, PgConnexion.pcon);
			dr = sc.ExecuteReader ();
			numCol = dr.FieldCount;
		}

		public static ListStore GeneraListStore(int numCol){
			ListStore List;
			Type[] listComp = new Type[numCol];
			for (int i = 0; i <numCol; i++) {
				listComp [i] = typeof(String);	
			} 
			List = new ListStore (listComp);
			return List;
		} //----------------------------------------------

		public static void CargarListStore(){
			lsClientes=GeneraListStore(numCol);
			//Generar los valores para el ListStore de forma automatica
			String[] array = new String[numCol];
			while (dr.Read()) {
				for (int j = 0; j < numCol; j++) {
					array [j] = dr [j].ToString ();
				}
				lsClientes.AppendValues (array);//, dr [1].ToString(), dr [2].ToString());

			}
			dr.Close ();
			//CrearDataView (treeview1, numCol);

		}


		

		
}



}
