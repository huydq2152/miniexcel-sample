using TestMiniExcel.Common.Storage;
using TestMiniExcel.Services;

namespace TestMiniExcel.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ITempFileCacheManager, TempFileCacheManager>();
        services.AddTransient<ITodoListExcelExporter, TodoListExcelExporter>();
    }
}