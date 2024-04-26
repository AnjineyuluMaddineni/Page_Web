using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.IO;

namespace Page_Pl.Helper
{
    public static class DocSettgings
    {
        public static string UploadFile(IFormFile file,string FolderName)
        { 
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
            string FileName = $"{Guid.NewGuid()}{file.FileName}";
            string FilePath=Path.Combine(FolderPath,FileName);
            using var FS=new FileStream(FilePath, FileMode.Create);
            file.CopyTo(FS);
            return FileName;
        }
        public static void DeleteFile(string FileName,string FolderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName,FileName);
            if(File.Exists(FolderPath))
            {
                File.Delete(FolderPath);
            }
        }
    }
}
