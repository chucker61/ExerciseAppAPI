using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IWorkoutService WorkoutService { get; }
        IExerciseService ExerciseService { get; }
        IAuthenticationService AuthenticationService { get; }
        IWorkoutHistoryService WorkoutHistoryService { get; }
    }
}
