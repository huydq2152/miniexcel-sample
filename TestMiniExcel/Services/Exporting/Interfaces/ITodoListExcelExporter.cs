using TestMiniExcel.Common.Dtos;
using TestMiniExcel.Models.Exporting;

namespace TestMiniExcel.Services.Exporting.Interfaces
{
    public interface ITodoListExcelExporter
    {
        FileDto ExportToFile(List<ExportTodoDto> todos);
    }
}