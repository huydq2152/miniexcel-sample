using TestMiniExcel.Common.Dtos;
using TestMiniExcel.Common.Services;
using TestMiniExcel.Common.Storage;
using TestMiniExcel.Models;

namespace TestMiniExcel.Services
{
    public class TodoListExcelExporter : MiniExcelExcelExporterBase, ITodoListExcelExporter
    {
        public TodoListExcelExporter(ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager)
        {
        }

        public FileDto ExportToFile(List<ExportTodoDto> todos)
        {
            var items = new List<Dictionary<string, object>>();
            foreach (var todo in todos)
            {
                items.Add(new Dictionary<string, object>()
                {
                    { "Id", todo.Id },
                    { "Name", todo.Title },
                    { "IsComplete", todo.IsComplete }
                });
            }
        
            return CreateExcelPackage("todos.xlsx", items);
        }
    }
}