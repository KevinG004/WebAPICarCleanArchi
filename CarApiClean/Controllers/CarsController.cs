using CarApiClean.DTOs.Responses;
using CarList.Core.Interfaces.Services;
using CarList.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApiClean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _context;

        public CarsController(ICarService context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCar()
        {
            var car = await _context.Getall();
            return Ok(car);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(Guid id)
        {
            var car = await _context.GetById(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(Guid id, [FromBody] CarAddResponseDTO car)
        {
            var CarExisting = await _context.GetById(id);
            if (CarExisting == null)
            {
                return BadRequest();
            }

               CarExisting.Models = car.Models;
               CarExisting.HorsePower = car.HorsePower;
               CarExisting.Tire = car.Tire;
               await _context.Put(CarExisting, id);
               return Ok(CarExisting);          
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [HttpPost("post")]
        [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CarAddResponseDTO carDTO)
        {
            if (carDTO == null)
                return BadRequest();

            //var CreateCar = new Car
            //{
            //    Models = carDTO.Models,
            //    Tire = carDTO.Tire,
            //    HorsePower = carDTO.HorsePower
            //};

            //_car.Add(CreateCar);
            var Car = await _context.Post(carDTO);

            return Ok(Car);
            ;
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var car = await _context.GetById(id);
            if (car == null)
            {
                return NotFound();
            }

            try
            {
                await _context.Delete(car);
                return Ok();
            }
            catch (Exception)
            {
               return NoContent();
            }
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch([FromRoute] Guid id, [FromBody] PatchDTO pdto)
        {
            var existingCar = await _context.GetById(id);
            if (existingCar == null) return NotFound();

            existingCar.Models = pdto.Models;

            await _context.PacthAsync(existingCar);
            return Ok();
        }

    }
}
