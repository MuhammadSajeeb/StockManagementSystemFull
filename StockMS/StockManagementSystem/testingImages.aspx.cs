using Stock.Core.Models;
using Stock.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystem
{
    public partial class testingImages : System.Web.UI.Page
    {
        CategorySetupRepository _CategorySetupRepository = new CategorySetupRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                Images images = new Images();

                HttpPostedFile postedFile = FileUpload1.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int fileSize = postedFile.ContentLength;

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                    || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    images.Name = filename;
                    images.Size = fileSize;
                    images.ImageData = bytes;

                    int success = _CategorySetupRepository.AddIamges(images);
                    if(success>0)
                    {
                        lblMessage.Text = "success";
                    }
                    else
                    {
                        lblMessage.Text = "failed";
                    }
                }
            }
            catch(Exception ex)
            {

            }

        }
    }
}