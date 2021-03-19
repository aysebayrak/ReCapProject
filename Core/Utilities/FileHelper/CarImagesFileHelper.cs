using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
 //dısarıdan pdf png cv gibi uzantıları almak için kurdum 
        public class CarImagesFileHelper
        {
            public static string Add(IFormFile file)
            {
                //extension=uzantı
                //Path=yol
                string extension = Path.GetExtension(file.FileName);//verilen path uzantısını büyük harfe çeviriyor.
                string newGUID = CreateGuid() + extension;
                var directory = Directory.GetCurrentDirectory() + "\\wwwroot";
                var path = directory + @"\Images";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string imagePath;
                using(FileStream fileStream = File.Create(path + "\\" + newGUID))
                {
                    file.CopyToAsync(fileStream);
                    imagePath = "/Images" + "\\" + newGUID;
                    fileStream.Flush();
            }
                return imagePath.Replace("\\", "/");

            }
            public static string Update(IFormFile file, string OldImagePath)
            {
                Delete(OldImagePath);
                return Add(file);
            }
            public static void Delete(string ImagePath)
            {
                if (File.Exists(ImagePath.Replace("/", "\\")) && Path.GetFileName(ImagePath) != "default.png")
                {
                    File.Delete(ImagePath.Replace("/", "\\"));
                }
            }

            public static string CreateGuid()
            {
                return Guid.NewGuid().ToString("N") + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;
            }
        }
    }

