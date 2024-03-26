using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App3
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var deviceFamily = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;
            tb1.Text = deviceFamily + Environment.NewLine;
            string localIp = GetFirstLocalIp();
            if (localIp != null)
            {
                tb1.Text += "Local IP: " + localIp;
            }
        }
        public static string GetFirstLocalIp(HostNameType hostNameType = HostNameType.Ipv4)
        {
            var icp = NetworkInformation.GetInternetConnectionProfile();
            if (icp?.NetworkAdapter == null) return null;
            var hostname = 
                NetworkInformation.GetHostNames()
                .FirstOrDefault(
                    hn=>
                        hn.Type== hostNameType &&
                        hn.IPInformation?.NetworkAdapter != null &
                        hn.IPInformation.NetworkAdapter.NetworkAdapterId == icp.NetworkAdapter.NetworkAdapterId);
            return hostname?.CanonicalName;
        }
    }
}
