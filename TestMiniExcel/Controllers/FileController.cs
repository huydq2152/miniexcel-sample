using Microsoft.AspNetCore.Mvc;
using TestMiniExcel.Common.Dtos;
using TestMiniExcel.Common.Storage;

namespace TestMiniExcel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController: ControllerBase
{
    private readonly ITempFileCacheManager _tempFileCacheManager;

    public FileController(ITempFileCacheManager tempFileCacheManager)
    {
        _tempFileCacheManager = tempFileCacheManager;
    }

    [HttpPost("download-temp-file")]
    public async Task<ActionResult> DownloadTempFile(FileDto file)
    {
        var fileBytes = await _tempFileCacheManager.GetFile(file.FileToken);
        if (fileBytes == null)
        {
            return NotFound("Requested File Does Not Exists");
        }

        return File(fileBytes, file.FileType, file.FileName);
    }

}