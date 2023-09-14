using UuidExtensions;

namespace RinhaBackend.Models;

public class Person
{
    public Person(string surname, string name, DateOnly birthDate, List<string> stacks)
    {
        Id = new Uuid7().ToString();
        Surname = surname;
        Name = name;
        BirthDate = birthDate;
        Stacks = stacks;
    }
    public string Id { get; private set; }
    public string Surname { get; private set; }
    public string Name { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public List<string>? Stacks { get; private set; }
}