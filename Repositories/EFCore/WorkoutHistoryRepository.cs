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
    public class WorkoutHistoryRepository : RepositoryBase<WorkoutHistory>, IWorkoutHistoryRepository
    {
        public WorkoutHistoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WorkoutHistory>> GetUserWorkoutHistoriesByUserId(string userId, bool trackChanges)
        {
            return await _context.WorkoutHistories
                .AsNoTracking()
                .Include(wh => wh.WorkoutExercise)
                    .ThenInclude(we => we.Exercise)
                .Include(wh => wh.WorkoutExercise)
                    .ThenInclude(we => we.Workout)
                .Where(wh => wh.WorkoutExercise.Workout.UserId.Equals(userId))
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkoutHistory>> GetUserWorkoutHistoriesByUserAndWorkoutIdId(int workoutId, string userId, bool trackChanges)
        {
            return await _context.WorkoutHistories
                .AsNoTracking()
                .Include(wh => wh.WorkoutExercise)
                    .ThenInclude(we => we.Exercise)
                .Include(wh => wh.WorkoutExercise)
                    .ThenInclude(we => we.Workout)
                .Where(wh => wh.WorkoutExercise.Workout.UserId.Equals(userId) && wh.WorkoutExercise.Workout.Id.Equals(workoutId))
                .ToListAsync();
        }

        public async Task<WorkoutHistory> GetOneWorkoutHistoryById(int id, bool trackChanges)
        {
            return await FindByCondition(wh => wh.Id.Equals(id),trackChanges).FirstOrDefaultAsync();
        }

        public void StartExercise(WorkoutHistory workoutHistory)
        {
            Create(workoutHistory);
        }

        public void SaveExercise(WorkoutHistory workoutHistory)
        {
            Update(workoutHistory);
        }

    }
}
