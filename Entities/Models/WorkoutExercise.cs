using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int WorkoutId { get; set; }

        //relations
        public Workout Workout{ get; set; }
        public Exercise Exercise { get; set; }
        public ICollection<WorkoutHistory> WorkoutHistories { get; set; }
    }
}
