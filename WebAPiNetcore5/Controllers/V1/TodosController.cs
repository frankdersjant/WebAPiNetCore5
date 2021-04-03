using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiNetcore5.Services;

namespace WebAPiNetcore5.Controllers.V1
{

  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TodosController : Controller
    {
        private readonly ITodosService _todosService;
        
        public TodosController(ITodosService todoService)
        {
            _todosService = todoService;
        }

        [HttpGet("api/v1/todos")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _todosService.getAllTodosAsync());
        }
    }
}
