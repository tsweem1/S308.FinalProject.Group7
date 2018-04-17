using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
   //Add class for member
    public class Member
    {

        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int Weight { get; set; }
        public string EmailAddress { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardNumber { get; set; }
        public string SecurityCode { get; set; }
    

        public Member()
        {

        }

        //Initialize constructor
        public Member(string userID, string firstName, string lastName, string phoneNumber, string gender, DateTime birthday, string email, string creditType, string creditNumber, string securityCode, int weight )
        {
            UserId = userID;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Birthday = birthday;
            EmailAddress = email;
            CreditCardType = creditType;
            CreditCardNumber = creditNumber;
            SecurityCode = securityCode;
            Weight = weight;
       }

        // Output for data grids...probably add more for output
        public override string ToString()
        {
            string strOutput = "";

            strOutput += "First Name" + Environment.NewLine;
            strOutput += "Last Name" + Environment.NewLine;
            strOutput += "Phone" + Environment.NewLine;
            strOutput += "Gender" + Environment.NewLine;
            strOutput += "Birthday" + Environment.NewLine;
            strOutput += "Email" + Environment.NewLine;

            return strOutput;
        }
    }
}
