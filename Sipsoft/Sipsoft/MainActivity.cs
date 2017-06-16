using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Plugin.Connectivity;

namespace Sipsoft
{
    [Activity(Label = "Sipsoft", MainLauncher = true, Icon = "@drawable/sipsoft")]
    public class MainActivity : Activity
    {
        Button btn_facebook, btn_microsoft, btn_twiter;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            btn_facebook = FindViewById<Button>(Resource.Id.buttonLoginUserF);
            btn_microsoft = FindViewById<Button>(Resource.Id.buttonLoginUserM);
            btn_twiter = FindViewById<Button>(Resource.Id.buttonLoginUserT);

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChange;

            btn_facebook.Click += Btn_facebook_Click;
            btn_microsoft.Click += Btn_microsoft_Click;
            btn_twiter.Click += Btn_twiter_Click;
        }

        private void Btn_twiter_Click(object sender, System.EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var intent = new Intent(this, typeof(PrincipalActivity));
                intent.PutExtra("User", "juan.tec@live.com.mx");
                intent.PutExtra("Nombre", "Juan Magaña");
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "No hay conexión a Internet", ToastLength.Long).Show();
            }
        }

        private void Btn_microsoft_Click(object sender, System.EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var intent = new Intent(this, typeof(PrincipalActivity));
                intent.PutExtra("User", "juan.tec@live.com.mx");
                intent.PutExtra("Nombre", "Juan Magaña");
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "No hay conexión a Internet", ToastLength.Long).Show();
            }

        }

        private void Btn_facebook_Click(object sender, System.EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var intent = new Intent(this, typeof(PrincipalActivity));
                intent.PutExtra("User", "juan.tec@live.com.mx");
                intent.PutExtra("Nombre", "Juan Magaña");
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "No hay conexión a Internet", ToastLength.Long).Show();
            }
        }

        private void Current_ConnectivityChange(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Toast.MakeText(this, "Conectado a Internet", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "No hay conexión a Internet", ToastLength.Short).Show();
            }
        }
    }
}

