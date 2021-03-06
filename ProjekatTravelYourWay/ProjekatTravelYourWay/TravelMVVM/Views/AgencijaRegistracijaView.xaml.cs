﻿using System;
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
using ProjekatTravelYourWay.TravelMVVM.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatTravelYourWay.TravelMVVM.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AgencijaRegistracijaView : Page
    {
        public AgencijaRegistracijaView()
        {
            this.InitializeComponent();
            //staviti da se vidi back
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }

        //prosljedjivanje parametra pri navigaciji. KorisnikStartViewModel je bio proslijedjen pa se ovdje stavlja za DataContext
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (AgencijaRegistracijaViewModel)e.Parameter;
        }

        //ako se klikne back, onda idi nazad a Frame ce da odredi ko je bio prije
        //ako je view cashiran onda ce se otvoriti a ako nije onda ce se kreirati pa otvoriti
        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }


    }
}
