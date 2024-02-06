using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record ExerciseDto
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public int Diff { get; init; } // zorluk derecesi
        public double Correction { get; init; }
        public int WorkoutId { get; init; }
    }
}
