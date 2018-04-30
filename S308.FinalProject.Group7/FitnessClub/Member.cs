using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    //Add class for member
    public class Member : CustomerPaymentInfo 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Weight { get; set; }
        public string Age { get; set; }
        public string FitnessGoal { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardType { get; set; }
        public string ExpirationDate { get; set; }
        public string BillingAddress { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }


        public Member()
        {

        }

        //Initialize constructor
        public Member(string firstName, string lastName, string gender, string phoneNumber, string email, string weight, string age, string fitnessGoal, string membershipType, string startDate, string endDate, string membershipPrice, string addtionalFeatures, string totalPrice, string strCreditCardNumber, string strCreditCardType, string strBillingAddress, string strCity, string strZip)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            PhoneNumber = phoneNumber;
            EmailAddress = email;
            Weight = weight;
            Age = age;
            FitnessGoal = fitnessGoal;
            MembershipType = membershipType;
            StartDate = startDate;
            EndDate = endDate;
            MembershipPrice = membershipPrice;
            AdditionalFeatures = addtionalFeatures;
            TotalPrice = totalPrice;
            CreditCardNumber = strCreditCardNumber;
            CreditCardType = strCreditCardType;
            BillingAddress = strBillingAddress;
            City = strCity;
            Zip = strZip;

        }

        private long lngNum;
        private int intDigits;
        private int intSum;

        //Check for validity
        public bool CardNumValid(string CreditCardNumber)
        {
            if (!Int64.TryParse(CreditCardNumber, out lngNum))
            { return false; }
            else { return true; }
        }

        //Check for length
        public bool CheckCreditLength(string CreditCardNumber)
        {
            if (CreditCardNumber.Length != 13 && CreditCardNumber.Length != 15 && CreditCardNumber.Length != 16)
            { return false; }
            else { return true; }
        }

        //Check card type
        public string CardType(string card)
        {
            if (card.StartsWith("34") || card.StartsWith("37")) { CreditCardType = "AMEX"; }
            else if (card.StartsWith("6011"))
            {
                CreditCardType = "Discover";
            }
            else if (card.StartsWith("51") || card.StartsWith("52") || card.StartsWith("53") || card.StartsWith("53") || card.StartsWith("54") || card.StartsWith("55")) { CreditCardType = "MasterCard"; } else if (card.StartsWith("4")) { CreditCardType = "Visa"; } else { CreditCardType = "Unknown Card Type"; }
            return CreditCardType;
        }

        // Reverse string for Luhn
        private string ReverseString(string card)
        {
            char[] arr = card.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
       }

        // Luhn algorthim
        public bool Luhn(string strCard)
        {
            strCard = ReverseString(strCard);
            for (int i = 0; i < strCard.Length; i++)
            {
                intDigits = Convert.ToInt32(strCard.Substring(i, 1));
                if ((i + 1) % 2 == 0)
                {
                    intDigits *= 2;
                    if (intDigits > 9)
                    { intDigits -= 9; }
                }
                intSum += intDigits;
            }
            if (intSum % 10 == 0) { return true; } else { return false; }
        }

        public bool isExpired(int mm, int yyyy)
        {
            int todayMonth = DateTime.Today.Month;
            int todayYear = DateTime.Today.Year;
            bool isValid = false;
            
            if(yyyy == todayYear)
            {
                if(mm < todayMonth)
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }
            if(yyyy > todayYear)
            {
                isValid = true;
            }
            return isValid;
            
        }
        
        public override string ToString()
        {
            return
                "Personal Information" + Environment.NewLine
                + "First Name: " + FirstName + Environment.NewLine
                + "Last Name: " + LastName + Environment.NewLine
                + "Gender: " + Gender + Environment.NewLine
                + "Phone Number: " + PhoneNumber + Environment.NewLine
                + "Email Address: " + EmailAddress + Environment.NewLine
                + "Weight: " + Weight + Environment.NewLine
                + "Age: " + Age + Environment.NewLine
                + "Fitness Goal: " + FitnessGoal + Environment.NewLine + Environment.NewLine
                + "Membership Information" + Environment.NewLine
                + "Membership Type: " + MembershipType + Environment.NewLine
                + "Start Date: " + StartDate + Environment.NewLine
                + "End Date: " + EndDate + Environment.NewLine
                + "Membership Price: " + MembershipPrice + Environment.NewLine
                + "Additional Features: " + AdditionalFeatures + Environment.NewLine
                + "Total Price: " + TotalPrice + Environment.NewLine + Environment.NewLine
                + "Shipment Information" + Environment.NewLine
                + "Credit Card Number: " + CreditCardNumber + Environment.NewLine
                + "Credit Card Type: " + CreditCardType + Environment.NewLine
                + "Billing Address: " + BillingAddress + Environment.NewLine
                + "City: " + City + Environment.NewLine
                + "Zipcode: " + Zip + Environment.NewLine;
        }


    }
}
