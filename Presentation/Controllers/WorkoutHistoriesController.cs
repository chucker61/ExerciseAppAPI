using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/workoutHistory")]
    [Authorize]
    public class WorkoutHistoriesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public WorkoutHistoriesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkoutHistoriesByUserNameAsync()
        {
            var userName = GetCurrentUserName();
            return Ok(await _manager.WorkoutHistoryService.GetWorkoutHistoriesByUserNameAsync(userName, false));
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetWorkoutHistoriesByUserNameAndWorkoutIdAsync([FromRoute] int id)
        {
            var userName = GetCurrentUserName();
            return Ok(await _manager.WorkoutHistoryService.GetWorkoutHistoriesByUserNameAndWorkoutIdAsync(id, userName, false));
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> StartExerciseAsync([FromBody] WorkoutHistoryDtoForInsertion workoutHistoryDto)
        {
            await _manager.WorkoutHistoryService.StartExerciseAsync(workoutHistoryDto);
            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> SaveExerciseAsync([FromRoute] int id,[FromBody] WorkoutHistoryDtoForUpdate workoutHistoryDto)
        {
            await _manager.WorkoutHistoryService.SaveExerciseAsync(id,workoutHistoryDto,false);
            return StatusCode(201);
        }


        [HttpPatch("{id:int}")]
        public async Task<IActionResult> SaveExercise([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<WorkoutHistoryDtoForUpdate> whPatch)
        {
            if (whPatch is null)
                return BadRequest(); // 400

            var result = await _manager.WorkoutHistoryService.GetWorkoutHistoryForPatchAsync(id, false);

            whPatch.ApplyTo(result.whDtoForUpdate,ModelState);

            TryValidateModel(result.whDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _manager.WorkoutHistoryService.SaveChangesForPatchAsync(result.whDtoForUpdate, result.wh);

            return NoContent(); // 204
        }
        private string GetCurrentUserName()
        {
            var userName = User.Identity.Name;
            if (userName == null)
            {
                throw new Exception("Username is null");
            }
            return userName;
        }
    }
}
