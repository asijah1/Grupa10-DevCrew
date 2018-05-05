using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTravelYourWay.TravelMVVM.Helper;
using Windows.UI.Popups;
using ProjekatTravelYourWay.TravelMVVM.Views;

namespace ProjekatTravelYourWay.TravelMVVM.ViewModels
{
    class AgencijaRegistracijaViewModel
    {
        public AgencijaStartViewModel Parent { get; set; }
        public ICommand RegistracijaAgencije { get; set; }

        public AgencijaRegistracijaViewModel(AgencijaStartViewModel parent)
        {
            this.Parent = parent;
            RegistracijaAgencije = new RelayCommand<object>(registracija);
        }

        public async void registracija(object parametar)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog("Uspješna registracija agencije");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Ok"));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();

        }



    }
}
