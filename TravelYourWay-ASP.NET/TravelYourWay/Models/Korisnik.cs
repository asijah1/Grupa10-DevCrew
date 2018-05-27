using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelYourWay.Models
{
    public class Korisnik : Osoba
    {
        protected Korisnik(string ime, string prezime, DateTime datumRodjenja, string drzava, string email, string korisnickoIme, string sifra, int id) : base(ime, prezime, datumRodjenja, drzava, email, korisnickoIme, sifra, id)
        {
        }

        public Korisnik() { }

        public virtual ICollection<PrijavaNaDogadjaj> PrijavaNaDogadjaj { get; set; }
    }

    
}