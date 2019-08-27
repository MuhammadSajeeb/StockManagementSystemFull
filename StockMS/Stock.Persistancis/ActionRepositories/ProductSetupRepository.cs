using Stock.Core.Models;
using Stock.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Persistancis.ActionRepositories
{
    public class ProductSetupRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExistCode()
        {
            string query = "Select Count(*)from Products";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Products LastExistCode()
        {
            Products _Products = null;

            string query = "select top 1 Code from Products order by Code desc";
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
        public decimal AlreadyExistName(Products _Products)
        {
            string query = "Select Count(*)from Products Where Name='" + _Products.Name + "' And CategoriesId='"+_Products.CategoriesId+"'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int Add(Products _Products)
        {
            string query = "Insert Into Products(Code,Name,ReorderLevel,Description,Images,CategoriesId) Values ('" + _Products.Code + "','" + _Products.Name + "','" + _Products.ReorderLevel + "','" + _Products.Description + "','" + _Products.Images + "','"+_Products.CategoriesId+"')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public List<Categories> GetAllCategories()
        {
            var _CategoryList = new List<Categories>();
            string query = ("Select *From Categories");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Category = new Categories();
                    _Category.Id = Convert.ToInt32(reader["Id"].ToString());
                    _Category.Name = reader["Name"].ToString();

                    _CategoryList.Add(_Category);
                }
            }
            reader.Close();

            return _CategoryList;
        }
    }
}
