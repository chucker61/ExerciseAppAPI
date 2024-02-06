using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/exercises")]
    public class ExercisesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ExercisesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercisesWithAsync()
        {
            return Ok(await _manager.ExerciseService.GetAllExercisesAsync(false));
        }
    }
}
