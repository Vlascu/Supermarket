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
                NotifyPropertyChanged("Display");
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
                NotifyPropertyChanged("Display");
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
                NotifyPropertyChanged("Display");
            }
        }
        public string Display
        {
            get { return $"ID: {manufacturerID}  |  Name: {name}  |  Origin: {countryOfOrigin}"; }
        }
    }
}
