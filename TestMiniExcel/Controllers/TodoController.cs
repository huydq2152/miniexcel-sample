using Microsoft.AspNetCore.Mvc;
using MiniExcelLibs;
using TestMiniExcel.Models;

namespace TestMiniExcel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTodos()
    {
        var todos = Todo.GetList();
        return Ok(todos);
    }

    [HttpGet("export")]
    public async Task<IActionResult> ExportTodos([FromQuery] bool isComplete, CancellationToken token)
    {
        var filteredList = Todo.GetList().Where(x => x.IsComplete == isComplete).ToList();
        if (filteredList.Count == 0)
        {
            return NotFound();
        }

        var memoryStream = new MemoryStream();
        await memoryStream.SaveAsAsync(filteredList, cancellationToken: token);
        memoryStream.Seek(0, SeekOrigin.Begin);

        return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "todos.xlsx");
    }
}