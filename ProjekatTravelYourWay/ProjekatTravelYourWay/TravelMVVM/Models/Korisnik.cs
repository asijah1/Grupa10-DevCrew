using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTravelYourWay.TravelMVVM.Models
{
    public class Korisnik : Osoba
    {
        public Korisnik(string ime, string prezime, DateTime datumRodjenja, string drzava, string email, string korisnickoIme, string sifra) : base(ime, prezime, datumRodjenja, drzava, email, korisnickoIme, sifra)
        {
        }

        public Korisnik()
        {

        }

        public void prijaviDogadjaj()
        {

        }

    }
}
