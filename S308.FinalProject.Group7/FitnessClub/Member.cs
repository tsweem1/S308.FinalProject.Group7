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
        public long CreditCard { get; set; }
        public string CreditCardType { get; set; }
        public string BillingAddress { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }


        public Member()
        {

        }

        //Initialize constructor
        public Member(string firstName, string lastName,string gender, string phoneNumber,  string email, int weight, int age, string fitnessGoal, CustomerPaymentInfo payment, long creditcard, string creditcardtype, string billingadddress, string city, int zipcode)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            PhoneNumber = phoneNumber;
            EmailAddress = email;
            Weight = weight;
            Age = age;
            FitnessGoal = fitnessGoal;
            CreditCard = creditcard;
            CreditCardType = creditcardtype;
            BillingAddress = billingadddress;
            City = city;
            ZipCode = zipcode;

            //MembershipType = payment.MembershipType;
          //  StartDate = payment.StartDate;
           

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
                + "Fitness Goal: " + FitnessGoal + Environment.NewLine;
                 
        }


    }
}
