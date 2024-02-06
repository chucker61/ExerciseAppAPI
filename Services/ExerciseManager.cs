using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ExerciseManager : IExerciseService
    {
        private readonly IRepositoryManager _manager;

        private readonly IMapper _mapper;
        public ExerciseManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }


        public async Task CreateOneExerciseAsync(ExerciseDtoForInsertions exerciseDto)
        {
            var exercise = _mapper.Map<Exercise>(exerciseDto);
            _manager.Exercise.CreateExercise(exercise);
            await _manager.SaveAsync();
        }

        public async Task DeleteOneExerciseAsync(int id, bool trackChanges)
        {
            var exercise = await GetOneExerciseByIdAndCheckExist(id, trackChanges);
            _manager.Exercise.DeleteExercise(exercise);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<Exercise>> GetAllExercisesAsync(bool trackChanges)
        {
            return await _manager.Exercise.GetAllExercisesAsync(trackChanges);
        }

        public async Task<Exercise> GetOneExerciseByIdAsync(int id, bool trackChanges)
        {
            return await GetOneExerciseByIdAndCheckExist(id, trackChanges);
        }

        public async Task UpdateOneExerciseAsync(int id, ExerciseDtoForUpdate exerciseDto, bool trackChanges)
        {
            await GetOneExerciseByIdAndCheckExist(id, trackChanges);
            var entity = _mapper.Map<Exercise>(exerciseDto);
            _manager.Exercise.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Exercise> GetOneExerciseByIdAndCheckExist(int id, bool trackChanges)
        {
            var exercise = await _manager.Exercise.GetOneExerciseByIdAsync(id, trackChanges);
            if (exercise == null)
                throw new Exception("Exercise not found.");
            return exercise;
        }
    }
}
