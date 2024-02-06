using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        Task<IEnumerable<Exercise>> GetAllExercisesAsync(bool trackChanges);
        Task<IEnumerable<Exercise>> GetExercisesByIds(List<int> exerciseIds);
        Task<Exercise> GetOneExerciseByIdAsync(int id, bool trackChanges);
        void DeleteExercise(Exercise exercise);
        void CreateExercise(Exercise exercise);
        void UpdateExercise(Exercise exercise);
    }
}
