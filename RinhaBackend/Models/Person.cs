using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using UuidExtensions;

namespace RinhaBackend.Models;

public class Person
{
    private Person(){}
    public Person(string surname, string name, string birthDate, List<string> stacks)
    {
        var t = Uuid7.TimeNs();
        Id = Uuid7.Guid(t).ToString();
        Surname = surname;
        Name = name;
        BirthDate = birthDate;
        Stacks = string.Join(",",stacks.Select(t => t.ToString()));
    }
    public string Id { get; private set; }
    public string Surname { get; private set; }
    public string Name { get; private set; }
    public string BirthDate { get; private set; }
    public string Stacks { get; private set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string SearchText {get; private set;}
}