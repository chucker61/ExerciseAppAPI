using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;


namespace Services
{
    public class WorkoutHistoryManager : IWorkoutHistoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public WorkoutHistoryManager(IRepositoryManager manager, UserManager<AppUser> userManager, IMapper mapper, AppDbContext context)
        {
            _manager = manager;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<WorkoutHistory>> GetWorkoutHistoriesByUserNameAsync(string userName, bool trackChanges)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user is null)
                throw new Exception("User is null");
            return await _manager.WorkoutHistory.GetUserWorkoutHistoriesByUserId(user.Id, trackChanges);

        }

        public async Task<IEnumerable<WorkoutHistory>> GetWorkoutHistoriesByUserNameAndWorkoutIdAsync(int id, string userName, bool trackChanges)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user is null)
                throw new Exception("User is null");
            return await _manager.WorkoutHistory.GetUserWorkoutHistoriesByUserAndWorkoutIdId(id, user.Id, trackChanges);
        }

        public async Task<(WorkoutHistoryDtoForUpdate whDtoForUpdate, WorkoutHistory wh)> GetWorkoutHistoryForPatchAsync(int id, bool trackChanges)
        {
            var wh = await GetWorkoutHistoryByIdAndCheckExists(id, trackChanges);
            var workoutHistoryDtoForUpdate = _mapper.Map<WorkoutHistoryDtoForUpdate>(wh);
            return (workoutHistoryDtoForUpdate, wh);
        }

        public async Task StartExerciseAsync(WorkoutHistoryDtoForInsertion workoutHistoryDto)
        {
            var workoutHistory = _mapper.Map<WorkoutHistory>(workoutHistoryDto);
            _manager.WorkoutHistory.StartExercise(workoutHistory);
            await _manager.SaveAsync();
        }

        public async Task SaveExerciseAsync(int id, WorkoutHistoryDtoForUpdate workoutHistoryDto, bool trackChanges)
        {
            var workoutHistory = await _manager.WorkoutHistory.GetOneWorkoutHistoryById(id, trackChanges);
            workoutHistory = _mapper.Map<WorkoutHistory>(workoutHistoryDto);
            _manager.WorkoutHistory.SaveExercise(workoutHistory);
            await _manager.SaveAsync();
        }

        public async Task SaveChangesForPatchAsync(WorkoutHistoryDtoForUpdate whDtoForUpdate, WorkoutHistory wh)
        {
            wh = _mapper.Map<WorkoutHistory>(whDtoForUpdate);
            _manager.WorkoutHistory.Update(wh);
            await _manager.SaveAsync();
        }


        private async Task<WorkoutHistory> GetWorkoutHistoryByIdAndCheckExists(int id, bool trackChanges)
        {
            // check entity 
            var entity = await _manager.WorkoutHistory.GetOneWorkoutHistoryById(id, trackChanges);

            if (entity is null)
                throw new Exception("NotFound");

            return entity;
        }

    }
}
