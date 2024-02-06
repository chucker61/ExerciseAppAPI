using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record WorkoutDto
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public List<Exercise> Exercises { get; init; } = new List<Exercise>();
    }
}
