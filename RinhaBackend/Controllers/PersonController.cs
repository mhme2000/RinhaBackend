using System.Net;
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
        var id = await _personRepository.CreatePerson(personDto);
        var interpolatedString = $"/pessoas/{id}";
        Response.Headers.Location = interpolatedString;
        return new ObjectResult(id) { StatusCode = StatusCodes.Status201Created };
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
        return Ok(count);
    }
}