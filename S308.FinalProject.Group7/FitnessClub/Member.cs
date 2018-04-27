using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
   //Add class for member
    public class Member: CustomerPaymentInfo
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
        public Member(string memberid, string firstName, string lastName,string gender, string phoneNumber,  string email, int weight, int age, string fitnessGoal, int caloriesBurned, int miles, int weightGoal, int steps, int floorsClimbed, CustomerPaymentInfo payment, string transactiondate, string itemspurchased)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            PhoneNumber = phoneNumber;
            EmailAddress = email;
            Weight = weight;
            Age = age;
            FitnessGoal = fitnessGoal;
            MembershipType = payment.MembershipType;
            StartDate = payment.StartDate;
           

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
