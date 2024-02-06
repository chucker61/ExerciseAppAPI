using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IWorkoutExerciseRepository : IRepositoryBase<WorkoutExercise>
    {
        Task<WorkoutExercise> GetByWorkoutAndExerciseId(int workoutId, int exerciseId, bool trackChanges);
    }
}
