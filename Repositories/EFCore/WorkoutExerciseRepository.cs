using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class WorkoutExerciseRepository : RepositoryBase<WorkoutExercise>, IWorkoutExerciseRepository
    {
        public WorkoutExerciseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<WorkoutExercise> GetByWorkoutAndExerciseId(int workoutId, int exerciseId, bool trackChanges)
        {
            return await FindByCondition(we => we.WorkoutId == workoutId && we.ExerciseId == exerciseId, trackChanges).FirstOrDefaultAsync();
        }
    }
}
