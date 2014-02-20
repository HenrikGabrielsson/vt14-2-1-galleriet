using System;
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

                string imgName = imgGall.SaveImage(FileUpload.FileContent, FileUpload.FileName);

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
            
        }


    }
}