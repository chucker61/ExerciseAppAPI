using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record ExerciseDtoForManipulation
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MinLength(2, ErrorMessage = "Name must consist of at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Name must consist of at maximum 50 characters.")]
        public string? Name { get; init; }
        [Required(ErrorMessage = "Diff is a required field.")]
        [Range(0,100,ErrorMessage ="Diff must be between 0 and 100")]
        public int Diff { get; init; } // zorluk derecesi
        [Required(ErrorMessage ="WorkoutId is required field.")]
        public int WorkoutId { get; init; }
    }
}
