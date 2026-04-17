using CarApiClean.DTOs.Responses;
using CarList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Core.DTOs.Responses
{
    public class PersonneAddResponseDTO
    {
        public string Email { get; set; } = null!;
        public string? FirstName { get; set; }
        public string Password { get; set; } = null!;
        public string? LastName { get; set; }
        public IEnumerable<CarAddResponseDTO>? Cars { get; set; }
    }
}
