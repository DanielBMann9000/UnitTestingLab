using System;

namespace DataSearcher.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DaysSinceLastLogin
        {
            get
            {
                return (int)DateTime.Now.Subtract(LastLogin).TotalDays;
            }
        }

        public DateTime LastLogin { get; set; }
    }
}
