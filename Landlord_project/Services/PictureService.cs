using Landlord_project.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Landlord_project.Services
{
    public class PictureService : IPictureService
    {
        #region Fields
        private readonly string reportPath = @"images\reports\";
        #endregion

        #region Constructor
        public PictureService()
        {

        }
        #endregion

        #region Methods
        public byte[] GetPictureBytesByPath(string webRootPath, string folderPath, string imageName)
        {
            if (!string.IsNullOrEmpty(webRootPath) && !string.IsNullOrWhiteSpace(imageName))
            {
                var fullPath = webRootPath + folderPath + imageName;

                if (File.Exists(fullPath))
                {
                    var fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using var br = new BinaryReader(fileOnDisk);
                    return fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }
            }
            return null;
        }

        public Dictionary<byte[], string> UploadPicture(IWebHostEnvironment environment, IFormFile uploadedPicture, string fileName)
        {
            fileName += Path.GetExtension(uploadedPicture.FileName);

            var relImagePath = reportPath + fileName;
            var absImagePath = Path.Combine(environment.WebRootPath, relImagePath);

            byte[] imageFile;

            bool exists = Directory.Exists(Path.Combine(environment.WebRootPath,reportPath));
            if (!exists)
                Directory.CreateDirectory(Path.Combine(environment.WebRootPath, reportPath));

            using (var memoryStream = new MemoryStream())
            {
                uploadedPicture.CopyTo(memoryStream);
                imageFile = memoryStream.ToArray();
            }

            using (var fileStream = new FileStream(absImagePath, FileMode.Create))
            {
                uploadedPicture.CopyTo(fileStream);
            }

            var model = new Dictionary<byte[], string>
            {
                {imageFile, fileName}
            };

            return model;
        }
        #endregion
    }
}