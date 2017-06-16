using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace Sipsoft.Services
{
    public class ServiceHelper
    {
        const string ApplicationURL = @"http://sipsoft.azurewebsites.net";
        MobileServiceClient client;
        Activity _Activity;

        public ServiceHelper(Activity activity)
        {
            _Activity = activity;
            CurrentPlatform.Init();
            client = new MobileServiceClient(ApplicationURL);
        }

        #region Metodos para lanzar Alerts Dialogs
        public void CreateAndShowDialog(Exception exception, String title)
        {
            CreateAndShowDialog(exception.Message, title);
        }

        public void CreateAndShowDialog(string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(_Activity);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }
        #endregion

        // Define a authenticated user.
        private MobileServiceUser user;
        //public async Task<bool> Authenticate(int RedSocial)
        //{
        //    /*
        //     0 Microsoft Account
        //     1 Google 
        //     2 Twiter
        //     3 Facebook
        //     4 Activedirectory
        //     */

        //    var success = false;
        //    try
        //    {

        //        // Sign in with Facebook login using a server-managed flow.
        //        switch (RedSocial)
        //        {
        //            case 0:
        //                user = await client.LoginAsync(_Activity, MobileServiceAuthenticationProvider.MicrosoftAccount);
        //                break;
        //            case 1:
        //                user = await client.LoginAsync(_Activity, MobileServiceAuthenticationProvider.Google);
        //                break;
        //            case 2:
        //                user = await client.LoginAsync(_Activity, MobileServiceAuthenticationProvider.Twitter);
        //                break;
        //            case 3:
        //                user = await client.LoginAsync(_Activity, MobileServiceAuthenticationProvider.Facebook);
        //                break;
        //            case 4:
        //                user = await client.LoginAsync(_Activity, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
        //                break;
        //        }

        //        CreateAndShowDialog(string.Format("Estas logeado con el ID - {0}", user.UserId), "Login");

        //        success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //CreateAndShowDialog(ex, "Authentication failed");
        //    }
        //    return success;
        //}

        //public async void LoginUserMicrosoft(View view)
        //{
        //    // Load data only after authentication succeeds.
        //    if (await Authenticate(0))
        //    {
        //        //Hide the button after authentication succeeds.
        //        _Activity.FindViewById<Button>(Resource.Id.buttonLoginUserM).Visibility = ViewStates.Gone;

        //        // Load the data.
        //        //OnRefreshItemsSelected();
        //    }
        //}

        //public async void LoginUserGoogle(View view)
        //{
        //    // Load data only after authentication succeeds.
        //    if (await Authenticate(1))
        //    {
        //        //Hide the button after authentication succeeds.
        //        _Activity.FindViewById<Button>(Resource.Id.buttonLoginUserG).Visibility = ViewStates.Gone;

        //        // Load the data.
        //        //OnRefreshItemsSelected();
        //    }
        //}

        //public async void LoginUserTwiter(View view)
        //{
        //    // Load data only after authentication succeeds.
        //    if (await Authenticate(2))
        //    {
        //        //Hide the button after authentication succeeds.
        //        _Activity.FindViewById<Button>(Resource.Id.buttonLoginUserT).Visibility = ViewStates.Gone;

        //        // Load the data.
        //        //OnRefreshItemsSelected();
        //    }
        //}

        //public async void LoginUserFacebook(View view)
        //{
        //    // Load data only after authentication succeeds.
        //    if (await Authenticate(3))
        //    {
        //        //Hide the button after authentication succeeds.
        //        _Activity.FindViewById<Button>(Resource.Id.buttonLoginUserF).Visibility = ViewStates.Gone;

        //        // Load the data.
        //        //OnRefreshItemsSelected();
        //    }
        //}

        //public async void LoginUserActiveDirectory(View view)
        //{
        //    // Load data only after authentication succeeds.
        //    if (await Authenticate(4))
        //    {
        //        //Hide the button after authentication succeeds.
        //        _Activity.FindViewById<Button>(Resource.Id.buttonLoginUserA).Visibility = ViewStates.Gone;

        //        // Load the data.
        //        //OnRefreshItemsSelected();
        //    }
        //}
    }
}