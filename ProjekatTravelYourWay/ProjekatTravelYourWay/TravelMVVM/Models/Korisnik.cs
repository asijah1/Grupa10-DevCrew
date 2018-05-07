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

        public Korisnik(Korisnik k)
        {
            id = k.id;
            Ime = k.Ime;
            Prezime = k.Prezime;
            DatumRodjenja = k.DatumRodjenja;
            Drzava = k.Drzava;
            Email = k.Email;
            KorisnickoIme = k.KorisnickoIme;
            Sifra = k.Sifra;

        }

        public void prijaviDogadjaj()
        {

        }

    }
}
