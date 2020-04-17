using System.IO;

namespace Landlord_project.Services.Interfaces
{
    public interface IPictureService
    {
        byte[] GetBytesByPath(string webRootPath, string imageName);
    }
}
