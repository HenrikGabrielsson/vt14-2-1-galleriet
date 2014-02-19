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

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            //här sparas bilden som skickas upp
            ImageGallery imgGall = new ImageGallery();

            Label.Text = imgGall.SaveImage(FileUpload.FileContent, FileUpload.FileName);

             
        }

        public IEnumerable<string> GalleryRepeater_GetData()
        {
            ImageGallery imgGall = new ImageGallery();

            return imgGall.GetImageNames(); 
        }

    }
}