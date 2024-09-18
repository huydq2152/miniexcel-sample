using Microsoft.AspNetCore.Mvc;
using TestMiniExcel.Common.Dtos;
using TestMiniExcel.Models;
using TestMiniExcel.Services;

namespace TestMiniExcel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoListExcelExporter _todoListExcelExporter;

    public TodoController(ITodoListExcelExporter todoListExcelExporter)
    {
        _todoListExcelExporter = todoListExcelExporter;
    }

    [HttpGet]
    public IActionResult GetTodos()
    {
        var todos = ExportTodoDto.GetList();
        return Ok(todos);
    }

    [HttpGet("todos-to-excel")]
    public async Task<FileDto> GetTodosToExcel(GetTodosToExcelInput input)
    {
        var todos = ExportTodoDto.GetList().Where(x => x.IsComplete == input.IsComplete).ToList();
        if (todos.Count == 0)
        {
            return new FileDto();
        }

        return _todoListExcelExporter.ExportToFile(todos);
    }
}