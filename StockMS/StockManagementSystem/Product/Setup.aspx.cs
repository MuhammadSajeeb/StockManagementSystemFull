using Stock.Core.Models;
using Stock.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystem.Product
{
    public partial class Setup : System.Web.UI.Page
    {
        ProductSetupRepository _ProductSetupRepository = new ProductSetupRepository();
        public enum MessageType { Success, Failed, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AutoCodeGenerate();
                GetAllCategories();
            }
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        public void AutoCodeGenerate()
        {

            decimal AlreadyExistData = _ProductSetupRepository.AlreadyExistCode();
            int code = 1;
            if (AlreadyExistData >= 1)
            {
                var GetLastCode = _ProductSetupRepository.LastExistCode();
                if (GetLastCode != null)
                {
                    code = Convert.ToInt32(GetLastCode.Code);
                    code++;
                }
                txtCode.Text = code.ToString("000");
            }
            else
            {
                txtCode.Text = "001";
            }
        }
        public void GetAllCategories()
        {
            CategoriesDropDownList.DataSource = _ProductSetupRepository.GetAllCategories();
            CategoriesDropDownList.DataTextField = "Name";
            CategoriesDropDownList.DataValueField = "Id";
            CategoriesDropDownList.DataBind();
            CategoriesDropDownList.Items.Insert(0, new ListItem("Select Category", "0"));

        }
        public void Refresh()
        {
            txtName.Text = "";
            txtReorder.Text = "";
            txtDescription.Text = "";
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImageFileUpload.SaveAs(Server.MapPath("~/Product/Images/") + Path.GetFileName(ImageFileUpload.FileName));
                String GetImagePath = "~/Product/Images/" + Path.GetFileName(ImageFileUpload.FileName);

                Products _Products = new Products();
                _Products.Code = txtCode.Text;
                _Products.Name = txtName.Text;
                _Products.ReorderLevel = Convert.ToInt32(txtReorder.Text);
                _Products.Description = txtDescription.Text;
                _Products.Images = GetImagePath;
                _Products.CategoriesId = Convert.ToInt32(CategoriesDropDownList.SelectedValue);

                int Savesuccess = _ProductSetupRepository.Add(_Products);
                if (Savesuccess > 0)
                {
                    ShowMessage("Successfully Save Product!!...Continue Working", MessageType.Success);
                    Refresh();
                    _Products.CategoriesId = Convert.ToInt32(CategoriesDropDownList.SelectedValue);
                    AutoCodeGenerate();
                }
                else
                {
                    ShowMessage("Failed Product Save!!...Continue Working", MessageType.Warning);
                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void CategoriesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoCodeGenerate();
        }
    }
}