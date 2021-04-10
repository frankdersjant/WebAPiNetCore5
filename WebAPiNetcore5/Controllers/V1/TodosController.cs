using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiNetcore5.Model;
using WebApiNetcore5.Services;
using WebAPiNetcore5.Controllers.V1.Request;
using WebAPiNetcore5.Extensions;

namespace WebAPiNetcore5.Controllers.V1
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TodosController : Controller
    {
        private readonly ITodosService _todosService;

        /// <summary>
        /// http://localhost:5000/api/v1/todos
        /// </summary>
        /// <param name="todoService"></param>
        public TodosController(ITodosService todoService)
        {
            _todosService = todoService;
        }

        //http://localhost:5000/api/v1/todos/gettodos        
        [HttpGet("api/v1/todos/GetTodos")]
        public async Task<IActionResult> GetAllTodos()
        {
            return Ok(await _todosService.getAllTodosAsync());
        }

        [HttpPost("api/v1/todos/Create")]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequest createTodoRequest)
        {
            if (!ModelState.IsValid)
            { 
            }
            Todos newTodos = new Todos
            {
                Name = createTodoRequest.TodoName,
                UserId = HttpContext.GetUserId()
            };

            return Ok(await _todosService.getAllTodosAsync());
        }
    }
}
