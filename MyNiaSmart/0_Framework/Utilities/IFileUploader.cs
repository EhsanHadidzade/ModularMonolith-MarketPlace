using Microsoft.AspNetCore.Http;

namespace _01_Framework.Application
{
    public interface IFileUploader
    {
        string Upload(IFormFile file, string path);
        //string UploadWithWaterMark(IFormFile file, string path);

        //Get Size OF Given Root Calculated in MB unit
        long GetDiskSpaceByPath(string path);
        string UploadDocument(IFormFile file, string Type, string path);
        void RemovePicture(string UserPhoto);
    }
}
