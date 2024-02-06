using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [ApiController]
    [Route("api/workouts")]
    public class WorkoutsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public WorkoutsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkoutsByUserNameAsync()
        {
            var userName = GetCurrentUserName();
            var result = await _manager.WorkoutService.GetWorkoutsByUserNameAsync(userName, false);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneUserWorkoutByIdAsync([FromRoute] int id)
        {
            var userName = GetCurrentUserName();
            return Ok(await _manager.WorkoutService.GetOneUserWorkoutByIdAsync(userName, id, false));
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateOneWorkoutAsync([FromBody] WorkoutDtoForInsertion workoutDto)
        {
            var userName = GetCurrentUserName();
            await _manager.WorkoutService.CreateOneWorkoutAsync(userName,workoutDto);
            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateOneWorkoutAsync([FromRoute] int id, [FromBody] WorkoutDtoForUpdate workoutDto)
        {
            var userName = GetCurrentUserName();
            await _manager.WorkoutService.UpdateOneWorkoutAsync(userName,id, workoutDto, false);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneWorkoutAsync([FromRoute] int id)
        {
            var userName = GetCurrentUserName();
            await _manager.WorkoutService.DeleteOneWorkoutAsync(userName, id, false);
            return NoContent();
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
