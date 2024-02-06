using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IWorkoutService _workoutService;
        private readonly IExerciseService _exerciseService;
        private readonly IWorkoutHistoryService _workoutHistoryService;

        public ServiceManager(IAuthenticationService authenticationService, IWorkoutService workoutService, IExerciseService exerciseService, IWorkoutHistoryService workoutHistoryService)
        {
            _authenticationService = authenticationService;
            _workoutService = workoutService;
            _exerciseService = exerciseService;
            _workoutHistoryService = workoutHistoryService;
        }

        public IAuthenticationService AuthenticationService => _authenticationService;

        public IWorkoutService WorkoutService => _workoutService;

        public IExerciseService ExerciseService => _exerciseService;

        public IWorkoutHistoryService WorkoutHistoryService => _workoutHistoryService;
    }
}
