using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace Landlord_project.Services.Interfaces
{
    public interface IPictureService
    {
        byte[] GetPictureBytesByPath(string webRootPath, string folderPath, string imageName);

        Dictionary<byte[], string> UploadPicture(IWebHostEnvironment environment, IFormFile uploadedPicture, string fileName);
    }
}
