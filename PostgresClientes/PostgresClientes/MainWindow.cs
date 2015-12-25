using System;
using Gtk;
using PostgresClientes;


public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();



	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	public static void CrearDataView(TreeView tv, int numCOl){
		//int numCol = dr.MetaData.metaDataArray.length;
		for (int i = 0; i < DataSource.numCol; i++) {
			tv.AppendColumn (DataSource.dr.GetName(i).ToString(),new CellRendererText(),"text",i);
		}
		tv.Model = DataSource.lsClientes;
		//DataSource.lsClientes.Clear ();
		DataSource.dr.Close ();
		PgConnexion.pcon.Close ();

	}

	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		try {
			if (PgConnexion.pcon.State==System.Data.ConnectionState.Closed) {
				PgConnexion.pcon.Open ();
			}

			int longi,veces=0;
			longi = treeview1.Columns.Length;

			if (entry3.Text == "") {
				MessageBox.Show ("Espabila y escribe un query!");
			} else {

				if (treeview1.Columns.Length>0) {

					for (int i = 0; i <=treeview1.Columns.Length-1; i++) {
						treeview1.RemoveColumn (treeview1.Columns[i]);
						veces += 1;
						label1.LabelProp = veces.ToString();
					}

				}
				DataSource.GenerarDataReader (entry3.Text);
				DataSource.GeneraListStore (DataSource.numCol);
				DataSource.CargarListStore ();

				if (treeview1.Columns.Length==0) {

					CrearDataView (treeview1, DataSource.numCol);
					//MessageBox.Show ("Finalizando Click: " + veces.ToString ());
				}
			
			} }catch (Exception ex) {
			MessageBox.Show("Se ha producido un error");
			label1.LabelProp = "Error: " + ex.ToString ();    
		}





		
	}
}


