using Stock.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystem.Sale
{
    public partial class Confirm : System.Web.UI.Page
    {
        SalesRepository _SalesRepository = new SalesRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AutoInvoiceGenerate();
                GetAllCustomers();
                GetAllProducts();
            }
        }
        public void AutoInvoiceGenerate()
        {
            decimal AlreadyExistInvoice = _SalesRepository.AlreadyExistInvoice();
            int code = 1;
            if (AlreadyExistInvoice >= 1)
            {
                var LastExistInvoice = _SalesRepository.LastExistInvoice();
                if (LastExistInvoice != null)
                {
                    code = Convert.ToInt32(LastExistInvoice.Invoice);
                    code++;
                }
                txtInvoice.Text = code.ToString("000");
            }
            else
            {
                txtInvoice.Text = "100";
            }
        }
        public void GetAllCustomers()
        {
            CustomerDropDownList.DataSource = _SalesRepository.GetAllCustomer();
            CustomerDropDownList.DataTextField = "Name";
            CustomerDropDownList.DataValueField = "Id";
            CustomerDropDownList.DataBind();
            CustomerDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Customer", "0"));

        }
        public void GetAllProducts()
        {
            ProductDropDownList.DataSource = _SalesRepository.GetAllProducts();
            ProductDropDownList.DataTextField = "Name";
            ProductDropDownList.DataValueField = "Code";
            ProductDropDownList.DataBind();
            ProductDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Products", "0"));

        }

        protected void CustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(CustomerDropDownList.SelectedValue);
                var getData = _SalesRepository.GetLoyaltyByCustomer(Id);
                if (getData != null)
                {
                    txtLoyaltyPoint.Text = (getData.LoyaltyPoint).ToString();
                    //txtQty.Text = "";
                    //txtQty.Focus();
                    //txtSubPrice.Text = "";
                }
            }
            catch
            {
            }
        }

        protected void ProductDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string code = (ProductDropDownList.SelectedValue);
                var getData = _SalesRepository.GetProductMrpById(code);
                if (getData != null)
                {
                    txtMrp.Text = Convert.ToDecimal(getData.NewMrp).ToString();
                    //txtQty.Text = "";
                    //txtQty.Focus();
                    //txtSubPrice.Text = "";
                }
            }
            catch
            {
            }
        }
    }
}