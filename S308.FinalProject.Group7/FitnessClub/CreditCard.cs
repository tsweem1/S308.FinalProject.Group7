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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FitnessClub
{
    class CreditCard : Member
    {
        public string CreditCardNumber { get; set; }
        public string CreditCardType { get; set; }
        public string ExpirationDate { get; set; }
        public string BillingAddress { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public CreditCard()
        {

        }
        public CreditCard(string strCreditCardNumber, string strCreditCardType, string strExpirationDate, string strBillingAddress, string strCity, string strZip)
        {
            CreditCardNumber = strCreditCardNumber;
            CreditCardType = strCreditCardType;
            ExpirationDate = strExpirationDate;
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
            { return false; } else { return true; } 
        }

        //Check for length
        public bool CheckCreditLength(string CreditCardNumber)
        {
            if (CreditCardNumber.Length != 13 && CreditCardNumber.Length != 15 && CreditCardNumber.Length != 16)
            { return false; } else { return true; } 
        }

        //Check card type
        public string CardType(string card)
        {
            if (card.StartsWith("34") || card.StartsWith("37")) { CreditCardType = "AMEX"; } else if (card.StartsWith("6011")) {
                CreditCardType = "Discover"; }
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
    }  
 }

