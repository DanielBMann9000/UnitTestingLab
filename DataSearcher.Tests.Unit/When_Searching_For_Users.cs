using System;
using System.Linq;
using System.Collections.Generic;
using DataSearcher.Model;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataSearcher;

namespace DataSearcherSolution.Tests.Unit
{
    [TestClass]
    public class When_Searching_For_Users
    {
        [TestMethod]
        public void Filtering_By_Last_Names_Should_Return_Users_Whose_Last_Names_Start_With_Search_Criteria()
        {
            //Arrange
            var lastNameSearchCriteria = "D";

            var repository = new DataSearcher.Repository.Fakes.StubIPeopleSearchRepository
            {
                GetAllPeople = () => new List<Person>
                {
                    new Person {FirstName = "Daniel", LastName = "Mann"},
                    new Person {FirstName = "Robert", LastName = "Davidson"},
                    new Person {FirstName = "Timothy", LastName = "Dennison"},
                }
            };

            var expected = 2;

            var vm = new SearcherWindowViewModel(repository);

            //Act
            vm.LastNameSearchCriteria = lastNameSearchCriteria;
            var actual = vm.People.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Filtering_By_Last_Names_Is_Not_Case_Sensitive()
        {
            //Arrange
            var lastNameSearchCriteria = "d";

            var repository = new DataSearcher.Repository.Fakes.StubIPeopleSearchRepository
            {
                GetAllPeople = () => new List<Person>
                {
                    new Person {FirstName = "Daniel", LastName = "Mann"},
                    new Person {FirstName = "Robert", LastName = "Davidson"},
                    new Person {FirstName = "Timothy", LastName = "Dennison"},
                }
            };

            var expected = 2;

            var vm = new SearcherWindowViewModel(repository);

            //Act
            vm.LastNameSearchCriteria = lastNameSearchCriteria;
            var actual = vm.People.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Filtering_Throws_An_Exception_If_Filter_Criteria_Is_Null()
        {
            //Arrange
            string lastNameSearchCriteria = null;

            var repository = new DataSearcher.Repository.Fakes.StubIPeopleSearchRepository
            {
                GetAllPeople = () => new List<Person>
                {
                    new Person {FirstName = "Daniel", LastName = "Mann"},
                    new Person {FirstName = "Robert", LastName = "Davidson"},
                    new Person {FirstName = "Timothy", LastName = "Dennison"},
                }
            };

            var expected = 2;

            var vm = new SearcherWindowViewModel(repository);

            //Act
            vm.LastNameSearchCriteria = lastNameSearchCriteria;
        }

        [TestMethod]
        public void Filtering_By_First_Names_Should_Return_Users_Whose_First_Names_Start_With_Search_Criteria()
        {
            //Arrange
            var firstNameSearchCriteria = "D";

            var repository = new DataSearcher.Repository.Fakes.StubIPeopleSearchRepository
            {
                GetAllPeople = () => new List<Person>
                {
                    new Person {FirstName = "Daniel", LastName = "Mann"},
                    new Person {FirstName = "Donald", LastName = "Davidson"},
                    new Person {FirstName = "Timothy", LastName = "Smith"},
                }
            };

            var expected = 2;

            var vm = new SearcherWindowViewModel(repository);

            //Act
            vm.FirstNameSearchCriteria = firstNameSearchCriteria;
            var actual = vm.People.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Filtering_By_First_And_Last_Names_Should_Return_Users_Whose_First_And_Last_Names_Start_With_Search_Criteria()
        {
            //Arrange
            var firstNameSearchCriteria = "D";
            var lastNameSearchCriteria = "D";

            var repository = new DataSearcher.Repository.Fakes.StubIPeopleSearchRepository
            {
                GetAllPeople = () => new List<Person>
                {
                    new Person {FirstName = "Daniel", LastName = "Mann"},
                    new Person {FirstName = "Donald", LastName = "Davidson"},
                    new Person {FirstName = "Timothy", LastName = "Smith"},
                }
            };

            var expected = 1;

            var vm = new SearcherWindowViewModel(repository);

            //Act
            vm.LastNameSearchCriteria = firstNameSearchCriteria;
            var actual = vm.People.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Days_Since_Last_Login_Should_Be_Calculated_Correctly_Relative_To_A_Given_Date()
        {
            using (ShimsContext.Create())
            {
                //Arrange
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2013, 1, 2);
                var testPerson = new Person
                {
                    LastLogin = new DateTime(2012, 1, 1)
                };

                var expected = 367;

                //Act
                var actual = testPerson.DaysSinceLastLogin;

                //Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
