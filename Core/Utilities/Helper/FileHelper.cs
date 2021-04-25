using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace Core.Utilities.Helper
{
    public static  class FileHelper
    {

        public static string Create(IFormFile file)
        {
           Image image = Image.FromStream(file.OpenReadStream());
           string currentDirectory = Directory.GetCurrentDirectory();
           string imagename = Guid.NewGuid().ToString();
           string newpath = $@"{currentDirectory}\wwwroot\Images\{imagename}.jpeg";
           image.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
           return newpath;
        }
        public static void Delete(string imagepath)
        {
            File.Delete(imagepath);
           
        }
        public static void Update(string imagepath, IFormFile file)
        {
            File.Delete(imagepath);
            Image image = Image.FromStream(file.OpenReadStream());
            image.Save(imagepath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
