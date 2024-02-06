﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserId { get; set; }

        //relations
        public AppUser User { get; set; }
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
