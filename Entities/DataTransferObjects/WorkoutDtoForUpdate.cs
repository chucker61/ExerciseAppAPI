using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record WorkoutDtoForUpdate : WorkoutDtoForManipulation
    {
        [Required(ErrorMessage = "Workout Id is required field.")]
        public int Id { get; init; }
    }
}
