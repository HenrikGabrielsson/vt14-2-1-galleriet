using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Gallery.Model
{
    public class Gallery
    {
        //regex som används för att kontrollera filändelsen
        static Regex ApprovedExtensions = new Regex("^.*\\.(gif|jpg|png)$");
        
        //regex som används för att kontrollera så filnamn innehåller godkända tecken.
        Regex SanitizePath = new Regex("");
   
        string PhysicalUploadedImagesPath = @"~/Content/Images";


    }
}