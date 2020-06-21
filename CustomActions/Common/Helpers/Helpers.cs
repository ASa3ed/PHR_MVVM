using System;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace CustomActions.Common
{
    public static class Helpers
    {
        public async static void OpenPage(Page mypage, Page pageToOpen)
        {
            try
            {
                bool isDuplicated = false;
                if (mypage.Navigation.NavigationStack.Count > 0)
                {
                    isDuplicated = pageToOpen.GetType().Name == mypage.Navigation.NavigationStack[mypage.Navigation.NavigationStack.Count - 1].GetType().Name;
                }
                if (!isDuplicated)
                {
                    if (mypage.GetType().Name != "HomePage")
                    {
                        mypage.Navigation.InsertPageBefore(pageToOpen, mypage);
                        await mypage.Navigation.PopAsync(false);
                    }
                    else
                    {
                        await mypage.Navigation.PushAsync(pageToOpen);
                    }
                }
            }
            catch (Exception e)
            {
             
            }
        }

        public static bool IfTypeOfPageExists(Page page)
        {
            bool isDuplicated=false;
            try
            {
                if (page.Navigation.NavigationStack.Count > 0)
                {
                    isDuplicated = page.GetType().Name == page.Navigation.NavigationStack[page.Navigation.NavigationStack.Count - 1].GetType().Name;
                }
            }
            catch (Exception e)
            {

            }
            return isDuplicated;
        }
        public  static bool CheckNetworkConnection()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                // Register for connectivity changes, be sure to unsubscribe when finished
                Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
                //Local and internet access.
                if (current == NetworkAccess.Internet)
                {
                    // Connection to internet is available
                    return true;
                }
                /*Limited internet access.Indicates captive portal connectivity, 
                  where local access to a web portal is provided, 
                  but access to the Internet requires that specific credentials are provided via a portal.*/
                else if (current == NetworkAccess.ConstrainedInternet)
                {
                    return false;
                }
                //Local network access only
                else if (current == NetworkAccess.Local)
                {
                    return true;
                }
                //No connectivity is available
                else if (current == NetworkAccess.None)
                {
                    return false;
                }
                //Unable to determine internet connectivity
                else if (current == NetworkAccess.Unknown)
                {
                    return false;
                }
                return false;
                #region XAM
                //if (CrossConnectivity.Current.IsConnected)
                //return true;
                //else
                //    return false;//show loader 
                #endregion
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        static void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var access = e.NetworkAccess;
            var profiles = e.ConnectionProfiles;
        }
    }
}
