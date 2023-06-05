using Microsoft.AspNetCore.Mvc;
using Resilient.Api.Dtos;
using Resilient.Api.Services;

namespace Resilient.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodosService _todosService;

    public TodoController(ITodosService todosService)
    {
        _todosService = todosService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetAsync()
    {
        var todos = await _todosService.GetAsync();

        return Ok(todos);
    }        
}