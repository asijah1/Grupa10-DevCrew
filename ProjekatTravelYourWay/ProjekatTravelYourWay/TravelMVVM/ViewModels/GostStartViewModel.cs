using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTravelYourWay.TravelMVVM.Helper;
using Windows.UI.Popups;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProjekatTravelYourWay.TravelMVVM.Models;
using Microsoft.WindowsAzure.MobileServices;


namespace ProjekatTravelYourWay.TravelMVVM.ViewModels
{
    class GostStartViewModel : INotifyPropertyChanged
    {
        public PocetakViewModel Parent { get; set; }
        public ICommand Registracija { get; set; }
        public Korisnik korisnik { get; set; }

        public Korisnik Korisnik
        {
            get
            {
                return korisnik;
            }

            set
            {
                korisnik = value;
                OnNotifyPropertyChanged("korisnik");
            }
        }

        public GostStartViewModel(PocetakViewModel parent)
        {
            this.Parent = parent;
            Registracija = new RelayCommand<object>(Provjeri);
            Korisnik = new Korisnik();
            Korisnik.ErrorsChanged += Vm_ErrorsChanged;
        }

        public void Provjeri(object parametar)
        {
            if(Erori == null)
            {
                registruj();

            } else
            {
                if (Erori.Count == 0)
                {

                    registruj();

                }
            }
        }

        public void registruj()
        {
            Korisnik k = TravelYourWay.korisnici.FirstOrDefault(kor => kor.KorisnickoIme == Korisnik.KorisnickoIme);

            if (k == null)
            {
                TravelYourWay.korisnici.Add(Korisnik);

                IMobileServiceTable<Korisnik> userTableObjKorisnici = App.MobileService.GetTable<Korisnik>();

                userTableObjKorisnici.InsertAsync(Korisnik);

                UspjesnaRegistracijaObavijest();

                Parent.NavigationService.GoBack();

            }
            else
            {
                NeuspjesnaRegistracijaObavijest();
            }
        }

        public async void NeuspjesnaRegistracijaObavijest()
        {
            // Create the message dialog and set its content
            MessageDialog messageDialog = new MessageDialog("Već postoji korisnik sa takvim korisničkim imenom!");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Pokušaj ponovo"));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();

        }

        public async void UspjesnaRegistracijaObavijest()
        {
            // Create the message dialog and set its content
            MessageDialog messageDialog = new MessageDialog("Uspješno ste registrovani. Možete se prijaviti sa vašim korisničkim imenom i šifrom!");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Shvatam"));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();

        }

        private void Vm_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            //event koji ce se pozvati kad dodje do neispravne validacije
            //daj sve greske i pretvori ih u listu stringova da se mogu ispisati
            Erori = new ObservableCollection<string>(Korisnik.Errors.Errors.Values.SelectMany(x => x).ToList());
        }

        //mora biti observableCollection i pozvati OnNotifyPropertyChanged da bi se primjetila promjena liste da bi view skontao da se mora izmjeniti
        private ObservableCollection<string> erori;
        public ObservableCollection<string> Erori { get { return erori; } set { erori = value; OnNotifyPropertyChanged("Erori"); } }

        //implementacija INotifyPropertyChanged interfejsa koji ova klasa implementira
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }







    }
}
