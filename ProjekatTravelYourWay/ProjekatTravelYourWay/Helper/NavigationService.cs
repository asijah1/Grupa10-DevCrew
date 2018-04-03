﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace ProjekatTravelYourWay.Helper
{
    public interface INavigationService
    {
        void Navigate(Type sourcePage);
        void Navigate(Type sourcePage, object parameter);
        void GoBack();
    }
    class NavigationService : INavigationService
    {
        //obicna navigacija bez parametra
        public void Navigate(Type sourcePage)
        {
            App.splitViewFrame.Navigate(sourcePage);
        }
        //navigiranje na page ali da se proslijedi parametar stranici
        public void Navigate(Type sourcePage, object parameter)
        {
            App.splitViewFrame.Navigate(sourcePage, parameter);
        }

        //poziv da se vrati na predhodnu stranicu
        public void GoBack()
        {
            if (App.splitViewFrame.CanGoBack)
                App.splitViewFrame.GoBack();

        }
    }

}
