using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IWorkoutHistoryRepository _workoutHistoryRepository;
        private readonly IWorkoutExerciseRepository _workoutExerciseRepository;

        public RepositoryManager(AppDbContext context,IWorkoutRepository workoutRepository, IExerciseRepository exerciseRepository, IWorkoutHistoryRepository workoutHistoryRepository, IWorkoutExerciseRepository workoutExerciseRepository)
        {
            _context = context;
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _workoutHistoryRepository = workoutHistoryRepository;
            _workoutExerciseRepository = workoutExerciseRepository;
        }

        public IWorkoutRepository Workout => _workoutRepository;

        public IExerciseRepository Exercise => _exerciseRepository;

        public IWorkoutHistoryRepository WorkoutHistory => _workoutHistoryRepository;

        public IWorkoutExerciseRepository WorkoutExercise => _workoutExerciseRepository;

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
