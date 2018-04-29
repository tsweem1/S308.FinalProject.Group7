using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    public class MerchandiseInfo : Member
    {
        public string Items { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }

        public MerchandiseInfo()
        {

        }

        public MerchandiseInfo(string items, double itemprice, int quantity, string size)
        {
            Items = items;
            ItemPrice = itemprice;
            Quantity = quantity;
            Size = size;
        }


 }
}
