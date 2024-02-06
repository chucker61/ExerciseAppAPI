using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/admin/exercises")]
    public class ExercisesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ExercisesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneExerciseByIdAsync([FromRoute] int id)
        {
            return Ok(await _manager.ExerciseService.GetOneExerciseByIdAsync(id, false));
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateOneExerciseAsync([FromBody] ExerciseDtoForInsertions exerciseDto)
        {
            await _manager.ExerciseService.CreateOneExerciseAsync(exerciseDto);
            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateOneExerciseAsync([FromRoute] int id, [FromBody] ExerciseDtoForUpdate exerciseDto)
        {
            await _manager.ExerciseService.UpdateOneExerciseAsync(id, exerciseDto, false);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneExerciseAsync([FromRoute] int id)
        {
            await _manager.ExerciseService.DeleteOneExerciseAsync(id, false);
            return NoContent();
        }
    }
}
