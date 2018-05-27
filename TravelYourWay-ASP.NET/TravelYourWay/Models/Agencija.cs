using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelYourWay.Models
{
    public class Agencija
    {
        //ovdje je javljalo određenu grešku, pa sam morao da koristim Column()
        [ScaffoldColumn(false), Range(1, 99999), Column("agencijaId")]
        public int id { get; set; }

        [Required, StringLength(15)]
        [DisplayName("Naziv agencije")]
        private string naziv { get; set; }

        [Required]
        [DisplayName("Datum osnivanja agencije")]
        private DateTime datumOsnivanja { get; set; }

        [Required, StringLength(15)]
        [DisplayName("Sjediste agencije")]
        private string sjediste { get; set; }

        [Required, StringLength(35)]
        [DisplayName("Email agencije")]
        private string email { get; set; }

        [Required, StringLength(15)]
        private string sifra { get; set; }

        public Agencija(string naziv, DateTime datumOsnivanja, string sjediste, string email, string sifra, int agencijaId)
        {
            this.naziv = naziv;
            this.datumOsnivanja = datumOsnivanja;
            this.sjediste = sjediste;
            this.email = email;
            this.sifra = sifra;
            this.id = agencijaId;
        }

        public Agencija() { }
        
    }
}