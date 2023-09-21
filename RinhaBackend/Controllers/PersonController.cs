using Microsoft.AspNetCore.Mvc;
using RinhaBackend.Models;
using RinhaBackend.Repositories;

namespace RinhaBackend.Controllers;

[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [HttpPost("pessoas")]
    public async Task<IActionResult> Post([FromBody] PersonDto personDto)
    {
        if(personDto.Apelido.Length >= 32 || personDto.Nome.Length >= 100){
            return new ObjectResult(null){StatusCode = StatusCodes.Status422UnprocessableEntity};
        }
        
        if(personDto.Stack != null)
        {
            if (personDto.Stack.Any(tech => tech.Length >= 32))
            {
                return new ObjectResult(null){StatusCode = StatusCodes.Status422UnprocessableEntity};
            }
        }
        var id = await _personRepository.CreatePerson(personDto);
        var interpolatedString = $"/pessoas/{id}";
        Response.Headers.Location = interpolatedString;
        return new ObjectResult(null) { StatusCode = StatusCodes.Status201Created };
    }

    [HttpGet("pessoas/{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var person = await _personRepository.GetPersonById(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpGet("pessoas")]
    public async Task<IActionResult> GetByTerm([FromQuery] string t)
    {
        if (string.IsNullOrEmpty(t)) return BadRequest();
        var persons = await _personRepository.GetPersonByTerm(t);
        return Ok(persons);
    }

    [HttpGet("contagem-pessoas")]
    public async Task<IActionResult> GetCountPersons()
    {
        var count = await _personRepository.CountPersons();
        return Ok(new {count});
    }
}