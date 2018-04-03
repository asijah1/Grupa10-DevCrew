using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using ProjekatTravelYourWay.Helper;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjekatTravelYourWay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public INavigationService nav { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            App.splitViewFrame = MainFrame;

            var currentView = SystemNavigationManager.GetForCurrentView();

            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;

            nav = new NavigationService();
        }



        private void Korisnik_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Korisnik.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 132, 11, 255));
            Korisnik.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 250, 240));
        }

        private void Agencija_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Agencija.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 30, 144, 255));
            Agencija.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 250, 240));
        }

        private void Gost_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Gost.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 240, 128, 128));
            Gost.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 250, 240));
        }

        private void ONama_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            ONama.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 218, 165, 32));
            ONama.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0,0,0));
        }

        private void Korisnik_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Korisnik.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 106, 90, 205));
            Korisnik.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 250, 240));
        }

        private void Agencija_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Agencija.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 205));
            Agencija.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 250, 240));
        }

        private void Gost_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Gost.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 220, 20, 60));
            Gost.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 250, 240));
        }


        private void ONama_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ONama.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 215, 0));
            ONama.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 0));
        }

        private void Korisnik_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Forme.PrijavaKorisnik));
        }

        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if(this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private void Gost_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Forme.MeniGost));
        }

        private void Agencija_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Forme.PrijavaAgencija));
        }
    }
}
