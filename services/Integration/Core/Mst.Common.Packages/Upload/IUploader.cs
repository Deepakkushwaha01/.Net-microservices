using Microsoft.AspNetCore.Http;

namespace Mst.Common.Packages.Upload
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file, string uploadPath);
    }
}