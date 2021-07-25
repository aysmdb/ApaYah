using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApaYah.Services
{
    public class FileService
    {
        IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment e)
        {
            _env = e;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            if (file == null)
            {
                return string.Empty;
            }

            var savepath = Path.Combine(_env.WebRootPath, "upload");
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }

            var filename = file.FileName;

            var fullpath = Path.Combine(savepath, filename);

            var extensyyen = Path.GetExtension(fullpath).ToLower();

            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine("upload", filename);
        }
    }
}
