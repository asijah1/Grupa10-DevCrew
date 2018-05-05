using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTravelYourWay.TravelMVVM.Models
{
    class TravelYourWay
    {
        private List<Agencija> agencije;
        private List<Korisnik> korisnici;
        private List<Dogadjaj> dogadjaji;

        public List<Agencija> Agencije
        {
            get
            {
                return agencije;
            }

            set
            {
                agencije = value;
            }
        }

        public List<Korisnik> Korisnici
        {
            get
            {
                return korisnici;
            }

            set
            {
                korisnici = value;
            }
        }

        public List<Dogadjaj> Dogadjaji
        {
            get
            {
                return dogadjaji;
            }

            set
            {
                dogadjaji = value;
            }
        }


    }
}
