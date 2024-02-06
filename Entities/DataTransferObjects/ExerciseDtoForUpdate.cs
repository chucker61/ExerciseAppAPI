using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record ExerciseDtoForUpdate : ExerciseDtoForManipulation
    {
        [Required(ErrorMessage = "Id is required field")]
        public int Id { get; init; }
    }
}
