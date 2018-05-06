using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTravelYourWay.TravelMVVM.Helper;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ProjekatTravelYourWay.TravelMVVM.ViewModels;
using ProjekatTravelYourWay.TravelMVVM.Views;
using ProjekatTravelYourWay.TravelMVVM.Models;
using Windows.UI.Xaml.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Windows.UI.Core;


namespace ProjekatTravelYourWay.TravelMVVM.ViewModels
{
    class KorisnikStartViewModel : INotifyPropertyChanged
    {
        public PocetakViewModel Parent { get; set; }
        public ICommand Prijava { get; set; }
        public string korisnickoIme { get; set; }
        public string sifra { get; set; }

        public string KorisnickoIme
        {
            get
            {
                return korisnickoIme;
            }

            set
            {
                korisnickoIme = value;
                OnNotifyPropertyChanged("korisnickoIme");
            }
        }

        public string Sifra
        {
            get
            {
                return sifra;
            }

            set
            {
                sifra = value;
                OnNotifyPropertyChanged("sifra");
            }
        }

        public KorisnikStartViewModel(PocetakViewModel parent)
        {
            this.Parent = parent;
            Prijava = new RelayCommand<object>(prijava);
            
        }

        public async void prijava(object parametar)
        {
            if(korisnickoIme == "admin" && sifra == "123")
            {
                // Create the message dialog and set its content
                var messageDialog = new MessageDialog("Sada ste u administrator modu!");

                // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
                messageDialog.Commands.Add(new UICommand("Pristup") { Id = 0});

                messageDialog.Commands.Add(new UICommand("Odustani") { Id = 1 });

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Set the command to be invoked when escape is pressed
                messageDialog.CancelCommandIndex = 1;

                // Show the message dialog
                var result = await messageDialog.ShowAsync();

                if ((int)result.Id == 0)
                {

                    Parent.NavigationService.Navigate(typeof(AdministratorStartView), new AdministratorStartViewModel(this));

                }
                else
                {

                    KorisnickoIme = string.Empty;
                    Sifra = string.Empty;

                }

            } else
            {
                Korisnik korisnik = TravelYourWay.korisnici.FirstOrDefault(k => k.KorisnickoIme.Equals(korisnickoIme));
                if (korisnik != null)
                {
                    if(korisnik.Sifra != Sifra)
                    {
                        NesupjesnaPrijavaObavijest(true, false);

                        KorisnickoIme = string.Empty;
                        Sifra = string.Empty;

                        return;
                    }

                    // Create the message dialog and set its content
                    var messageDialog = new MessageDialog("Prijavljeni ste kao korisnik");

                    // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
                    messageDialog.Commands.Add(new UICommand("Završi"));

                    // Set the command that will be invoked by default
                    messageDialog.DefaultCommandIndex = 0;

                    // Set the command to be invoked when escape is pressed
                    messageDialog.CancelCommandIndex = 1;

                    // Show the message dialog
                    await messageDialog.ShowAsync();

                    Parent.NavigationService.GoBack();

                } else
                {

                    NesupjesnaPrijavaObavijest(false, false);

                    KorisnickoIme = string.Empty;
                    Sifra = string.Empty;

                }

                

            }

        }

        public async void NesupjesnaPrijavaObavijest(bool tacnoIme, bool tacnaSifra)
        {
            // Create the message dialog and set its content
            MessageDialog messageDialog;

            if (!tacnoIme && !tacnaSifra)
            {
                messageDialog = new MessageDialog("Pogrešno korisničko ime ili šifra");

            } else
            {
                messageDialog = new MessageDialog("Pogrešna šifra");
            }

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Pokušaj ponovo"));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();

        }

        //implementacija INotifyPropertyChanged interfejsa koji ova klasa implementira
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

    }
}
