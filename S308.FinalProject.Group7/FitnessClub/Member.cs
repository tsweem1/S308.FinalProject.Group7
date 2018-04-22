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
        public Member(string firstName, string lastName,string gender, string phoneNumber,  string email, int weight, int age, string fitnessGoal )
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
    }
}
