using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Gallery.Model.DAL;

namespace Gallery.Model
{
    public class Gallery
    {
        static Regex ApprovedExtensions = new Regex("^.*\\.(gif|jpg|png)$");

        string PhysicalUploadedImagesPath;
        Regex SanitizePath = new Regex("");

    }
}