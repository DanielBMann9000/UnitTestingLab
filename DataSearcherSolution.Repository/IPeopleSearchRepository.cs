using System.Collections.Generic;
using DataSearcherSolution.Model;

namespace DataSearcherSolution.Repository
{
    public interface IPeopleSearchRepository
    {
        IEnumerable<Person> GetAllPeople();
    }
}
