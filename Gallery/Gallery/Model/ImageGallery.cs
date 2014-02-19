using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Gallery.Model
{
    public class ImageGallery
    {
        //regex som används för att kontrollera filändelsen och se till så filnamnet är korrekt formaterat.
        static Regex ApprovedExtensions;
        static Regex SanitizePath;

        static string PhysicalUploadedImagesPath;


        //Konstrucktor
        static ImageGallery()
        {
            ApprovedExtensions = new Regex("^.*\\.(gif|jpg|png)$");

            //Nu innehåller SanitizePath alla tecken som inte får användas.
            string invalidChars = new String(Path.GetInvalidPathChars());
            SanitizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));

            //Sökvägen till bildernas mapp
            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\Images");
        }


        //Metod som returnerar alla filnamn som finns i mappen med bilderna.
        public IEnumerable<string> GetImageNames()
        {
            FileInfo[] allFiles = new DirectoryInfo(PhysicalUploadedImagesPath).GetFiles();

            //Ny lista som fylls med namnen på filerna.
            List<string> fileNames = new List<string>();
            foreach (FileInfo file in allFiles)
            {
                fileNames.Add(file.Name);
            }

            return fileNames.AsReadOnly();
        }



        //Kollar om en bild finns
        public static bool ImageExists(string name)
        {
            FileInfo[] allFiles = new DirectoryInfo(PhysicalUploadedImagesPath).GetFiles();

            //kollar alla namn och jämför det med argumentet. Return true om nåt hittas
            foreach (FileInfo fi in allFiles)
            {
                if (fi.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        //Tar emot en bild och kontrollerar så den är av rätt filtyp (gif, jpg, png) 
        bool isValidImage(Image image)
        {
            if (
                image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid ||
                image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid ||
                image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid
                )
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //Funktion som sparar uppladdade bilder och skapar en tumnagel. //EJ KLAR
        public string SaveImage(Stream stream, string fileName)
        {
  
            //Skapar ett bildobjekt från strömmen och sparar den.
            Image img = Image.FromStream(stream);
            img.Save(String.Format("{0}\\{1}",PhysicalUploadedImagesPath, fileName));



            return null;
        }


    }
}