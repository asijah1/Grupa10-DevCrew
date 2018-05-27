using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelYourWay.Models
{
    public abstract class Osoba
    {
        [Required, Range(1,9999999), Key]
        public int id { get; set; }

        [Required, StringLength(15)]
        [DisplayName("Ime korisnika")]
        private string ime { get; set; }

        [Required, StringLength(15)]
        [DisplayName("Prezime korisnika")]
        private string prezime { get; set; }

        [Required]
        [DisplayName("Datum rodjenja korisnika")]
        private DateTime datumRodjenja { get; set; }

        [Required, StringLength(30)]
        [DisplayName("Drzava prebivalista korisnika")]
        private string drzava { get; set; }

        [Required, StringLength(35)]
        [DisplayName("Email korisnika")]
        private string email { get; set; }

        [Required, StringLength(15)]
        [DisplayName("Korisnicko ime korisnika")]
        private string korisnickoIme { get; set; }

        [Required, StringLength(15)]
        [DisplayName("Sifra korisnika")]
        private string sifra { get; set; }

        public string ImePrezime { get { return string.Format("{0} {1}", ime, prezime); } }

        protected Osoba(string ime, string prezime, DateTime datumRodjenja, string drzava, string email, string korisnickoIme, string sifra, int id)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.drzava = drzava;
            this.email = email;
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
            this.id = id;
        }

        public Osoba() { }

    }
}