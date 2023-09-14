using RinhaBackend.Models;

namespace RinhaBackend.Repositories;

public interface IPersonRepository
{
    Task<string> CreatePerson(PersonDto personDto);
    Task<Person?> GetPersonById(string id);
    Task<List<Person>?> GetPersonByTerm(string term);
    Task<int> CountPersons();
}