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
        private long lngNum;
        private int intDigits;
        private int intSum;
        public object imgCard;

        //Check for validity
        public bool CardNumValid(bool isValid)
        {
            if (!Int64.TryParse(CreditCardNumber, out lngNum)) { isValid = false; }
            else { isValid = true; }
            return isValid;
        }

        //Check for length
        public bool CheckCreditLength(bool isValid)
        {
            if (CreditCardNumber.Length != 13 && CreditCardNumber.Length != 15 && CreditCardNumber.Length != 16)
            { isValid = false; } else { isValid = true; }
            return isValid;
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
        public bool Luhn(bool isValid)
        {
            string strCard = ReverseString(CreditCardNumber);
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
            if(intSum % 10 == 0) { isValid = true; } else { isValid = false; }
            return isValid;
            }

     }  
 }

