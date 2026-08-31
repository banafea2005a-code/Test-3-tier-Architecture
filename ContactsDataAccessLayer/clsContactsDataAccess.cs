using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    public class clsContactsDataAccess
    {
        public static bool GetContact(int id,ref string FirstName,
            ref string LastName,ref string Email,ref string Phone,
            ref string Address,ref DateTime DateOfBirth,ref int CountryID,
            ref string ImagePath)
        {
            FirstName = ""; LastName = ""; Email = "";Phone = "";Address = "";
            DateOfBirth = DateTime.Now;CountryID = 1;ImagePath = "";


            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Contacts 
                           WHERE  contactID = @ContactID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Contact is Found
                    IsFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    // When return Image Path value Check If Null Or Not
                    // handling
                    
                    if (reader["ImagePath"] != DBNull.Value)
                    {

                        ImagePath = (string)reader["ImagePath"];

                    }
                    else
                    {
                        ImagePath = "";
                    }

                }

                else
                {
                    // Contact Is Not Found
                    IsFound= false;
                }

                reader.Close();

              
            }

            catch (Exception ex)
            {



            }

            finally { connection.Close();  }
           
            return IsFound;
        }
          
         
    }
}
