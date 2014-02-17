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
            
        }

        public IEnumerable<string> GalleryRepeater_GetData()
        {
            ImageGallery imgGall = new ImageGallery();

            return imgGall.GetImageNames();
 
        }

    }
}