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
using Microsoft.WindowsAzure.MobileServices;

namespace ProjekatTravelYourWay.TravelMVVM.ViewModels
{
    class AdministratorStartViewModel
    {

        public KorisnikStartViewModel Parent { get; set; }
        public ICommand obrisiAgenciju { get; set; }
        public ICommand obrisiKorisnika { get; set; }
        public ICommand odobriAgenciju { get; set; }

        public ObservableCollection<Agencija> agencije { get; set; }
        public ObservableCollection<Korisnik> korisnici { get; set; }
        public ObservableCollection<ZahtjevAgencije> zahtjeviAgencija { get; set; }

        public Agencija trenutnaAgencija { get; set; }
        public Korisnik trenutniKorisnik { get; set; }
        public ZahtjevAgencije trenutniZahtjevAgencije { get; set; }

        public AdministratorStartViewModel(KorisnikStartViewModel parent)
        {
            this.Parent = parent;
            obrisiAgenciju = new RelayCommand<object>(obrisiAgencijuFun);
            obrisiKorisnika = new RelayCommand<object>(obrisiKorisnikaFun);
            odobriAgenciju = new RelayCommand<object>(odobriAgencijuFun);

            agencije = new ObservableCollection<Agencija>(TravelYourWay.agencije);
            korisnici = new ObservableCollection<Korisnik>(TravelYourWay.korisnici);
            zahtjeviAgencija = new ObservableCollection<ZahtjevAgencije>(TravelYourWay.zahtjeviAgencija);

            trenutnaAgencija = new Agencija();
            trenutniKorisnik = new Korisnik();
            trenutniZahtjevAgencije = new ZahtjevAgencije();

        }

        public ObservableCollection<Agencija> Agencije
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

        public ObservableCollection<Korisnik> Korisnici
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

        public ObservableCollection<ZahtjevAgencije> ZahtjeviAgencija
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
                OnNotifyPropertyChanged("TrenutnaAgencija");
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
                OnNotifyPropertyChanged("TrenutniKorisnik");
            }
        }

        public ZahtjevAgencije TrenutniZahtjevAgencije
        {
            get
            {
                return trenutniZahtjevAgencije;
            }

            set
            {
                trenutniZahtjevAgencije = value;
                OnNotifyPropertyChanged("TrenutniZahtjevAgencije");
            }
        }

        public void obrisiAgencijuFun(object parametar)
        {
            Agencija a = Agencije.FirstOrDefault(ag => ag.Naziv == trenutnaAgencija.Naziv);

            if(a != null)
            {
                IMobileServiceTable<Agencija> userTableObjAgencija = App.MobileService.GetTable<Agencija>();

                Agencija ag = new Agencija(a);

                userTableObjAgencija.DeleteAsync(ag);

                Agencije.Remove(a);
                TravelYourWay.agencije = agencije.ToList();
            }

            //TrenutnaAgencija = null;
        }

        public void obrisiKorisnikaFun(object parametar)
        {
            Korisnik k = Korisnici.FirstOrDefault(ko => ko.KorisnickoIme == trenutniKorisnik.KorisnickoIme);

            if(k != null)
            {
                IMobileServiceTable<Korisnik> userTableObjKorisnik = App.MobileService.GetTable<Korisnik>();

                Korisnik kor = new Korisnik(k);

                userTableObjKorisnik.DeleteAsync(kor);

                Korisnici.Remove(k);
                TravelYourWay.korisnici = korisnici.ToList();
            }

            //TrenutniKorisnik = null;
        }

        public void odobriAgencijuFun(object parametar)
        {
            ZahtjevAgencije a = ZahtjeviAgencija.FirstOrDefault(ag => ag.Naziv == trenutniZahtjevAgencije.Naziv);

            if (a != null)
            {
                

                Contact contact = new Contact();

                var personalEmail = new Windows.ApplicationModel.Contacts.ContactEmail();
                personalEmail.Address = TrenutniZahtjevAgencije.Email;
                contact.Emails.Add(personalEmail);

                string subject = "Travel Your Way Agency Service";

                string message = "Poštovani," + System.Environment.NewLine + System.Environment.NewLine + "Ovom prilikom Vas obavještavamo da je Vaš zahtjev za registraciju agencije \"" + TrenutniZahtjevAgencije.Naziv + "\" odobren. Ugodno korištenje aplikacije Vam želi naš Admin team." + System.Environment.NewLine + System.Environment.NewLine + "Lijep pozdrav," + System.Environment.NewLine + "Travel Your Way";

                var task = ComposeEmail(contact, subject, message);

                //task.RunSynchronously();

                Agencija nova = new Agencija(a);
                ZahtjevAgencije noviZahtjev = new ZahtjevAgencije(a);

                

                IMobileServiceTable<ZahtjevAgencije> userTableObjZahtjeviAgencija = App.MobileService.GetTable<ZahtjevAgencije>();
                IMobileServiceTable<Agencija> userTableObjAgencija = App.MobileService.GetTable<Agencija>();

                userTableObjAgencija.InsertAsync(nova);
                userTableObjZahtjeviAgencija.DeleteAsync(noviZahtjev);

                Agencije.Add(a);
                ZahtjeviAgencija.Remove(a);
                TravelYourWay.agencije = agencije.ToList();
                TravelYourWay.zahtjeviAgencija = zahtjeviAgencija.ToList();

                //TrenutniZahtjevAgencije = null;

            }

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
