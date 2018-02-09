using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SwiftPMModel
{
    class ValidateFileAttribute : RequiredAttribute

    {
        public override bool IsValid(object value)
        {
            var uploadedFile = value as HttpPostedFileBase;
            if (uploadedFile == null)
            {
                return true;
            }

            if (uploadedFile.ContentLength > 1 * 400 * 400)
            {
                return false;
            }
            try
            {
                // coding soon
                return false;
            }
            catch { }
            return false;
        }
    }
}
