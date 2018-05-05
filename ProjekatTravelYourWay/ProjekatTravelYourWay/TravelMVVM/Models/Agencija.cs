using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Prism.Windows.Validation;
using ProjekatTravelYourWay.TravelMVVM.Helper;

//Tools -> NuGet Package Manager -> Console

//Install-Package Prism.Windows -Version 6.3.0

namespace ProjekatTravelYourWay.TravelMVVM.Models
{
    class Agencija : ValidatableBindableBase
    {

        private string naziv;
        //required polje validacija, potreban je SetProperty
        [Required(ErrorMessage = "Niste unijeli naziv agencije")]
        public string Naziv
        {
            get { return naziv; }
            set { SetProperty(ref naziv, value); }
        }

        private DateTime datumOsnivanja;
        //Custom definirana Validacija uklasi LaterThanTodayPropertyAttribute
        [BeforeTodayProperty(ErrorMessage = "Datum osnivanja ne može biti u budućnosti")]
        public DateTime DatumOsnivanja
        {
            get { return datumOsnivanja; }
            set { SetProperty(ref datumOsnivanja, value); }
        }

        private string sjediste;
        //required polje validacija, potreban je SetProperty
        [Required(ErrorMessage = "Niste unijeli sjedište agencije")]
        public string Sjediste
        {
            get { return sjediste; }
            set { SetProperty(ref sjediste, value); }
        }

        private string email;
        //required polje validacija, potreban je SetProperty
        [Required(ErrorMessage = "Niste unijeli email agencije"), RegularExpressionMail(ErrorMessage = "Pogrešan email!")]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        
        private string sifra;
        [Required(ErrorMessage = "Niste unijeli šifru!"), RegularExpressionPass(ErrorMessage = "Šifra mora biti duga barem 6 karaktera!")]
        public string Sifra
        {
            get { return sifra; }
            set { SetProperty(ref sifra, value); }
        }

        public void dodajDogadjaj()
        {



        }

    }
}
