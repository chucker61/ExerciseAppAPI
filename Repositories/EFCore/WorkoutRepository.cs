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
    public class WorkoutRepository : RepositoryBase<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateWorkout(Workout workout)
        {
            Create(workout);
        }

        public void DeleteWorkout(Workout workout)
        {
            Delete(workout);
        }

        public async Task<IEnumerable<Workout>> GetAllWorkoutsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).Include(w => w.WorkoutExercises).ThenInclude(we => we.Exercise).OrderBy(w => w.Name).ToListAsync();
        }

        public async Task<Workout> GetOneUserWorkoutByIdAsync(string userId, int workoutId, bool trackChanges)
        {
            return await _context.Workouts
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                        .ThenInclude(e => e.WorkoutExercises)
                .Where(w => w.UserId.Equals(userId) && w.Id.Equals(workoutId)).SingleOrDefaultAsync();
        }

        public async Task<Workout> GetOneWorkoutByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(w => w.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(string userId, bool trackChanges)
        {
            return await _context.Workouts
                            .AsNoTracking()
                            .Include(w => w.User)
                            .Include(w => w.WorkoutExercises)
                                .ThenInclude(we => we.Exercise)
                            .Where(w => w.UserId.Equals(userId))
                            .ToListAsync();
        }

        public void UpdateWorkout(Workout workout)
        {
            Update(workout);
        }
    }
}
