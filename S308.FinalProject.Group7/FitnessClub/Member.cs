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
        public long MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public string FitnessGoal { get; set; }
        public int CaloriesBurned { get; set; }
        public int Miles { get; set; }
        public int WeightGoal { get; set; }
        public int Steps { get; set; }
        public int FloorsClimbed { get; set; }

        public Member()
        {

        }

        //Initialize constructor
        public Member(long memberid, string firstName, string lastName,string gender, string phoneNumber,  string email, int weight, int age, string fitnessGoal, int caloriesBurned, int miles, int weightGoal, int steps, int floorsClimbed)
        {
            MemberID = memberid;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            PhoneNumber = phoneNumber;
            EmailAddress = email;
            Weight = weight;
            Age = age;
            FitnessGoal = fitnessGoal;
            CaloriesBurned = caloriesBurned;
            Miles = miles;
            WeightGoal = weightGoal;
            Steps = steps;
            FloorsClimbed = floorsClimbed;

       }

        public override string ToString()
        {
            return
                 "MemberID: " + MemberID + Environment.NewLine
                + "First Name: " + FirstName + Environment.NewLine
                + "Last Name: " + LastName + Environment.NewLine
                + "Gender: " + Gender + Environment.NewLine
                + "Phone Number: " + PhoneNumber + Environment.NewLine
                + "Email Address: " + EmailAddress + Environment.NewLine
                + "Weight: " + Weight + Environment.NewLine
                + "Age: " + Age + Environment.NewLine
                + "Fitness Goal: " + FitnessGoal + Environment.NewLine
                + "Calories Burned: " + CaloriesBurned + Environment.NewLine
                + "Miles: " + Miles + Environment.NewLine
                + "WeightGoal: " + WeightGoal + Environment.NewLine
                + "Steps: " + Steps + Environment.NewLine
                + "Floors Climbed" + FloorsClimbed + Environment.NewLine;
                 
        }


    }
}
