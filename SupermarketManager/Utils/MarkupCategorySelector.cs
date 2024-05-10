using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Utils
{
    public class MarkupCategorySelector
    {
        public static int GetMarkupCategory(decimal price)
        {
            if (price > 0 && price < 50)
            {
                return 0;
            }
            else if (price > 50 && price < 200)
            {
                return 1;
            }
            else if (price > 200 && price < 1000)
            {
                return 2;
            }
            else if (price > 1000)
            {
                return 3;
            }
            else
            {
                return -1;
            }
        }
    }
}
