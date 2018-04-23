using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    class PriceInformation
    {
        public string Membership { get; set; }
        public string Price { get; set; }

        PriceInformation()
        {

        }

        PriceInformation(string membershipType, string membershipPrice)
        {
            Membership = membershipType;
            Price = membershipPrice;
        }
    }
}
