using _0_Framework.Utilities;
using _01_Framework.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.IO;

namespace ServiceHost.Uploder
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public long GetDiskSpaceByPath(string path)
        {
            long size = 0;
            var directoryPath = $"{_webHostEnvironment.WebRootPath}//UploadedFiles//{path}";
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            foreach (FileInfo fi in dir.GetFiles("*.*", SearchOption.AllDirectories))
            {
                size += fi.Length;
            }
            return size / 1000000;
        }

        public void RemovePicture(string photo)
        {
            var directoryPath = $"{_webHostEnvironment.WebRootPath}//UploadedFiles//{photo}";

            if (File.Exists(directoryPath))
                File.Delete(directoryPath);

        }

        public string Upload(IFormFile file, string path)
        {
            if (file == null) return "";

            var directoryPath = $"{_webHostEnvironment.WebRootPath}//UploadedFiles//{path}";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
         
            var fileName = DateTime.Now.ToFileName() + file.FileName;
            var filePath = $"{directoryPath}//{fileName}";
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);
            return $"{path}/{fileName}";
        }

        //public string UploadWithWaterMark(IFormFile file, string path)
        //{
        //    if (file == null) return "";
        //    var directoryPath = $"{_webHostEnvironment.WebRootPath}//UploadedFiles//{path}";

        //    if (!Directory.Exists(directoryPath))
        //    {
        //        Directory.CreateDirectory(directoryPath);
        //    }

        //    var fileName = DateTime.Now.ToFileName() + file.FileName;

        //    var filePath = $"{directoryPath}//{fileName}";
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {

        //        using (Bitmap bmp = new Bitmap(stream, false))
        //        {
        //            using (Graphics grp = Graphics.FromImage(bmp))
        //            {
        //                Brush brush = new SolidBrush(Color.Red);

        //                Font font = new System.Drawing.Font("Arial", 50, FontStyle.Bold, GraphicsUnit.Pixel);
        //                const string waterMArk = "NiaSmart.com";
        //                SizeF textSize = new SizeF();
        //                textSize = grp.MeasureString(waterMArk, font);

        //                Point position = new Point((bmp.Width - ((int)textSize.Width + 10)), (bmp.Height - ((int)textSize.Height + 10)));
        //                grp.DrawString("NiaSmart.com", font, brush, position);
        //            }
        //        }

        //        file.CopyTo(stream);

        //    }

        //    return $"{path}/{fileName}";
        //}

        public string UploadDocument(IFormFile file, string Type, string path)
        {
            if (file == null) return "";

            var directoryPath = $"{_webHostEnvironment.WebRootPath}//UploadedFiles//{path}";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var fileName = DateTime.Now.ToFileName() + Type + file.FileName;
            var filePath = $"{directoryPath}//{fileName}";
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);
            return $"{path}/{fileName}";
        }

    }
}
