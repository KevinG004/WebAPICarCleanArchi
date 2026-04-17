using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Domain.Entities
{
    public class Personne
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public ICollection<Car> Cars { get; set; } = [];
    }
}
