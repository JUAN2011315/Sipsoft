using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

using Sipsoft.Fragments;
using Plugin.Connectivity;

namespace Sipsoft
{
    [Activity(Label = "PrincipalActivity")]
    public class PrincipalActivity : BaseActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        IMenuItem previousItem;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.activity_main;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            
            //FindViewById<Android.Widget.TextView>(Resource.Id.username).Text = 
            Android.Widget.Toast.MakeText(this, Intent.GetStringExtra("Nombre"), Android.Widget.ToastLength.Long).Show();
            

            navigationView.NavigationItemSelected += NavigationItemSelected_Click;
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChange;

            if (savedInstanceState == null)
            {
                navigationView.SetCheckedItem(Resource.Id.nav_home);
            }

            ListItemClicked(0);
        }

        private void NavigationItemSelected_Click(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            if (previousItem != null)
                previousItem.SetChecked(false);

            navigationView.SetCheckedItem(e.MenuItem.ItemId);

            previousItem = e.MenuItem;

            switch (e.MenuItem.ItemId)
            {
                case Resource.Id.nav_home:
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        ListItemClicked(0);
                    }
                    else
                    {
                        Android.Widget.Toast.MakeText(this, "No hay conexión a Internet", Android.Widget.ToastLength.Short).Show();
                    }
                    break;
                case Resource.Id.nav_clientes:
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        ListItemClicked(1);
                    }
                    else
                    {
                        Android.Widget.Toast.MakeText(this, "No hay conexión a Internet", Android.Widget.ToastLength.Short).Show();
                    }
                    break;
                    //case Resource.Id.nav_friends:
                    //    ListItemClicked(1);
                    //    break;
                    //case Resource.Id.nav_profile:
                    //    ListItemClicked(2);
                    //    break;
            }



            drawerLayout.CloseDrawers();

            //Android.Widget.Toast.MakeText(this, e.MenuItem.ToString(), Android.Widget.ToastLength.Short).Show();
        }

        private void ListItemClicked(int posicion)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (posicion)
            {
                case 0:
                    fragment = new DashBoardFragment();
                    break;
                case 1:
                    fragment = new ClientesFragment();
                    break;
            }

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.main_content, fragment)
                .Commit();
        }

        private void Current_ConnectivityChange(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Android.Widget.Toast.MakeText(this, "Conectado a Internet", Android.Widget.ToastLength.Short).Show();
            }
            else
            {
                Android.Widget.Toast.MakeText(this, "No hay conexión a Internet", Android.Widget.ToastLength.Short).Show();
            }
        }
    }
}