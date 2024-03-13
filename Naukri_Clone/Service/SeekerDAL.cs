using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace Naukri_Clone.Service
{
    public class SeekerDAL
    {
 
       private readonly IConfiguration _configuration;

        public SeekerDAL(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }


        public bool InsertSeeker(string fName, string lName, string email, long phoneNumber, string password, DateTime dateOfBirth)
        {
            string connectionString = _configuration.GetConnectionString("MyDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SpInsertJobSeeker", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

               
                    command.Parameters.AddWithValue("@FName", fName);
                    command.Parameters.AddWithValue("@LName", lName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                    command.ExecuteNonQuery();
                    return true; 
                   
                      
                }
            }
        }
    }
}
