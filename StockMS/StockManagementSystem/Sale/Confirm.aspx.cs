using Stock.Core.Models;
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
                LoadSaleDetails();
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
        public void LoadSaleDetails()
        {
            string Invoice;
            Invoice = txtInvoice.Text;

            SalesGridView.DataSource = _SalesRepository.GetAllSalesDetails(Invoice);
            SalesGridView.DataBind();
        }
        public void GrandTotal()
        {
            string invoice = txtInvoice.Text;

            decimal Grandtotal = _SalesRepository.GrandTotal(invoice);

            txtGrandTotal.Text = Convert.ToDecimal(Grandtotal).ToString();

            decimal OldLoyalty = Convert.ToDecimal(txtLoyaltyPoint.Text);
            decimal loyaltypoint = Grandtotal / 1000;
            decimal newloyaltypoint = OldLoyalty + loyaltypoint;
            decimal discountpercent = newloyaltypoint / 10;

            txtDiscount.Text = Convert.ToDecimal(discountpercent).ToString("00");

            decimal cal = discountpercent / 100;
            decimal discountAmount = cal * Grandtotal;
            decimal PayableAmount = Grandtotal - discountAmount;

            txtPayableAmount.Text = Convert.ToDecimal(PayableAmount).ToString("00.00");


        }
        protected void CustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtLoyaltyPoint.Text = "";
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
                txtMrp.Text = "";
                txtAvailableQty.Text = "";
                string code = (ProductDropDownList.SelectedValue);
                string Name = (ProductDropDownList.SelectedItem).ToString();
                var getData = _SalesRepository.GetProductMrpById(code);
                if (getData != null)
                {
                    txtMrp.Text = Convert.ToDecimal(getData.NewMrp).ToString();
                     
                    decimal PurchaseQty = _SalesRepository.QtyOfPurchase(code);
                    decimal SalesQty = _SalesRepository.QtyOfSales(Name);

                    decimal cal = PurchaseQty - SalesQty;
                    txtAvailableQty.Text = Convert.ToDecimal(cal).ToString("00");

                }

            }
            catch
            {
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaleDetails _SaleDetails=new SaleDetails();

                _SaleDetails.Product = ProductDropDownList.SelectedItem.ToString();
                _SaleDetails.Qty = Convert.ToDecimal(txtQty.Text);
                _SaleDetails.Mrp = Convert.ToDecimal(txtMrp.Text);
                _SaleDetails.TotalMrp = Convert.ToDecimal(txtTotalMrp.Text);
                _SaleDetails.Invoice = txtInvoice.Text;

                decimal CurrentQty = Convert.ToDecimal(txtAvailableQty.Text);

                if(CurrentQty > 0)
                {
                    int Addsuccess = _SalesRepository.Add(_SaleDetails);
                    if(Addsuccess > 0)
                    {
                        LoadSaleDetails();
                        GrandTotal();
                    }
                }
                else
                {

                }

            }
            catch
            {

            }
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalMrp.Text = (decimal.Parse(txtMrp.Text) * decimal.Parse(txtQty.Text)).ToString();

            }
            catch
            { }
        }

        protected void SalesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int successdelete = _SalesRepository.Delete(Convert.ToInt32(e.CommandArgument));
                if (successdelete > 0)
                {
                    LoadSaleDetails();
                }
                else
                {

                }
            }
            catch
            {

            }
        }
    }
}