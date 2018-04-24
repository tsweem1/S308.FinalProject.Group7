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
        public int DailySteps { get; set; }
        public int FloorsClimbed { get; set; }

        public Member()
        {

        }

        //Initialize constructor
        public Member(long memberid, string firstName, string lastName,string gender, string phoneNumber,  string email, int weight, int age, string fitnessGoal, int caloriesBurned, int miles, int weightGoal, int dailySteps, int floorsClimbed)
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
            DailySteps = dailySteps;
            FloorsClimbed = floorsClimbed;



       }
    }
}
