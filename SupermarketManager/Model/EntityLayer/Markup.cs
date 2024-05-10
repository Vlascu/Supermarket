using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.EntityLayer
{
    public class Markup : BasePropertyChanged
    {
        private int? markupID;
        public int? MarkupID
        {
            get { return markupID; }
            set
            {
                markupID = value;
                NotifyPropertyChanged("MarkupID");
            }
        }

        private int? markupPercentage;
        public int? MarkupPercentage
        {
            get { return markupPercentage; }
            set { markupPercentage = value;
                NotifyPropertyChanged("MarkupPercentage");
            }
        }
        private int? markupCategory;
        public int? MarkupCategory
        {
            get { return markupCategory; }
            set { markupCategory = value;
                NotifyPropertyChanged("MarkupCategory");
            }
        }
    }
}
