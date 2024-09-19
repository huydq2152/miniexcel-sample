using TestMiniExcel.Common.Storage;
using TestMiniExcel.Services;
using TestMiniExcel.Services.Exporting;
using TestMiniExcel.Services.Exporting.Interfaces;

namespace TestMiniExcel.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ITempFileCacheManager, TempFileCacheManager>();
        services.AddTransient<ITodoListExcelExporter, TodoListExcelExporter>();
    }
}