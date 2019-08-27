using Stock.Core.Models;
using Stock.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Persistancis.ActionRepositories
{
    public class PurchaseRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExistInvoice()
        {
            string query = "Select Count(*)from Purchases";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Purchases LastExistInvoice()
        {
            Purchases _Purchase = null;

            string query = "Select top 1 Invoice from Purchases order by Invoice desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Purchase = new Purchases();
                _Purchase.Invoice = (reader["Invoice"].ToString());
            }
            reader.Close();

            return _Purchase;
        }
        public List<Supliers> GetAllSupliers()
        {
            var _SupliersList = new List<Supliers>();
            string query = ("Select *From Supliers");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Supliers = new Supliers();
                    _Supliers.Id = Convert.ToInt32(reader["Id"].ToString());
                    _Supliers.Name = reader["Name"].ToString();

                    _SupliersList.Add(_Supliers);
                }
            }
            reader.Close();

            return _SupliersList;
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
                    _Products.Id = Convert.ToInt32(reader["Id"].ToString());
                    _Products.Name = reader["Name"].ToString();

                    __ProductsList.Add(_Products);
                }
            }
            reader.Close();

            return __ProductsList;
        }
        public Products GetProductCode(int Id)
        {
            Products _Products = null;

            string query = ("Select *From Products where Id='" + Id + "' ");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Products = new Products();
                _Products.Code = (reader["Code"].ToString());
            }
            reader.Close();

            return _Products;
        }
        public int Add(PurchaseDetails _PurchaseDetails)
        {
            string query = "Insert Into PurchaseDetails(ProductCode,ManufacturedDate,ExpireDate,Qty,UnitPrice,TotalPrice,NewMrp,Invoice,Date) Values ('" + _PurchaseDetails.ProductCode + "','" + _PurchaseDetails.ManufacturedDate + "','" + _PurchaseDetails.ExpireDate + "','" + _PurchaseDetails.Qty + "','" + _PurchaseDetails.UnitPrice + "','"+ _PurchaseDetails.TotalPrice+ "','"+ _PurchaseDetails.NewMrp+ "','"+ _PurchaseDetails.Invoice+ "','" + DateTime.Now.ToShortDateString() + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        //public int Update(PurchaseDetails _PurchaseDetails)
        //{
        //    string query = "Update ItemSales SET Qty='" + _PurchaseDetails.Qty + "',Sub_Price='" + _PurchaseDetails.Sub_Price + "' where Id='" + _PurchaseDetails.Id + "' ";
        //    return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        //}
        public int Delete(int id)
        {
            string query = ("Delete From PurchaseDetails Where Id='" + id + "' ");
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public List<PurchaseDetails> GetAllPurchaseDetails(string Invoice)
        {
            var _PurchaseDetailsList = new List<PurchaseDetails>();
            string query = ("Select *from PurchaseDetails where Invoice='" + Invoice + "' ");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _PurchaseDetails = new PurchaseDetails();
                    _PurchaseDetails.Id = Convert.ToInt32(reader["Id"].ToString());
                    _PurchaseDetails.ProductCode = reader["ProductCode"].ToString();
                    _PurchaseDetails.ManufacturedDate = (reader["ManufacturedDate"].ToString());
                    _PurchaseDetails.ExpireDate = (reader["ExpireDate"].ToString());
                    _PurchaseDetails.Qty = Convert.ToDecimal(reader["Qty"].ToString());
                    _PurchaseDetails.UnitPrice = Convert.ToDecimal(reader["UnitPrice"].ToString());
                    _PurchaseDetails.TotalPrice = Convert.ToDecimal(reader["TotalPrice"].ToString());
                    _PurchaseDetails.NewMrp = Convert.ToDecimal(reader["NewMrp"].ToString());

                    _PurchaseDetailsList.Add(_PurchaseDetails);
                }
            }
            reader.Close();

            return _PurchaseDetailsList;
        }
        public int Submit(Purchases _Purchase)
        {
            string query = "Insert Into Purchases(SuplierId,Invoice,Date) Values ('" + _Purchase.SuplierId + "','" + _Purchase.Invoice + "','" + DateTime.Now.ToShortDateString() + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
    }
}
