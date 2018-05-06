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
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.ApplicationModel.Contacts;

namespace ProjekatTravelYourWay.TravelMVVM.ViewModels
{
    class AdministratorStartViewModel
    {

        public KorisnikStartViewModel Parent { get; set; }
        public ICommand obrisiAgenciju { get; set; }
        public ICommand obrisiKorisnika { get; set; }
        public ICommand odobriAgenciju { get; set; }

        public List<Agencija> agencije { get; set; }
        public List<Korisnik> korisnici { get; set; }
        public List<Agencija> zahtjeviAgencija { get; set; }

        public Agencija trenutnaAgencija { get; set; }
        public Korisnik trenutniKorisnik { get; set; }
        public Agencija trenutniZahtjevAgencije { get; set; }

        public AdministratorStartViewModel(KorisnikStartViewModel parent)
        {
            this.Parent = parent;
            obrisiAgenciju = new RelayCommand<object>(obrisiAgencijuFun);
            obrisiKorisnika = new RelayCommand<object>(obrisiKorisnikaFun);
            odobriAgenciju = new RelayCommand<object>(odobriAgencijuFun);

            agencije = TravelYourWay.agencije;
            korisnici = TravelYourWay.korisnici;
            zahtjeviAgencija = TravelYourWay.zahtjeviAgencija;

            trenutnaAgencija = new Agencija();
            trenutniKorisnik = new Korisnik();
            trenutniZahtjevAgencije = new Agencija();

        }

        public List<Agencija> Agencije
        {
            get
            {
                return agencije;
            }

            set
            {
                agencije = value;
                OnNotifyPropertyChanged("Agencije");
            }
        }

        public List<Korisnik> Korisnici
        {
            get
            {
                return korisnici;
            }

            set
            {
                korisnici = value;
                OnNotifyPropertyChanged("Korisnici");
            }
        }

        public List<Agencija> ZahtjeviAgencija
        {
            get
            {
                return zahtjeviAgencija;
            }

            set
            {
                zahtjeviAgencija = value;
                OnNotifyPropertyChanged("ZahtjeviAgencija");
            }
        }

        public Agencija TrenutnaAgencija
        {
            get
            {
                return trenutnaAgencija;
            }

            set
            {
                trenutnaAgencija = value;
                OnNotifyPropertyChanged("trenutnaAgencija");
            }
        }

        public Korisnik TrenutniKorisnik
        {
            get
            {
                return trenutniKorisnik;
            }

            set
            {
                trenutniKorisnik = value;
                OnNotifyPropertyChanged("trenutniKorisnik");
            }
        }

        public Agencija TrenutniZahtjevAgencije
        {
            get
            {
                return trenutniZahtjevAgencije;
            }

            set
            {
                trenutniZahtjevAgencije = value;
                OnNotifyPropertyChanged("trenutniZahtjevAgencije");
            }
        }

        public void obrisiAgencijuFun(object parametar)
        {
            Agencija a = Agencije.FirstOrDefault(ag => ag.Naziv == trenutnaAgencija.Naziv);

            if(a != null)
            {
                Agencije.Remove(a);
                TravelYourWay.agencije = agencije;
            }

            TrenutnaAgencija = null;
        }

        public void obrisiKorisnikaFun(object parametar)
        {
            Korisnik k = Korisnici.FirstOrDefault(ko => ko.KorisnickoIme == trenutniKorisnik.KorisnickoIme);

            if(k != null)
            {
                Korisnici.Remove(k);
                TravelYourWay.korisnici = korisnici;
            }

            TrenutniKorisnik = null;
        }

        public void odobriAgencijuFun(object parametar)
        {
            Agencija a = ZahtjeviAgencija.FirstOrDefault(ag => ag.Naziv == trenutniZahtjevAgencije.Naziv);

            if (a != null)
            {
                Agencije.Add(a);
                ZahtjeviAgencija.Remove(a);
                TravelYourWay.agencije = agencije;
                TravelYourWay.zahtjeviAgencija = zahtjeviAgencija;
            }

            Contact contact = new Contact();

            var personalEmail = new Windows.ApplicationModel.Contacts.ContactEmail();
            personalEmail.Address = TrenutniZahtjevAgencije.Email;
            contact.Emails.Add(personalEmail);

            string subject = "Travel Your Way Agency Service";

            string message = "Ovom prilikom Vas obavještavamo da je Vaš zahtjev za registraciju agencije odobren. Ugodno korištenje aplikacije Vam želi naš Admin team.";

            var task = ComposeEmail(contact, subject, message);

            //task.RunSynchronously();

            //TrenutniZahtjevAgencije = null;

        }

        private async Task ComposeEmail(Windows.ApplicationModel.Contacts.Contact recipient, string subject, string messageBody)
        {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            emailMessage.Body = messageBody;

            var email = recipient.Emails.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactEmail>();
            if (email != null)
            {
                var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(email.Address);
                emailMessage.To.Add(emailRecipient);
                emailMessage.Subject = subject;
            }

            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
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
