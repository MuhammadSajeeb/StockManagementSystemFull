using Stock.Core.Models;
using Stock.Persistancis.ActionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystem.Purchase
{
    public partial class Confirm : System.Web.UI.Page
    {
        PurchaseRepository _PurchaseRepository = new PurchaseRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AutoInvoiceGenerate();
                GetAllSupliers();
                GetAllProducts();
                LoadPurchaseDetails();
                txtDate.Text = DateTime.Now.ToString("dd MMMM,yyyy");
            }
        }
        public void AutoInvoiceGenerate()
        {
            decimal AlreadyExistInvoice = _PurchaseRepository.AlreadyExistInvoice();
            int code = 1;
            if (AlreadyExistInvoice >= 1)
            {
                var LastExistInvoice = _PurchaseRepository.LastExistInvoice();
                if (LastExistInvoice != null)
                {
                    code = Convert.ToInt32(LastExistInvoice.Invoice);
                    code++;
                }
                txtInvoice.Text = code.ToString("000");
            }
            else
            {
                txtInvoice.Text = "001";
            }
        }
        public void GetAllSupliers()
        {
            SuplierDropDownList.DataSource = _PurchaseRepository.GetAllSupliers();
            SuplierDropDownList.DataTextField = "Name";
            SuplierDropDownList.DataValueField = "Id";
            SuplierDropDownList.DataBind();
            SuplierDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Supliers", "0"));

        }
        public void GetAllProducts()
        {
            ProductDropDownList.DataSource = _PurchaseRepository.GetAllProducts();
            ProductDropDownList.DataTextField = "Name";
            ProductDropDownList.DataValueField = "Id";
            ProductDropDownList.DataBind();
            ProductDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Products", "0"));

        }
        public void NewMrpCalculation()
        {
            decimal unitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            decimal Percent = 25;

            decimal cal = Percent / 100;
            decimal PercentAmount = cal * unitPrice;
            decimal Mrpamount = unitPrice + PercentAmount;
            txtMrp.Text = Convert.ToDecimal(Mrpamount).ToString("00.00");

        }
        public void LoadPurchaseDetails()
        {
            string Invoice;
            Invoice = txtInvoice.Text;

            PurchaseGridView.DataSource = _PurchaseRepository.GetAllPurchaseDetails(Invoice);
            PurchaseGridView.DataBind();
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseDetails _PurchaseDetails = new PurchaseDetails();
                _PurchaseDetails.ProductCode = txtCode.Text;
                _PurchaseDetails.ManufacturedDate = Convert.ToDateTime(txtManufacturedDate.Text).ToShortDateString();
                _PurchaseDetails.ExpireDate = Convert.ToDateTime(txtExpireDate.Text).ToShortDateString();
                _PurchaseDetails.Qty = Convert.ToDecimal(txtQty.Text);
                _PurchaseDetails.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                _PurchaseDetails.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text);
                _PurchaseDetails.NewMrp = Convert.ToDecimal(txtMrp.Text);
                _PurchaseDetails.Invoice = txtInvoice.Text;

                int successAdd = _PurchaseRepository.Add(_PurchaseDetails);
                if (successAdd > 0)
                {
                    LoadPurchaseDetails();
                     
                }
                else
                {
                     
                }
            }
            catch
            {

            }
        }

        protected void PurchaseGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int successdelete = _PurchaseRepository.Delete(Convert.ToInt32(e.CommandArgument));
                if (successdelete > 0)
                {
                    LoadPurchaseDetails();
                }
                else
                {

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
                int Id = Convert.ToInt32(ProductDropDownList.SelectedValue);
                var getCode = _PurchaseRepository.GetProductCode(Id);
                if (getCode != null)
                {
                    txtCode.Text = (getCode.Code).ToString();
                    //txtQty.Text = "";
                    //txtQty.Focus();
                    //txtSubPrice.Text = "";
                }
            }
            catch
            {
            }
        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalPrice.Text = (decimal.Parse(txtQty.Text) * decimal.Parse(txtUnitPrice.Text)).ToString();
                NewMrpCalculation();
            }
            catch
            { }
        }
    }
}