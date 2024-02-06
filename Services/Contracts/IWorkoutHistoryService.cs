using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IWorkoutHistoryService
    {
        Task<IEnumerable<WorkoutHistory>> GetWorkoutHistoriesByUserNameAsync(string userName, bool trackChanges);
        Task<IEnumerable<WorkoutHistory>> GetWorkoutHistoriesByUserNameAndWorkoutIdAsync(int id, string userName, bool trackChanges);
        Task StartExerciseAsync(WorkoutHistoryDtoForInsertion workoutHistoryDto);
        Task SaveExerciseAsync(int id, WorkoutHistoryDtoForUpdate workoutHistoryDto, bool trackChanges);
        Task<(WorkoutHistoryDtoForUpdate whDtoForUpdate, WorkoutHistory wh)> GetWorkoutHistoryForPatchAsync(int id, bool trackChanges);
        Task SaveChangesForPatchAsync(WorkoutHistoryDtoForUpdate whDtoForUpdate, WorkoutHistory wh);
    }
}
