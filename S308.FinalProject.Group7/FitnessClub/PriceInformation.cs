using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace FitnessClub
{
    public class PriceInformation
    {   //1. Set properties
        public string Membership { get; set; }
        public string Price { get; set; }
        public string Availability { get; set; }

        public PriceInformation()
        {

        }
        //2. Create constructors
        public PriceInformation(string membershipType, string membershipPrice, string avaliability)
        {
            Membership = membershipType;
            Price = membershipPrice;
            Availability = avaliability;
        }
    }
}
