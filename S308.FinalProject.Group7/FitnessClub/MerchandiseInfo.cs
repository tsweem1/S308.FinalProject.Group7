using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    public class MerchandiseInfo : Member
    {
        public string MerchItem { get; set; }
        public string MerchPrice { get; set; }
        public string Quantity { get; set; }
        public string Size { get; set; }
        public string InStock { get; set; }

        public MerchandiseInfo()
        {

        }

        public MerchandiseInfo(string merchitem, string merchprice, string quantity, string size, string instock)
        {
            MerchItem = merchitem;
            MerchPrice = merchprice;
            Quantity = quantity;
            Size = size;
            InStock = instock;
        }


 }
}
