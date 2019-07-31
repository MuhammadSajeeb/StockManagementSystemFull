using Stock.Core.Models;
using Stock.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Persistancis.ActionRepositories
{
    public class CategorySetupRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExistCode()
        {
            string query = "Select Count(*)from Categories";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Categories LastExistCode()
        {
            Categories _Categories = null;

            string query = "select top 1 Code from Categories order by Code desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Categories = new Categories();
                _Categories.Code = Convert.ToInt32(reader["Code"]);
            }
            reader.Close();

            return _Categories;
        }
    }
}
