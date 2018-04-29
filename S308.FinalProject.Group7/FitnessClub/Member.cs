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
        public int Weight { get; set; }
        public int Age { get; set; }
        public string FitnessGoal { get; set; }
        
 
        public Member()
        {

        }

        //Initialize constructor
        public Member (string firstName, string lastName, string gender, string phoneNumber, string email, int weight, int age, string fitnessGoal, CustomerPaymentInfo payment)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            PhoneNumber = phoneNumber;
            EmailAddress = email;
            Weight = weight;
            Age = age;
            FitnessGoal = fitnessGoal;
            
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

        public override string ToString()
        {
            return
                "First Name: " + FirstName + Environment.NewLine
                + "Last Name: " + LastName + Environment.NewLine
                + "Gender: " + Gender + Environment.NewLine
                + "Phone Number: " + PhoneNumber + Environment.NewLine
                + "Email Address: " + EmailAddress + Environment.NewLine
                + "Weight: " + Weight + Environment.NewLine
                + "Age: " + Age + Environment.NewLine
                + "Fitness Goal: " + FitnessGoal + Environment.NewLine
                 
        }


    }
}
