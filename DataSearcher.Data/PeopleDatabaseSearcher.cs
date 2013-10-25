using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Linq;
using DataSearcher.Model;

namespace DataSearcher.Data
{
    public class PeopleDatabaseSearcher
    {
        static PeopleDatabaseSearcher()
        {
            var firstNames = new[] {"Daniel", "Ryan", "Bob", "Johnny", "Leo", "Frederic", "Martin", "Nathalie", "Andree", "Julie"};
            var lastNames = new[] { "Mann", "Riehle", "Palmer", "Fayad", "Vildosola", "Persoon", "Rajotte", "Feau", "Chatelain", "Beaulieu" };

            var rng = new Random();

            var numberOfRecords = rng.Next(5, 20);
            //randomize the database   
            using (var con = new SqlCeConnection("Data Source=PeopleDatabase.sdf;Persist Security Info=False;"))
            using (var cmd = new SqlCeCommand("DELETE FROM People", con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }

            using (var con = new SqlCeConnection("Data Source=PeopleDatabase.sdf;Persist Security Info=False;"))
            {
                con.Open();
                for (int i = 0; i < numberOfRecords; i++)
                {
                    using (var cmd = new SqlCeCommand("INSERT INTO People (FirstName, LastName, LastLogin) VALUES (@FirstName, @LastName, @LastLogin)", con))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstNames[rng.Next(0,firstNames.Length - 1)]);
                        cmd.Parameters.AddWithValue("@LastName", lastNames[rng.Next(0, lastNames.Length - 1)]);
                        cmd.Parameters.AddWithValue("@LastLogin", DateTime.Now.AddDays(-rng.Next(0, 365)));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public IEnumerable<Person> GetAllPeople()
        {
            var people = new List<Person>();
            using (var con = new SqlCeConnection("Data Source=PeopleDatabase.sdf;Persist Security Info=False;"))
            using (var cmd = new SqlCeCommand("SELECT * FROM People", con))
            {
                con.Open();
                var results = cmd.ExecuteReader();
                people.AddRange(from DbDataRecord result in results
                    select new Person
                    {
                        FirstName = result["FirstName"].ToString(),
                        LastName = result["LastName"].ToString(),
                        LastLogin = DateTime.Parse(result["LastLogin"].ToString())
                    });
            }
            
            return people;
        }
    }
}
