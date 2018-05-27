using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelYourWay.Models
{
    public class Administrator : Osoba
    {
        protected Administrator(string ime, string prezime, DateTime datumRodjenja, string drzava, string email, string korisnickoIme, string sifra, int id) : base(ime, prezime, datumRodjenja, drzava, email, korisnickoIme, sifra, id)
        {
        }

        public Administrator() { }

        public void obrisiKorisnika(Korisnik korisnik) { }

        public void obrisiAgenciju(Agencija agencija) { }

        public void dodajAgenciju(Agencija agencija) { }

    }
}