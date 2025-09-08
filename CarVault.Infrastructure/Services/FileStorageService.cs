using CarVault.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace CarVault.Infrastructure.Services;
public class FileStorageService(IWebHostEnvironment environment) : IFileStorageService
{
    private readonly IWebHostEnvironment _environment = environment;

    public async Task<string> SaveFileAsync(Stream fileStream, string fileName, string folder)
    {
       var uploadPath= Path.Combine(_environment.WebRootPath,folder);
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        var fullPath= Path.Combine(uploadPath,fileName);

        using (var stream = new FileStream(fullPath, FileMode.Create)) 
        {
        
        await fileStream.CopyToAsync(stream);
        
        }; ;
        return $"{folder}/{fileName}";
    }
    public async Task<bool> DeleteFileAsync(string filePath)
    {
       var fullPath=Path.Combine(_environment.WebRootPath,filePath.TrimStart('/'));
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
           return await Task.FromResult(true);
        }
        return await Task.FromResult(true);
    }

  
}
