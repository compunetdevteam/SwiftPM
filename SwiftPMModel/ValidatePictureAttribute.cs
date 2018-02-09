using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace SwiftPMModel
{
    public class ValidatePictureAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var uploadedFile = value as HttpPostedFileBase;
            if (uploadedFile == null)
            {
                return true;
            }

            if (uploadedFile.ContentLength > 1 * 200 * 200)
            {
                return false;
            }

            try
            {
                using (var img = Image.FromStream(uploadedFile.InputStream))
                {

                    if (img.RawFormat == (ImageFormat.Png) || img.RawFormat ==(ImageFormat.Jpeg) || img.RawFormat==ImageFormat.Bmp)
                    {
                        return true;
                    }

                  //return img.RawFormat == (img.RawFormat.Equals(ImageFormat.Png) ? ImageFormat.Png : ImageFormat.Jpeg) ;
                }
            }
            catch { }
            return false;
        }
    }
}