using MiniExcelLibs.Attributes;

namespace TestMiniExcel.Models;

public class ExportTodoDto
{
    [ExcelColumn(Name = "Id", Index = 0, Width = 40)]
    public Guid Id { get; set; }

    [ExcelColumn(Name = "Title", Index = 1, Width = 100)]
    public string Title { get; set; } = default!;

    [ExcelColumn(Ignore = true)]
    public bool IsComplete { get; set; }

    public static IEnumerable<ExportTodoDto> GetList()
    {
        return new List<ExportTodoDto>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Write an article about export excel.",
                IsComplete = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Code review: davidfowl/TodoApi",
                IsComplete = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Read 'Implementing Domain Driven Design' book. https://abp.io/books/implementing-domain-driven-design",
                IsComplete = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Make a plan for next week.",
                IsComplete = false
            },
        };
    }
}