using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjekatTravelYourWay.TravelMVVM.Helper
{
    class RegularExpressionPass : ValidationAttribute
    {

        public RegularExpressionPass()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext obj)
        {
            //value je vrijednost koja se validira
            if (value == null)
            {
                //u konstruktor ide sta ce se ispisati ako faila validacija. ErrorMessage je postavljen pri definiranju anotacije nad poljem
                return new ValidationResult(this.ErrorMessage);
            }

            //Sve sto je starije od sadasnjeg vremena nije validno
            string checkPass = (string)value;

            if (checkPass.Length < 6)
            {
                return new ValidationResult(this.ErrorMessage);
            }
            //Ako nema problema dosad sve je Ok
            return ValidationResult.Success;
        }

    }
}
