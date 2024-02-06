using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record WorkoutHistoryDto
    {
        [Required(ErrorMessage = "Start time is required.")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public TimeSpan DurationTime { get; init; }
        public float Count { get; init; }
        [Required(ErrorMessage = "WorkoutExerciseId is required.")]
        public int WorkoutExerciseId { get; init; }
    }
}
