using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelYourWay.Models
{
    public class Dogadjaji
    {
        [Required, Range(1, 999999), Key]
        public int id { get; set; }

        [Required, StringLength(15)]
        [DisplayName("Naziv dogadjaja")]
        private string naziv { get; set; }

        [Required]
        [DisplayName("Datum odrzavanja dogadjaja")]
        private DateTime datumOdrzavanja { get; set; }

        [Required]
        [DisplayName("Vrijeme trajanja dogadjaja(u danima)")]
        private int vrijemeTrajanja { get; set; }

        [Required, StringLength(15)]
        [DisplayName("Mjesto odrzavanja dogadjaja")]
        private string mjesto { get; set; }

        [Range(0, 999), Required]
        [DisplayName("Broj slobodnih mjesta")]
        private int brojSlobodnihMjesta { get; set; }

        [Required, StringLength(15)]
        [DisplayName("Naziv agencije")]
        private string nazivAgencije { get; set; }

        [Required]
        private int dogadjajiId { get; set; }

        public Dogadjaji(int id, string naziv, DateTime datumOdrzavanja, int vrijemeTrajanja, string mjesto, int brojSlobodnihMjesta, string nazivAgencije, int dogadjajiId)
        {
            this.id = id;
            this.naziv = naziv;
            this.datumOdrzavanja = datumOdrzavanja;
            this.vrijemeTrajanja = vrijemeTrajanja;
            this.mjesto = mjesto;
            this.brojSlobodnihMjesta = brojSlobodnihMjesta;
            this.nazivAgencije = nazivAgencije;
            this.dogadjajiId = dogadjajiId;
        }

        public Dogadjaji() { }

        public virtual ICollection<PrijavaNaDogadjaj> PrijavaNaDogadjaj { get; set; }
        public virtual Agencija agencija { get; set; }
       
    }
}