using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatTravelYourWay.TravelMVVM.Helper;
using Windows.UI.Popups;

namespace ProjekatTravelYourWay.TravelMVVM.ViewModels
{
    class GostStartViewModel
    {
        public PocetakViewModel Parent { get; set; }
        public string ime { get; set; }
        public string sifra { get; set; }
        public ICommand Prijava { get; set; }
        public ICommand Registracija { get; set; }

        public GostStartViewModel(PocetakViewModel parent)
        {
            this.Parent = parent;
        }
    }
}
