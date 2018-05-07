using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTravelYourWay.TravelMVVM.Helper;
using Windows.UI.Popups;
using ProjekatTravelYourWay.TravelMVVM.Views;
using ProjekatTravelYourWay.TravelMVVM.Models;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.WindowsAzure.MobileServices;

namespace ProjekatTravelYourWay.TravelMVVM.ViewModels
{
    class AgencijaRegistracijaViewModel : INotifyPropertyChanged
    {
        public AgencijaStartViewModel Parent { get; set; }
        public ICommand RegistracijaAgencije { get; set; }
        public ZahtjevAgencije agencija { get; set; }


        public ZahtjevAgencije Agencija
        {
            get
            {
                return agencija;
            }

            set
            {
                agencija = value;
                OnNotifyPropertyChanged("agencija");
            }
        }

        public AgencijaRegistracijaViewModel(AgencijaStartViewModel parent)
        {
            this.Parent = parent;
            RegistracijaAgencije = new RelayCommand<object>(provjeri);
            Agencija = new ZahtjevAgencije();
            Agencija.ErrorsChanged += Vm_ErrorsChanged;

        }

        public void provjeri(object parametar)
        {
            if (Erori == null)
            {
                registruj();

            }
            else
            {
                if (Erori.Count == 0)
                {

                    registruj();

                }
            }

        }

        public void registruj()
        {
            Agencija a = TravelYourWay.agencije.FirstOrDefault(ag => ag.Naziv == Agencija.Naziv);

            if (a == null)
            {
                TravelYourWay.zahtjeviAgencija.Add(Agencija);

                IMobileServiceTable<ZahtjevAgencije> userTableObjZahtjeviAgencija = App.MobileService.GetTable<ZahtjevAgencije>();

                userTableObjZahtjeviAgencija.InsertAsync(Agencija);

                UspjesnoPoslanZahtjevObavijest();

                Parent.Parent.NavigationService.GoBack();

            }
            else
            {
                NeuspjesnoSlanjeZahtjevaObavijest();
            }


        }

        public async void UspjesnoPoslanZahtjevObavijest()
        {
            // Create the message dialog and set its content
            MessageDialog messageDialog = new MessageDialog("Uspješno poslan zahtjev za registraciju agencije. U roku od 24 sata ćete dobiti obavijest o tome da li je vaš zahtjev za registraciju odobren!");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Shvatam"));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();

        }

        public async void NeuspjesnoSlanjeZahtjevaObavijest()
        {
            // Create the message dialog and set its content
            MessageDialog messageDialog = new MessageDialog("Već postoji agencija sa istim nazivom!");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Pokušaj ponovo"));

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
            Erori = new ObservableCollection<string>(Agencija.Errors.Errors.Values.SelectMany(x => x).ToList());
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
