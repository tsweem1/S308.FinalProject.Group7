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

        public CustomerPaymentInfo(string membershipType, string startDate, string endDate, string addtionalFeatures, string membershipPrice, string totalPrice)
        {
            MembershipType = membershipType;
            StartDate = startDate;
            EndDate = endDate;
            AdditionalFeatures = addtionalFeatures;
            MembershipPrice = membershipPrice;
            TotalPrice = totalPrice;
        }

        public override string ToString()
        {
            string strOutput = "";

            strOutput += "Membership Quote " + Environment.NewLine;
            strOutput += "Membership Type: " + MembershipType + Environment.NewLine;
            strOutput += "Start Date: " + StartDate + Environment.NewLine;
            strOutput += "End Date: " + EndDate + Environment.NewLine;
            strOutput += "Additional Features: " + AdditionalFeatures + Environment.NewLine;
            strOutput += "Membership Price: " + MembershipPrice + Environment.NewLine;
            strOutput += "Total Price: " + TotalPrice + Environment.NewLine;

            return strOutput;
        }
    }
}
