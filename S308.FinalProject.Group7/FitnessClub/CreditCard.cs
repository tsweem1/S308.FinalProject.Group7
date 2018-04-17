using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    class CreditCard : Member
    {
        private bool isValid = false;
        private long lngNum;
        private string strErrorMessage;
        public void CardNumValid()
        {
            if(!Int64.TryParse(CreditCardNumber,out lngNum))
            {
                strErrorMessage = "Credit card numbers contain only numbers.";
                return;            
            }

        }

        public void CheckCreditLength()
        {
            if(CreditCardNumber.Length != 13 && CreditCardNumber.Length != 15 && CreditCardNumber.Length != 16)
            {
                strErrorMessage = "Credit card numbers must contain 13, 15, or 16 digits";
                return;
            }

        }

    }
}

