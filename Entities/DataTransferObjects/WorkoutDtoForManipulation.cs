using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record WorkoutDtoForManipulation
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MinLength(2, ErrorMessage = "Name must consist of at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Name must consist of at maximum 50 characters.")]
        public string? Name { get; init; }
        [Required(ErrorMessage ="You should select at least one exercise.")]
        public List<int> ExerciseIds { get; init; } = new List<int>();
    }
}
