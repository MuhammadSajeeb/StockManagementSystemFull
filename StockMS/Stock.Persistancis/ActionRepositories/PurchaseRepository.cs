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
            string query = "Select Count(*)from Purchase";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Purchase LastExistCode()
        {
            Purchase _Purchase = null;

            string query = "select top 1 Invoice from Purchase order by Invoice desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Purchase = new Purchase();
                _Purchase.Invoice = (reader["Invoice"].ToString());
            }
            reader.Close();

            return _Purchase;
        }
    }
}
