using Stock.Core.Models;
using Stock.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystem.Party
{
    public partial class Suplier : System.Web.UI.Page
    {
        SuplierRepository _SuplierRepository = new SuplierRepository();
        public enum MessageType { Success, Failed, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessage("Failed Suplier Saved!!...Try Again", MessageType.Failed);
                AutoCodeGenerate();
                LoadSuplier();
            }
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        public void AutoCodeGenerate()
        {
            decimal AlreadyExistData = _SuplierRepository.AlreadyExistCode();
            int code = 1;
            if (AlreadyExistData >= 1)
            {
                var GetLastCode = _SuplierRepository.LastExistCode();
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
        public void LoadSuplier()
        {
            SuplierGridView.DataSource = _SuplierRepository.GetAllCustomers();
            SuplierGridView.DataBind();
        }
        public void Refresh()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtContactPerson.Text = "";
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SuplierImageFileUpload.SaveAs(Server.MapPath("~/Party/Images/") + Path.GetFileName(SuplierImageFileUpload.FileName));
                String GetImagePaths = "~/Party/Images/" + Path.GetFileName(SuplierImageFileUpload.FileName);

                Supliers _Supliers = new Supliers();
                _Supliers.Code = txtCode.Text;
                _Supliers.Name = txtName.Text;
                _Supliers.Email = txtEmail.Text;
                _Supliers.Address = txtAddress.Text;
                _Supliers.Contact = txtContact.Text;
                _Supliers.ContactPerson = (txtContactPerson.Text);
                _Supliers.Images = GetImagePaths;

                if (IdHiddenField.Value == "")
                {
                    decimal AlreadyExistCustomer = _SuplierRepository.AlreadyExistSuplier(_Supliers);
                    if (AlreadyExistCustomer >= 1)
                    {
                        ShowMessage("This Suplier Already Here!!...Enter Another Name", MessageType.Warning);
                    }
                    else
                    {
                        int Savesuccess = _SuplierRepository.Add(_Supliers);
                        if (Savesuccess > 0)
                        {
                            ShowMessage("Successfully Save Suplier!!...Continue Working", MessageType.Success);
                            IdHiddenField.Value = "";
                            Refresh();
                            AutoCodeGenerate();
                            LoadSuplier();
                        }
                        else
                        {
                            ShowMessage("Failed Suplier Saved!!...Try Again", MessageType.Failed);
                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }
    }
}