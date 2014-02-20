﻿using System;
using System.Text;
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
        //regex som används för att kontrollera filändelsen.
        public static Regex ApprovedExtensions;

        static string PhysicalUploadedImagesPath;


        //Konstrucktor
        static ImageGallery()
        {
            ApprovedExtensions = new Regex("^.*\\.(gif|jpg|png)$");

            //Sökvägen till bildernas mapp
            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\Images\");
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
        private static bool ImageExists(string name)
        {
            return File.Exists(Path.Combine(PhysicalUploadedImagesPath, name))?true:false;

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

            return false;

        }

        //Funktion som sparar uppladdade bilder.
        public string SaveImage(Stream stream, string fileName)
        {

            //Kontroll så filnamnet inte är upptaget. Byter namn isåna fall.
            string ext = Path.GetExtension(fileName);
            string onlyName = Path.GetFileNameWithoutExtension(fileName);
            int i = 0;

            //Om filnamnet redan är taget så sparas bilden med ett nytt unikt namn.
            while(ImageExists(fileName))
            {
                i++;
                fileName = (String.Format("{0}({1}){2}",onlyName,i,ext));
            }

            //Skapar ett bildobjekt från strömmen och sparar den.
            Image img = Image.FromStream(stream);

            //kollar så bilden har korrekt MIME-typ och extension innan den sparas.
            if (fileName != ApprovedExtensions.Match(fileName).ToString())
            {
                throw new Exception("Den uppladdade filen hade fel format!");
            }

            //letar efter olagliga tecken i filnamnet och ersätter dem med '_';
            StringBuilder sb = new StringBuilder();
            foreach (char c in fileName)
            {
                if (Path.GetInvalidFileNameChars().Contains(c))
                {
                    sb.Append('_');
                }
                else
                {
                    sb.Append(c);
                }
            }
            string sanitizedFileName = sb.ToString();


            img.Save(String.Format("{0}\\{1}", PhysicalUploadedImagesPath, sanitizedFileName));

            //skapar en thumbnail
            createThumbnail(img, fileName);

            return fileName;
        }



        //funktion som skapar en thumbnail från en bild
        public void createThumbnail(Image img, string fileName)
        {
            //Sidorna
            double factor = img.Size.Height / img.Size.Width;
            int thumbHeight = 0;
            int thumbWidth = 0;

            //kollar vilken sida som är längst på bilden och förminskar den därefter.
            if (img.Size.Height > img.Size.Width)
            {
                factor = (double)100 / img.Size.Height;
                thumbHeight = 100;
                thumbWidth = (int)(img.Size.Width * factor);
            }
            else
            {
                factor = (double)100 / img.Size.Width;
                thumbWidth = 100;
                thumbHeight = (int)(img.Size.Height * factor);
            }

            Image thumb = img.GetThumbnailImage(thumbWidth, thumbHeight, null, IntPtr.Zero);
            thumb.Save(String.Format("{0}\\Thumbnails\\{1}", PhysicalUploadedImagesPath, fileName));
        }


    }
}