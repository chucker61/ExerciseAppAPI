using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IWorkoutHistoryRepository : IRepositoryBase<WorkoutHistory>
    {
        Task<IEnumerable<WorkoutHistory>> GetUserWorkoutHistoriesByUserId(string userId, bool trackChanges);
        Task<WorkoutHistory> GetOneWorkoutHistoryById(int id, bool trackChanges);
        void StartExercise(WorkoutHistory workoutHistory);
        void SaveExercise(WorkoutHistory workoutHistory);
        Task<IEnumerable<WorkoutHistory>> GetUserWorkoutHistoriesByUserAndWorkoutIdId(int workoutId, string userId, bool trackChanges);
    }
}
