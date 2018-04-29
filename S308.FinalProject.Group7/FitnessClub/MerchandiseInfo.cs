using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    public class MerchandiseInfo : Member
    {
        public string Item { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }

        public MerchandiseInfo()
        {

        }

        public MerchandiseInfo(string item, double itemprice, int quantity, string size)
        {
            Item = item;
            ItemPrice = itemprice;
            Quantity = quantity;
            Size = size;
        }


 }
}
