using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Prism.Windows.Validation;
using ProjekatTravelYourWay.TravelMVVM.Helper;

namespace ProjekatTravelYourWay.TravelMVVM.Models
{
    public class Osoba : ValidatableBindableBase
    {

        public Osoba(string ime, string prezime, DateTime datumRodjenja, string drzava, string email, string korisnickoIme, string sifra)
        {
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datumRodjenja;
            Drzava = drzava;
            Email = email;
            KorisnickoIme = korisnickoIme;
            Sifra = sifra;
        }

        public Osoba()
        {

        }

        public string id
        {
            get;
            set;
        }

        private string ime;
        //required polje validacija, potreban je SetProperty
        [Required(ErrorMessage = "Niste unijeli svoje ime")]
        public string Ime
        {
            get { return ime; }
            set { SetProperty(ref ime, value); }
        }

        private string prezime;
        [Required(ErrorMessage = "Niste unijeli svoje prezime")]
        public string Prezime
        {
            get { return prezime; }
            set { SetProperty(ref prezime, value); }
        }

        private DateTime datumRodjenja;
        [BeforeTodayProperty(ErrorMessage = "Neispravan datum rođenja!")]
        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { SetProperty(ref datumRodjenja, value); }
        }

        private string drzava;
        [Required(ErrorMessage = "Niste unijeli državu")]
        public string Drzava
        {
            get { return drzava; }
            set { SetProperty(ref drzava, value); }
        }

        private string email;
        //required polje validacija, potreban je SetProperty
        [Required(ErrorMessage = "Niste unijeli email"), RegularExpressionMail(ErrorMessage = "Pogrešan email!")]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string korisnickoIme;
        //required polje validacija, potreban je SetProperty
        [Required(ErrorMessage = "Niste unijeli korisničko ime")]
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { SetProperty(ref korisnickoIme, value); }
        }

        private string sifra;
        //required polje validacija, potreban je SetProperty
        [Required(ErrorMessage = "Niste unijeli šifru!"), RegularExpressionPass(ErrorMessage = "Šifra mora biti duga barem 6 karaktera!")]
        public string Sifra
        {
            get { return sifra; }
            set { SetProperty(ref sifra, value); }
        }



    }
}
