using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelYourWay.Models
{
    public class PrijavaNaDogadjaj
    {
        [Required, Range(1, 9999999)]
        [DisplayName("Id korisnika")]
        public string korisnikId { get; set; }

        [Required, Range(1, 999999)]
        [DisplayName("Id dogadjaja")]
        public int dogadjajId { get; set; }

        [Required, Range(1,10000)]
        [DisplayName("Id Prijave")]
        public int id { get; set; }

        public virtual Korisnik korisnik { get; set; }
        public virtual Dogadjaji dogadjaj { get; set; }
    }
}