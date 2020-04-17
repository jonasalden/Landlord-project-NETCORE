using Landlord_project.Services.Interfaces;
using System.IO;

namespace Landlord_project.Services
{
    public class PictureService : IPictureService
    {
        #region Fields
        private readonly string folderPath = "\\images\\";
        #endregion

        #region Constructor
        public PictureService()
        {

        }
        #endregion

        #region Methods
        public byte[] GetBytesByPath(string webRootPath, string imageName)
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
        #endregion
    }
}
