using TestMiniExcel.Common.Abstracts.Exporting;
using TestMiniExcel.Common.Dtos;
using TestMiniExcel.Common.Storage;
using TestMiniExcel.Models.Exporting;
using TestMiniExcel.Services.Exporting.Interfaces;

namespace TestMiniExcel.Services.Exporting
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