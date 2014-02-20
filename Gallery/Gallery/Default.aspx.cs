using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gallery.Model;

namespace Gallery
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Om en bild skickas med i URL:n så visas den.
            if (Request.QueryString["Name"] != null)
            {
                string imgFull = Request.QueryString["Name"];
                ImageDisplay.ImageUrl = String.Format("~//Content//Images//{0}", imgFull);

                ImageDisplay.Visible = true;
         

            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if(IsValid)
            { 
                //här sparas bilden som skickas upp
                ImageGallery imgGall = new ImageGallery();

                //letar efter olagliga tecken i filnamnet och ersätter dem med '_';
                StringBuilder sb = new StringBuilder();
                foreach (char c in FileUpload.FileName)
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

                string imgName = imgGall.SaveImage(FileUpload.FileContent, sanitizedFileName);

                UploadSuccess.Text = String.Format("Bilden {0} har laddats upp utan problem!", imgName);
                UploadSuccess.Visible = true;
            }

        }

        public IEnumerable<string> GalleryRepeater_GetData()
        {
            ImageGallery imgGall = new ImageGallery();
            return imgGall.GetImageNames(); 
        }

        protected void UploadFailValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //hämtar filnamnet på den uppladdade filen
            string fileName = FileUpload.FileName;

            //kollar om filändelsen är ok.
            if (fileName == ImageGallery.ApprovedExtensions.Match(fileName).ToString())
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }


    }
}