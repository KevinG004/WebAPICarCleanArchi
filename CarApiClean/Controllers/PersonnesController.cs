using CarList.Core.DTOs.Requests;
using CarList.Core.DTOs.Responses;
using CarList.Core.Interfaces.Services.Data;
using CarList.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarApiClean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnesController : ControllerBase
    {
        private readonly IPersonneService _personneService;
        public PersonnesController(IPersonneService personneService)
        {
            _personneService = personneService;
        }
        // GET: api/<PersonnesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personne>>> Get()
        {
            var Personne = await _personneService.Getall();
            return Ok(Personne);
        }

        // GET api/<PersonnesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personne>> Get(Guid id)
        {
           var Personne = await _personneService.GetById(id);
            if (Personne == null)
            {
                return NotFound();
            }
            return Ok(Personne);
        }

        // POST api/<PersonnesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonneAddResponseDTO personne)
        {

            if (personne == null)
            {
                return BadRequest();
            }
            else
            {
                var Personne = await _personneService.Post(personne);
                return Ok(Personne);
            }
        }

        // PUT api/<PersonnesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PersonneAddResponseDTO personne)
        {
            var existingPersonneDto = await _personneService.GetById(id);
            if (existingPersonneDto == null)
            {
                return NotFound();
            }

            var personneToUpdate = new Personne
            {
                Id = id,
                Email = personne.Email,
                FirstName = personne.FirstName,
                LastName = personne.LastName,
                Password = personne.Password
            };

            await _personneService.Put(personneToUpdate, id);

            var updatedDto = await _personneService.GetById(id);
            return Ok(updatedDto);

            // DELETE api/<PersonnesController>/5
            }
            [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var personneDto = await _personneService.GetById(id);
            if (personneDto == null)
            {
                return NotFound();
            }

            await _personneService.Delete(id);
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(Guid id, [FromBody] PersonnePatchRequestDTO personneDTO)
        {
            var personneDto = await _personneService.GetById(id);
            if (personneDto == null)
            {
                return NotFound();
            }

            await _personneService.PatchAsync(id, personneDTO.Email);

            var updatedDto = await _personneService.GetById(id);
            return Ok(updatedDto);
        }
    }
}
