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
    public partial class Customer : System.Web.UI.Page
    {
        CustomerRepository _CustomerRepository = new CustomerRepository();
        public enum MessageType { Success, Failed, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AutoCodeGenerate();
                LoadCustomers();
            }
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        public void AutoCodeGenerate()
        {
            decimal AlreadyExistData = _CustomerRepository.AlreadyExistCode();
            int code = 1;
            if (AlreadyExistData >= 1)
            {
                var GetLastCode = _CustomerRepository.LastExistCode();
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
        public void LoadCustomers()
        {
            CustomerGridView.DataSource = _CustomerRepository.GetAllCustomers();
            CustomerGridView.DataBind();
        }
        public void Refresh()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtLoyaltyPoint.Text = "";
        }
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImageFileUpload.SaveAs(Server.MapPath("~/Party/CustomerImages/") + Path.GetFileName(ImageFileUpload.FileName));
                String GetImagePath = "~/Party/CustomerImages/" + Path.GetFileName(ImageFileUpload.FileName);

                Customers _Customers = new Customers();
                _Customers.Code = txtCode.Text;
                _Customers.Name = txtName.Text;
                _Customers.Email = txtEmail.Text;
                _Customers.Address = txtAddress.Text;
                _Customers.Contact = txtContact.Text;
                _Customers.LoyaltyPoint = Convert.ToDecimal(txtLoyaltyPoint.Text);
                _Customers.Images = GetImagePath;

                if (IdHiddenField.Value == "")
                {
                    decimal AlreadyExistCustomer = _CustomerRepository.AlreadyExistCustomer(_Customers);
                    if (AlreadyExistCustomer >= 1)
                    {
                        ShowMessage("This Customer Already Here!!...Enter Another Name", MessageType.Warning);
                    }
                    else
                    {
                        int Savesuccess = _CustomerRepository.Add(_Customers);
                        if (Savesuccess > 0)
                        {
                            ShowMessage("Successfully Save Customer!!...Continue Working", MessageType.Success);
                            IdHiddenField.Value = "";
                            Refresh();
                            AutoCodeGenerate();
                            LoadCustomers();
                        }
                        else
                        {
                            ShowMessage("Failed Customer Saved!!...Try Again", MessageType.Failed);
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