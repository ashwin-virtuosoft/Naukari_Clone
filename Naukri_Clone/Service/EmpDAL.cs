using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace Naukri_Clone.wwwroot.Service
{
    public class EmpDAL
    {
        private readonly IConfiguration _configuration;

        public EmpDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public  bool InsertEmployer(string EfName, string ElName, string email, long phoneNumber, string password, DateTime dateOfBirth,string Designation,string OrganizationName)
        {
            string ConnectionString = _configuration.GetConnectionString("MyDB");
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using(SqlCommand command=new SqlCommand("SpInsertEmployer", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@EFName", EfName);
                    command.Parameters.AddWithValue("@ElName", ElName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@Designation", Designation);
                    command.Parameters.AddWithValue("@OrganizationName", OrganizationName);

                    command.ExecuteNonQuery();
                    return true;
                }
                
            }
        }
    }

}
