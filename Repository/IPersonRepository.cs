using FCX_Labs.Models;
using System.Collections.Generic;

namespace FCX_Labs.Repository
{
    public interface IPersonRepository
    {
        Person LoadById(long id);
        List<Person> LoadGrid();

        Person Add(Person person);
        Person Update(Person peron);
        bool Delete(long id);

    }
}