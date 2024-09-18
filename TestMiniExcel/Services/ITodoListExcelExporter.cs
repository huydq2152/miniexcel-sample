using TestMiniExcel.Common.Dtos;
using TestMiniExcel.Models;

namespace TestMiniExcel.Services
{
    public interface ITodoListExcelExporter
    {
        FileDto ExportToFile(List<ExportTodoDto> todos);
    }
}