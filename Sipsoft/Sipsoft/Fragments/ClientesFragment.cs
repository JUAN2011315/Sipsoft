using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Support.V7.View;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using Sipsoft.Services;

namespace Sipsoft.Fragments
{
    public class ClientesFragment : Fragment
    {
        Android.Widget.EditText Nombre, Rfc, Total, Contratados, Disponibles, Emitidos, Cancelados, UltimaFactura;
        Android.Widget.Button Registrar;
        CloudTable table;
        Android.Views.View view;
        CloudStorageAccount CuentaAzure;
        CloudTableClient tableClient;
        public ClientesFragment()
        {
            //        CuentaAzure =
            //        CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=sipsoftalmacenamiento;" +
            //        "AccountKey=kCsgLy0KJq/mAnmkPL/wo8squtKGPiGM/eFzX45EpocRQn0LoEygUsl1NB/zM5KaZBo5mu+4bzm2APQezjDeSw==");

            //tableClient = CuentaAzure.CreateCloudTableClient();
            //table = tableClient.GetTableReference("Cliente");
            //table.CreateIfNotExistsAsync();

            RetainInstance = true;
        }

        //public override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);

        //    // Create your fragment here
        //}


        class ClienteEntity : TableEntity
        {
            public int idEmisor { get; set; }
            public string Rfc { get; set; }
            public string Nombre { get; set; }
            public string Total { get; set; }
            public int Contratados { get; set; }
            public int Disponibles { get; set; }
            public int Emitidos { get; set; }
            public int Cancelados { get; set; }
            public string Image { get; set; }
            public string UltimaFactura { get; set; }
        }

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            view = inflater.Inflate(Resource.Layout.Clientes_view, null);

            Nombre = view.FindViewById<Android.Widget.EditText>(Resource.Id.Nombre);
            //Rfc = view.FindViewById<Android.Widget.EditText>(Resource.Id.Rfc);
            //Total = view.FindViewById<Android.Widget.EditText>(Resource.Id.Total);
            Contratados = view.FindViewById<Android.Widget.EditText>(Resource.Id.Contratados);
            Disponibles = view.FindViewById<Android.Widget.EditText>(Resource.Id.Disponibles);
            Emitidos = view.FindViewById<Android.Widget.EditText>(Resource.Id.Emitidos);
            Cancelados = view.FindViewById<Android.Widget.EditText>(Resource.Id.Cancelados);
            UltimaFactura = view.FindViewById<Android.Widget.EditText>(Resource.Id.Ultima);
            Registrar = view.FindViewById<Android.Widget.Button>(Resource.Id.btnInsertar);

            Registrar.Click += Registrar_Click;

            return view;
        }

        private void Registrar_Click(object sender, System.EventArgs e)
        {
            try
            {
                CuentaAzure =
                        CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=sipsoftalmacenamiento;" +
                        "AccountKey=kCsgLy0KJq/mAnmkPL/wo8squtKGPiGM/eFzX45EpocRQn0LoEygUsl1NB/zM5KaZBo5mu+4bzm2APQezjDeSw==");

                tableClient = CuentaAzure.CreateCloudTableClient();
                table = tableClient.GetTableReference("Cliente");
                table.CreateIfNotExistsAsync();

                ClienteEntity cliente = new ClienteEntity();
                cliente.Contratados = int.Parse(Contratados.Text);
                cliente.Emitidos = int.Parse(Emitidos.Text);
                cliente.Cancelados = int.Parse(Cancelados.Text);
                cliente.Disponibles = int.Parse(Disponibles.Text);
                cliente.Total = "$5,664,56";
                cliente.UltimaFactura = UltimaFactura.Text;
                cliente.Nombre = Nombre.Text;
                cliente.Rfc = "MASJ7834TGHE6";
                cliente.Image = "Prueba";

                TableOperation insertar = TableOperation.Insert(cliente);
                table.ExecuteAsync(insertar);

                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(view.Context);

                builder.SetMessage("Datos Guardados!");
                builder.SetTitle("Aviso");
                builder.Create().Show();

                //Android.Widget.Toast.MakeText(view.Context, "Se inserto el cliente!", Android.Widget.ToastLength.Short).Show();
            }
            catch (System.Exception ex)
            {
                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(view.Context);

                builder.SetMessage(ex.ToString());
                builder.SetTitle("Error");
                builder.Create().Show();

                //Android.Widget.Toast.MakeText(view.Context, ex.ToString(), Android.Widget.ToastLength.Short).Show();
            }
        }

    }
}