using Stock.Core.Models;
using Stock.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Persistancis.ActionRepositories
{
    public class CustomerRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExistCode()
        {
            string query = "Select Count(*)from Customers";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Customers LastExistCode()
        {
            Customers _Customers = null;

            string query = "select top 1 Code from Customers order by Code desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Customers = new Customers();
                _Customers.Code = (reader["Code"].ToString());
            }
            reader.Close();

            return _Customers;
        }
        public decimal AlreadyExistCustomer(Customers _Customers)
        {
            string query = "Select Count(*)from Customers Where Name='" + _Customers.Name + "' And Contact='"+_Customers.Contact+"'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int Add(Customers _Customers)
        {
            string query = "Insert Into Customers(Code,Name,Email,Address,Contact,LoyaltyPoint,Images) Values ('" + _Customers.Code + "','" + _Customers.Name + "','" + _Customers.Email + "','" + _Customers.Address + "','" + _Customers.Contact + "','" + _Customers.LoyaltyPoint + "','"+_Customers.Images+"')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public int Update(Customers _Customers)
        {
            string query = "Update Customers SET  Name='" + _Customers.Name + "' WHERE Code='" + _Customers.Code + "' ";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }

        public int Delete(Customers _Customers)
        {
            string query = ("Delete From Customers Where Code ='" + _Customers.Code + "' ");
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public List<Customers> GetAllCustomers()
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
                    _Customers.Code = (reader["Code"].ToString());
                    _Customers.Name = reader["Name"].ToString();
                    _Customers.Email = reader["Email"].ToString();
                    _Customers.Address = reader["Address"].ToString();
                    _Customers.Contact = reader["Contact"].ToString();
                    _Customers.LoyaltyPoint = Convert.ToDecimal(reader["LoyaltyPoint"].ToString());
                    _Customers.Images = reader["Images"].ToString();

                    _CustomersList.Add(_Customers);
                }
            }
            reader.Close();

            return _CustomersList;
        }
    }
}
