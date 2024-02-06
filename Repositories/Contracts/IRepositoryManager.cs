using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IWorkoutRepository Workout { get; }
        IExerciseRepository Exercise { get; }
        IWorkoutHistoryRepository WorkoutHistory { get; }
        IWorkoutExerciseRepository WorkoutExercise { get; }
        Task SaveAsync();
    }
}
