using Microsoft.AspNetCore.Mvc;
using TestMiniExcel.Common.Dtos;
using TestMiniExcel.Models.Exporting;
using TestMiniExcel.Services;
using TestMiniExcel.Services.Exporting.Interfaces;

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

    [HttpGet("todos")]
    public IActionResult GetTodos()
    {
        var todos = ExportTodoDto.GetList();
        return Ok(todos);
    }

    [HttpPost("export-todos")]
    public async Task<ActionResult<FileDto>> GetExportTodos(GetExportTodosInput input)
    {
        var todos = ExportTodoDto.GetList().Where(x => x.IsComplete == input.IsComplete).ToList();
        if (todos.Count == 0)
        {
            return new FileDto();
        }
        
        var file = _todoListExcelExporter.ExportToFile(todos);

        return Ok(file);
    }
}