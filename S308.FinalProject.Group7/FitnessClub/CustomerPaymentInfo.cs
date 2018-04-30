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
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string AdditionalFeatures { get; set; }
        public string MembershipPrice { get; set; }
        public string TotalPrice { get; set; }

        public CustomerPaymentInfo()
        {

        }

        public CustomerPaymentInfo(string membershipType, string startDate, string endDate, string addtionalFeatures, string intmembershipPrice, string totalPrice)
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
