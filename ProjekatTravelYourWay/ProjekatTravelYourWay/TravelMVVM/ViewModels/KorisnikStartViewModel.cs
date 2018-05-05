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

namespace ProjekatTravelYourWay.TravelMVVM.ViewModels
{
    class KorisnikStartViewModel
    {
        public PocetakViewModel Parent { get; set; }
        public ICommand Prijava { get; set; }
        public string korisnickoIme { get; set; }
        public string sifra { get; set; }


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
                var messageDialog = new MessageDialog("Prijavljeni ste kao administrator");

                // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
                messageDialog.Commands.Add(new UICommand("Ok"));

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Set the command to be invoked when escape is pressed
                messageDialog.CancelCommandIndex = 1;

                // Show the message dialog
                await messageDialog.ShowAsync();

            } else
            {

                // Create the message dialog and set its content
                var messageDialog = new MessageDialog("Prijavljeni ste kao korisnik");

                // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
                messageDialog.Commands.Add(new UICommand("Ok"));

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Set the command to be invoked when escape is pressed
                messageDialog.CancelCommandIndex = 1;

                // Show the message dialog
                await messageDialog.ShowAsync();

                Parent.NavigationService.GoBack();

            }

        }

    }
}
