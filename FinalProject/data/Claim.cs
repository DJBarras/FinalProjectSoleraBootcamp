using System;
using System.Collections.Generic;

namespace FinalProject.data
{
    public partial class Claim
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Date { get; set; }
        public int? VehicleId { get; set; }

        public virtual Vehicle? Vehicle { get; set; }
    }
}
