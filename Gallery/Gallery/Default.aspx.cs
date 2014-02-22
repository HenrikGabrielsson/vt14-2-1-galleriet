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
                //En ny validator som säger ifrån ifall uppladdningen misslyckas.
                CustomValidator checkUpload = new CustomValidator();
                checkUpload.ErrorMessage = "Det gick tyvärr inte att ladda upp filen";
                checkUpload.Text = "Fel!";

                //letar efter olagliga tecken i filnamnet och ersätter dem med '_';
                StringBuilder sb = new StringBuilder();
                foreach (char c in FileUpload.FileName)
                {
                    if(Path.GetInvalidFileNameChars().Contains(c))
                    {
                        sb.Append('_');
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                string sanitizedFileName = sb.ToString();

                ImageGallery imgGall = new ImageGallery();
                //här sparar filen.
                string imgName = imgGall.SaveImage(FileUpload.FileContent, sanitizedFileName);

                //check ifall uppladdningen fungerade.
                if (imgName != null)
                {
                    UploadSuccess.Text = String.Format("Bilden {0} har laddats upp utan problem!", imgName);
                    SuccessPanel.Visible = true;
                    Response.Redirect(String.Format("?Name={0}",imgName));
                }
                else
                {
                    checkUpload.IsValid = false;    
                    Page.Validators.Add(checkUpload);
                }
            }
        }

        public IEnumerable<string> GalleryRepeater_GetData()
        {
            ImageGallery imgGall = new ImageGallery();
            return imgGall.GetImageNames(); 
        }

    }
}