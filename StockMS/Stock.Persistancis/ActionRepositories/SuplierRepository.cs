using Stock.Core.Models;
using Stock.Persistancis.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Persistancis.ActionRepositories
{
    public class SuplierRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExistCode()
        {
            string query = "Select Count(*)from Supliers";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Supliers LastExistCode()
        {
            Supliers _Supliers = null;

            string query = "select top 1 Code from Supliers order by Code desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Supliers = new Supliers();
                _Supliers.Code = (reader["Code"].ToString());
            }
            reader.Close();

            return _Supliers;
        }
        public decimal AlreadyExistSuplier(Supliers _Supliers)
        {
            string query = "Select Count(*)from Supliers Where Name='" + _Supliers.Name + "' And Contact='"+_Supliers.Contact+"'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int Add(Supliers _Supliers)
        {
            string query = "Insert Into Supliers(Code,Name,Email,Address,Contact,ContactPerson,Images) Values ('" + _Supliers.Code + "','" + _Supliers.Name + "','" + _Supliers.Email + "','" + _Supliers.Address + "','" + _Supliers.Contact + "','" + _Supliers.ContactPerson + "','" + _Supliers.Images + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public int Update(Supliers _Supliers)
        {
            string query = "Update Supliers SET  Name='" + _Supliers.Name + "' WHERE Code='" + _Supliers.Code + "' ";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }

        public int Delete(Supliers _Supliers)
        {
            string query = ("Delete From Supliers Where Code ='" + _Supliers.Code + "' ");
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public List<Supliers> GetAllCustomers()
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
                    _Supliers.Code = (reader["Code"].ToString());
                    _Supliers.Name = reader["Name"].ToString();
                    _Supliers.Email = reader["Email"].ToString();
                    _Supliers.Address = reader["Address"].ToString();
                    _Supliers.Contact = reader["Contact"].ToString();
                    _Supliers.ContactPerson =(reader["ContactPerson"].ToString());
                    _Supliers.Images = reader["Images"].ToString();

                    _SupliersList.Add(_Supliers);
                }
            }
            reader.Close();

            return _SupliersList;
        }
    }
}
