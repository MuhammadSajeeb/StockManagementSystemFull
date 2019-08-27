using Stock.Core.Models;
using Stock.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Persistancis.ActionRepositories
{
    public class SalesRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExistInvoice()
        {
            string query = "Select Count(*)from Sales";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Sales LastExistInvoice()
        {
            Sales _Sales = null;

            string query = "Select top 1 Invoice from Sales order by Invoice desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Sales = new Sales();
                _Sales.Invoice = (reader["Invoice"].ToString());
            }
            reader.Close();

            return _Sales;
        }
        public List<Customers> GetAllCustomer()
        {
            var _CustomersList = new List<Customers>();
            string query = ("Select *From Customers");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Customers = new Customers();
                    _Customers.Id = Convert.ToInt32(reader["Id"].ToString());
                    _Customers.Name = reader["Name"].ToString();

                    _CustomersList.Add(_Customers);
                }
            }
            reader.Close();

            return _CustomersList;
        }
        public Customers GetLoyaltyByCustomer(int Id)
        {
            Customers _Customers = null;

            string query = ("Select *From Customers where Id='" + Id + "' ");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Customers = new Customers();
                _Customers.LoyaltyPoint = Convert.ToDecimal(reader["LoyaltyPoint"].ToString());
            }
            reader.Close();

            return _Customers;
        }
        public List<Products> GetAllProducts()
        {
            var __ProductsList = new List<Products>();
            string query = ("Select *From Products");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Products = new Products();
                    _Products.Code = (reader["Code"].ToString());
                    _Products.Name = reader["Name"].ToString();

                    __ProductsList.Add(_Products);
                }
            }
            reader.Close();

            return __ProductsList;
        }
        public PurchaseDetails GetProductMrpById(string code)
        {
            PurchaseDetails _PurchaseDetails = null;

            string query = ("Select top 1 NewMrp from PurchaseDetails where ProductCode='"+code+"' order by NewMrp desc ");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _PurchaseDetails = new PurchaseDetails();
                _PurchaseDetails.NewMrp = Convert.ToDecimal(reader["NewMrp"].ToString());

            }
            reader.Close();

            return _PurchaseDetails;
        }
        public decimal QtyOfPurchase(string code)
        {
            string query = "select SUM(Qty) from PurchaseDetails Where ProductCode='"+code+"' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public decimal QtyOfSales(string Product)
        {
            string query = "select SUM(Qty) from SaleDetails Where Product='" + Product + "' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int Add(SaleDetails _SaleDetails)
        {
            string query = "Insert Into SaleDetails(Product,Qty,Mrp,TotalMrp,Invoice,Date) Values ('" + _SaleDetails.Product + "','" + _SaleDetails.Qty + "','" + _SaleDetails.Mrp + "','" + _SaleDetails.TotalMrp + "','" + _SaleDetails.Invoice + "','" + DateTime.Now.ToShortDateString() + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public int Delete(int id)
        {
            string query = ("Delete From SaleDetails Where Id='" + id + "' ");
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public int UpdateLoyaltyPoint(Customers _Customers)
        {
            string query = "Update Customers SET loyaltyPoint='" + _Customers.LoyaltyPoint + "' where Id='" + _Customers.Id + "' ";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public List<SaleDetails> GetAllSalesDetails(string Invoice)
        {
            var _SaleDetailslsList = new List<SaleDetails>();
            string query = ("Select *from SaleDetails where Invoice='" + Invoice + "' ");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _SaleDetails = new SaleDetails();
                    _SaleDetails.Id = Convert.ToInt32(reader["Id"].ToString());
                    _SaleDetails.Product = reader["Product"].ToString();
                    _SaleDetails.Qty = Convert.ToDecimal(reader["Qty"].ToString());
                    _SaleDetails.Mrp = Convert.ToDecimal(reader["Mrp"].ToString());
                    _SaleDetails.TotalMrp = Convert.ToDecimal(reader["TotalMrp"].ToString());

                    _SaleDetailslsList.Add(_SaleDetails);
                }
            }
            reader.Close();

            return _SaleDetailslsList;
        }
        public decimal GrandTotal(string invoice)
        {
            string query = "select SUM(TotalMrp) from SaleDetails Where Invoice='" + invoice + "' ";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
    }
}
