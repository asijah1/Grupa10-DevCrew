using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTravelYourWay.TravelMVVM.Helper;
using Windows.UI.Popups;
using ProjekatTravelYourWay.TravelMVVM.Views;
using ProjekatTravelYourWay.TravelMVVM.ViewModels;

namespace ProjekatTravelYourWay.TravelMVVM.ViewModels
{
    class AgencijaStartViewModel
    {
        public PocetakViewModel Parent { get; set; }
        public string nazivAgencije { get; set; }
        public string sifra { get; set; }
        public ICommand Prijava { get; set; }
        public ICommand Registracija { get; set; }


        public AgencijaStartViewModel(PocetakViewModel parent)
        {
            this.Parent = parent;
            Prijava = new RelayCommand<object>(prijava);
            Registracija = new RelayCommand<object>(registracija);
        }

        public async void prijava(object parametar)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog("Uspješna prijava agencije");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Ok"));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();

        }

        public void registracija(object parametar)
        {
            Parent.NavigationService.Navigate(typeof(AgencijaRegistracijaView), new AgencijaRegistracijaViewModel(this));
        }


    }
}
