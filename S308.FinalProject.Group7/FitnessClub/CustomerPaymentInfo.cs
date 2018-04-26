using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    public class CustomerPaymentInfo
    {
        public string MembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<String> AdditionalFeatures { get; set; }
        public int MembershipPrice { get; set; }
        public int TotalPrice { get; set; }

        public CustomerPaymentInfo()
        {

        }

        public CustomerPaymentInfo(string membershipType, DateTime startDate, DateTime endDate, List<String> addtionalFeatures, int intmembershipPrice, int totalPrice)
        {
            MembershipType = membershipType;
            StartDate = startDate;
            EndDate = endDate;
            AdditionalFeatures = AdditionalFeatures;
            MembershipPrice = MembershipPrice;
            TotalPrice = totalPrice;
        }
    }
}
