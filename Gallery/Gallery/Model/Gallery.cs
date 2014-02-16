using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Gallery.Model
{
    public class Gallery
    {
        //regex som används för att kontrollera filändelsen och se till så filnamnet är korrekt formaterat.
        static Regex ApprovedExtensions;
        static Regex SanitizePath;
   
        static string PhysicalUploadedImagesPath;
        
        public static string testString;

        //Konstrucktor
        static Gallery()
        {
            ApprovedExtensions = new Regex("^.*\\.(gif|jpg|png)$");

            //Nu innehåller SanitizePath alla tecken som inte får användas.
            string invalidChars= new String(Path.GetInvalidPathChars());
            SanitizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));

            //Sökvägen till bildernas mapp
            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\Images");
        }

        //Metod som returnerar alla filnamn som finns i mappen med bilderna.
        public IEnumerable<string> GetImageNames()
        {
            FileInfo[] allFiles = new DirectoryInfo(PhysicalUploadedImagesPath).GetFiles();
            
            return null;
        }

        //Kollar om en bild verkligen finns
        public static bool ImageExists(string name)
        {
            FileInfo[] allFiles = new DirectoryInfo(PhysicalUploadedImagesPath).GetFiles();

            //kollar alla namn och jämför det med argumentet. Return true om nåt hittas
            foreach(FileInfo fi in allFiles)
            {
                if(fi.Name == name)
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

        //Funktion som sparar uppladdade bilder och skapar en tumnagel.
        public string SaveImage(Stream stream, string fileName)
        {
            return null;
        }

   
    }
}