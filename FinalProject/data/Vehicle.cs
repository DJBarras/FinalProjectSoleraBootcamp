using System;
using System.Collections.Generic;

namespace FinalProject.data
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Claims = new HashSet<Claim>();
        }

        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Vin { get; set; }
        public string? Color { get; set; }
        public string? Year { get; set; }
        public int? OwnerId { get; set; }

        public virtual Owner? Owner { get; set; }
        public virtual ICollection<Claim> Claims { get; set; }
    }
}
