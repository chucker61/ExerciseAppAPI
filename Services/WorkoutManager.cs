using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WorkoutManager : IWorkoutService
    {
        private readonly IRepositoryManager _manager;

        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public WorkoutManager(IRepositoryManager manager, IMapper mapper, UserManager<AppUser> userManager)
        {
            _manager = manager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreateOneWorkoutAsync(string userName,WorkoutDtoForInsertion workoutDto)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var exercises = await _manager.Exercise.GetExercisesByIds(workoutDto.ExerciseIds);

            if (exercises is not null && exercises.Any())
            {
                Workout workout = new Workout()
                {
                    Name = workoutDto.Name,
                    User = user,
                    WorkoutExercises = exercises.Select(e => new WorkoutExercise { Exercise = e }).ToList()
                };
                _manager.Workout.CreateWorkout(workout);
                await _manager.SaveAsync();
            }
            else
            {
                throw new Exception("Exercises not found.");
            }
        }

        public async Task DeleteOneWorkoutAsync(string userName, int workoutId, bool trackChanges)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var workout = await GetOneUserWorkoutByIdAndCheckExist(user.Id, workoutId, trackChanges);
            _manager.Workout.DeleteWorkout(workout);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<Workout>> GetAllWorkoutsAsync(bool trackChanges)
        {
            return await _manager.Workout.GetAllWorkoutsAsync(trackChanges);
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsByUserNameAsync(string userName, bool trackChanges)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return await _manager.Workout.GetWorkoutsByUserIdAsync(user.Id,trackChanges);
        }

        public async Task<Workout> GetOneUserWorkoutByIdAsync(string userName, int workoutId, bool trackChanges)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return await GetOneUserWorkoutByIdAndCheckExist(user.Id, workoutId, trackChanges);
        }

        public async Task UpdateOneWorkoutAsync(string userName, int workoutId, WorkoutDtoForUpdate workoutDto, bool trackChanges)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var workout = await GetOneUserWorkoutByIdAndCheckExist(user.Id, workoutId, trackChanges);

            var exercises = await _manager.Exercise.GetExercisesByIds(workoutDto.ExerciseIds);

            if (exercises is not null && exercises.Any())
            {
                workout.WorkoutExercises.Clear();

                workout.Id = workoutDto.Id;
                workout.Name = workoutDto.Name;
                workout.User = user;
                workout.WorkoutExercises = exercises.Select(e => new WorkoutExercise { Exercise = e }).ToList();

                _manager.Workout.UpdateWorkout(workout);
                await _manager.SaveAsync();
            }
            else
            {
                throw new Exception("Exercises not found.");
            }

        }

        private async Task<Workout> GetOneUserWorkoutByIdAndCheckExist(string userId,int workoutId, bool trackChanges)
        {
            var workout = await _manager.Workout.GetOneUserWorkoutByIdAsync(userId, workoutId, trackChanges);
            if (workout == null) 
                throw new Exception("Exercise not found");
            return workout;
        }

    }
}
