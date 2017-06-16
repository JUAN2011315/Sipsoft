using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Series;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.MobileServices;

namespace Sipsoft.Fragments
{
    public class DashBoardFragment : Fragment
    {
        ViewPager viewPager;
        private PlotModel modelP1;
        const string ApplicationURL = @"http://sipsoft.azurewebsites.net";
        MobileServiceClient client;

        public PlotModel Model1
        {
            get { return modelP1; }
            set { modelP1 = value; }
        }

        public DashBoardFragment()
        {
            //CloudStorageAccount CuentaAzure =
            //        CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=sipsoftalmacenamiento;" +
            //        "AccountKey=kCsgLy0KJq/mAnmkPL/wo8squtKGPiGM/eFzX45EpocRQn0LoEygUsl1NB/zM5KaZBo5mu+4bzm2APQezjDeSw==");

            //CloudTableClient tableClient = CuentaAzure.CreateCloudTableClient();
            //CloudTable table = tableClient.GetTableReference("Cliente");
            //table.CreateIfNotExistsAsync();

            //ClienteEntity cliente = new ClienteEntity();
            //cliente.Contratados = 490;
            //cliente.Emitidos = 250;
            //cliente.Cancelados = 58;
            //cliente.Disponibles = 240;
            //cliente.Total = "$6,344,595.00";
            //cliente.UltimaFactura = "14/06/2017";
            //cliente.Nombre = "ELOINA SERRANO";
            //cliente.Rfc = "MASJ901245HR";
            //cliente.Image = "http://facturacion.sipsoft.com.mx/temp/SIPWeb/Produccion/logos/29_0.jpg";

            //cliente.Contratados = 621;
            //cliente.Emitidos = 606;
            //cliente.Cancelados = 173;
            //cliente.Disponibles = 15;
            //cliente.Total = "$5,521,595.00";
            //cliente.UltimaFactura = "14/06/2017";
            //cliente.Nombre = "TADEO LOPEZ TAPIA";
            //cliente.Rfc = "FASJ9012S5HR";
            //cliente.Image = "http://facturacion.sipsoft.com.mx/temp/SIPWeb/Produccion/logos/30_0.jpg";

            //TableOperation insertar = TableOperation.Insert(cliente);
            //table.ExecuteAsync(insertar);
            client = new MobileServiceClient(ApplicationURL);
            RetainInstance = true;
        }


        private PlotModel CreatePlotModel()
        {
            modelP1 = new PlotModel { Title = "Pie Sample1" };

            dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            seriesP1.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            seriesP1.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Asia", 4157) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

            modelP1.Series.Add(seriesP1);

            return modelP1;
        }

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.DashBoard, null);

            PlotView viewPloit = view.FindViewById<PlotView>(Resource.Id.plot_view);
            //Android.Widget.TextView mytextView = view.

            viewPloit.Model = CreatePlotModel();

            return view;
        }

        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    // Use this to return your custom view for this Fragment
        //    // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

        //    return base.OnCreateView(inflater, container, savedInstanceState);
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
    }
}