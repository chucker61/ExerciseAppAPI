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
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateExercise(Exercise exercise)
        {
            Create(exercise);
        }

        public void DeleteExercise(Exercise exercise)
        {
            Delete(exercise);
        }

        public async Task<IEnumerable<Exercise>> GetAllExercisesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(e => e.Name).ToListAsync();
        }

        public async Task<IEnumerable<Exercise>> GetExercisesByIds(List<int> exerciseIds)
        {
            return await _context.Exercises.Where(e => exerciseIds.Contains(e.Id)).ToListAsync();
        }

        public async Task<Exercise> GetOneExerciseByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateExercise(Exercise exercise)
        {
            Update(exercise);
        }
    }
}
