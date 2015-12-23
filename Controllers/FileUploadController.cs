using Online_Story_Maker_Sridhar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Online_Story_Maker_Sridhar.Controllers
{
    public class FileUploadController : ApiController
    {
        //
        // GET: /FileUpload/
        public void UploadFile()
        {
          
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Gets the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    // Validates the uploaded image(optional)

                    // Gets the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);
                   
                    //Image_Table imgtb = new Image_Table();
                    //imgtb.ImageName = httpPostedFile.FileName;

                    //Image_Table 
                    // Saves the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
        }
	}
  




}