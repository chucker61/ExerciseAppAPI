using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IWorkoutService
    {
        Task<IEnumerable<Workout>> GetAllWorkoutsAsync(bool trackChanges);
        Task<IEnumerable<Workout>> GetWorkoutsByUserNameAsync(string userName,bool trackChanges);
        Task<Workout> GetOneUserWorkoutByIdAsync(string userName, int workoutId, bool trackChanges);
        Task CreateOneWorkoutAsync(string userName, WorkoutDtoForInsertion workoutDto);
        Task UpdateOneWorkoutAsync(string userName, int workoutId, WorkoutDtoForUpdate workoutDto, bool trackChanges);
        Task DeleteOneWorkoutAsync(string userName, int workoutId, bool trackChanges);
    }
}
