using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetAllExercisesAsync(bool trackChanges);
        Task<Exercise> GetOneExerciseByIdAsync(int id, bool trackChanges);
        Task CreateOneExerciseAsync(ExerciseDtoForInsertions exerciseDto);
        Task UpdateOneExerciseAsync(int id, ExerciseDtoForUpdate exerciseDto, bool trackChanges);
        Task DeleteOneExerciseAsync(int id, bool trackChanges);
    }
}
