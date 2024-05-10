using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.EntityLayer
{
    public class Manufacturer : BasePropertyChanged
    {
        private int? manufacturerID;
        public int? ManufacturerID
        {
            get { return manufacturerID; }
            set
            {
                manufacturerID = value;
                NotifyPropertyChanged("ManufacturerID");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string countryOfOrigin;
        public string CountryOfOrigin
        {
            get { return countryOfOrigin; }
            set
            {
                countryOfOrigin = value;
                NotifyPropertyChanged("CountryOfOrigin");
            }
        }
    }
}
