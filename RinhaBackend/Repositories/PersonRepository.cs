using Microsoft.EntityFrameworkCore;
using RinhaBackend.Models;

namespace RinhaBackend.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly PersonContext _context;

    public PersonRepository(PersonContext context)
    {
        _context = context;
    }
    public async Task<string> CreatePerson(PersonDto personDto)
    {
        var oldPerson = await GetPersonByTerm(personDto.Apelido);
        if(oldPerson.Any()) return string.Empty; 
        var person = new Person(personDto.Apelido, personDto.Nome, personDto.Nascimento, personDto.Stack);
        await _context.Person.AddAsync(person);
        await _context.SaveChangesAsync();
        return person.Id;
    }

    public async Task<Person?> GetPersonById(string id)
    {
        return await _context.Person.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<Person>?> GetPersonByTerm(string term)
    {
        term = term.ToLowerInvariant();
        var query = _context.Person.Where(t => t.SearchText.Contains(term));
        return await query.Take(50).ToListAsync();
    }

    public Task<int> CountPersons()
    {
        return _context.Person.CountAsync();
    }
}