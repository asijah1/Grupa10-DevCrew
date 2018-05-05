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
    class Dogadjaj : ValidatableBindableBase
    {
        private static int ID = 1;

        public Dogadjaj()
        {
            id = ID;
            ID += 1;
        }


        private int id;
        public int Id
        {
            get { return id; }
        }

        private string naziv;
        [Required(ErrorMessage = "Niste unijeli naziv dogadjaja")]
        public string Naziv
        {
            get { return naziv; }
            set { SetProperty(ref naziv, value); }
        }

        private DateTime datumOdrzavanja;
        [AfterTodayProperty(ErrorMessage = "Neispravan datum održavanja!")]
        public DateTime DatumOdrzavanja
        {
            get { return datumOdrzavanja; }
            set { SetProperty(ref datumOdrzavanja, value); }
        }

        private int vrijemeTrajanja;
        [Required(ErrorMessage = "Niste unijeli vrijeme trajanja dogadjaja"), RegularExpression(@"\d{1,5}", ErrorMessage = "Neispravno vrijeme trajanja")]
        public int VrijemeTrajanja
        {
            get { return vrijemeTrajanja; }
            set { SetProperty(ref vrijemeTrajanja, value); }
        }

        private string mjesto;
        [Required(ErrorMessage = "Niste unijeli mjesto dogadjaja")]
        public string Mjesto
        {
            get { return mjesto; }
            set { SetProperty(ref mjesto, value); }
        }

        private int brojSlobodnihMjesta;
        [Required(ErrorMessage = "Niste unijeli broj slobodnih mjesta"), RegularExpression(@"\d{1,5}", ErrorMessage = "Neispravan broj slobodnih mjesta")]
        public int BrojSlobodnihMjesta
        {
            get { return brojSlobodnihMjesta; }
            set { SetProperty(ref brojSlobodnihMjesta, value); }
        }

        private string nazivAgencije;
        [Required(ErrorMessage = "Niste unijeli naziv Agencije")]
        public string NazivAgencije
        {
            get { return nazivAgencije; }
            set { SetProperty(ref nazivAgencije, value); }
        }






    }
}
