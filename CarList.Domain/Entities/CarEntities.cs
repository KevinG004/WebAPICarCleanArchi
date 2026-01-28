using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Domain.Entities
{
    public class Car
    {
        
        public Guid Id { get; set; }

        public string Models { get; set; } = null!;

        public int Tire { get; set; }

        public int HorsePower { get; set; }
    
    }
}
