using Stock.Core.Models;
using Stock.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystem.Category
{
    public partial class Setup : System.Web.UI.Page
    {
        CategorySetupRepository _CategorySetupRepository = new CategorySetupRepository();
        public enum MessageType { Success, Failed, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AutoCodeGenerate();
                LoadCategories();
            }
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        public void AutoCodeGenerate()
        {
            decimal AlreadyExistData = _CategorySetupRepository.AlreadyExistCode();
            int code = 1;
            if (AlreadyExistData >= 1)
            {
                var GetLastCode = _CategorySetupRepository.LastExistCode();
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
        public void LoadCategories()
        {
            CategoriesGridView.DataSource = _CategorySetupRepository.GetAllCategories();
            CategoriesGridView.DataBind();
        }

        protected void CategorySaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Categories _Categories = new Categories();
                _Categories.Code = txtCode.Text;
                _Categories.Name = txtName.Text;

                if(IdHiddenField.Value=="")
                {
                    decimal AlreadyExistName = _CategorySetupRepository.AlreadyExistName(_Categories);
                    if(AlreadyExistName>=1)
                    {
                        ShowMessage("This Category Already Here!!...Enter Another Name", MessageType.Warning);
                    }
                    else
                    {
                        int Savesuccess = _CategorySetupRepository.Add(_Categories);
                        if(Savesuccess > 0)
                        {
                            ShowMessage("Successfully Save Category!!...Continue Working", MessageType.Success);
                            txtName.Text = "";
                            IdHiddenField.Value = "";
                            AutoCodeGenerate();
                            LoadCategories();
                        }
                        else
                        {
                            ShowMessage("Failed Category Saved!!...Try Again", MessageType.Failed);
                        }
                    }
                }
                else
                {
                    int Updatesuccess = _CategorySetupRepository.Update(_Categories);
                    if (Updatesuccess > 0)
                    {
                        ShowMessage("Successfully Update Category!!...Continue Working", MessageType.Success);
                        txtName.Text = "";
                        IdHiddenField.Value = "";
                        CategorySaveButton.Text = "Save";
                        AutoCodeGenerate();
                        LoadCategories();
                    }
                    else
                    {
                        ShowMessage("Failed Category Update!!...Try Again", MessageType.Failed);
                    }
                }
            }
            catch(Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void CategoriesGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdHiddenField.Value = CategoriesGridView.SelectedRow.Cells[1].Text;
            txtCode.Text= CategoriesGridView.SelectedRow.Cells[1].Text;
            txtName.Text = CategoriesGridView.SelectedRow.Cells[2].Text;

            CategorySaveButton.Text = "Update";
             
        }

        protected void CategoriesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CategoriesGridView.PageIndex = e.NewPageIndex;
            LoadCategories();
        }
    }
}