using System.Collections.Generic;
using DataSearcher.Model;

namespace DataSearcher.Repository
{
    public interface IPeopleSearchRepository
    {
        IEnumerable<Person> GetAllPeople();
    }
}
