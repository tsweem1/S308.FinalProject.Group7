using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    public class MerchandiseInfo
    {
        public List<string> Items { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
        public List<string> Size { get; set; }

        public MerchandiseInfo()
        {

        }

        public MerchandiseInfo(List<String> items, double itemprice, int quantity, List<String> size)
        {
            Items = items;
            ItemPrice = itemprice;
            Quantity = quantity;
            Size = size;
        }


 }
}
