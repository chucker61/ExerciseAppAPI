using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IWorkoutRepository : IRepositoryBase<Workout>
    {
        Task<IEnumerable<Workout>> GetAllWorkoutsAsync(bool trackChanges);
        Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(string userId, bool trackChanges);
        Task<Workout> GetOneWorkoutByIdAsync(int id, bool trackChanges);
        Task<Workout> GetOneUserWorkoutByIdAsync(string userId,int workoutId,bool trackChanges);
        void DeleteWorkout(Workout workout);
        void CreateWorkout(Workout workout);
        void UpdateWorkout(Workout workout);
    }
}
