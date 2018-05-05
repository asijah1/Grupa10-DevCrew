using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatTravelYourWay.TravelMVVM.Helper;
using System.Windows.Input;
using ProjekatTravelYourWay.TravelMVVM.Views;

namespace ProjekatTravelYourWay.TravelMVVM.ViewModels
{
    class PocetakViewModel
    {
        //Servis za navigaciju koji će preći na druge forme po potrebi
        public INavigationService NavigationService { get; set; }
        //Komande koje realiziraju Binding Korisnik, Agencija i Gost
        public ICommand Korisnik { get; set; }
        public ICommand Agencija { get; set; }
        public ICommand Gost { get; set; }

        public PocetakViewModel()
        {
            NavigationService = new NavigationService();
            //prvi parametar funkcija koja se pozove na klik a druga funkcija koja testira da li se treba pozvati komanda
            Korisnik = new RelayCommand<object>(meniKorisnik);
            Agencija = new RelayCommand<object>(meniAgencija);
            Gost = new RelayCommand<object>(meniGost);

        }

        public void meniKorisnik(object parametar)
        {
            //prebacuje na sljedeci view i proslijedjuje viewmodel za taj view, koji ima ovaj view (this) kao Parent
            NavigationService.Navigate(typeof(KorisnikStartView), new KorisnikStartViewModel(this));
        }

        public void meniAgencija(object parametar)
        {
            //prebacuje na sljedeci view i proslijedjuje viewmodel za taj view, koji ima ovaj view (this) kao Parent
            NavigationService.Navigate(typeof(AgencijaStartView), new AgencijaStartViewModel(this));
        }

        public void meniGost(object parametar)
        {
            //prebacuje na sljedeci view i proslijedjuje viewmodel za taj view, koji ima ovaj view (this) kao Parent
            NavigationService.Navigate(typeof(GostStartView), new GostStartViewModel(this));
        }


    }
}
