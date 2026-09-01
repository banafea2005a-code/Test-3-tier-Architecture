using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    public static class clsContactsDataAccess
    {
        public static bool GetContact(int id, ref string FirstName,
            ref string LastName, ref string Email, ref string Phone,
            ref string Address, ref DateTime DateOfBirth, ref int CountryID,
            ref string ImagePath)
        {
            FirstName = ""; LastName = ""; Email = ""; Phone = ""; Address = "";
            DateOfBirth = DateTime.Now; CountryID = 1; ImagePath = "";


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
                    IsFound = false;
                }

                reader.Close();


            }

            catch (Exception ex)
            {

                // Later Add Log Error FIle

            }

            finally { connection.Close(); }

            return IsFound;
        }

        public static int AddNewContact(string FirstName, string LastName,
            string Email, string Phone, string Address, DateTime DateOfBirth,
            int CountryID, string ImagePath)
        {


            int ContactID = -1;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Contacts (FirstName,LastName,Email,Phone,Address,DateOfBirth,CountryID,ImagePath)
             Values(@FirstName,@LastName,@Email,@Phone,@Address,@DateOfBirth,@CountryID,@ImagePath);
             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != string.Empty)
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            }
            else
            {
                command.Parameters.AddWithValue("@imagePath", DBNull.Value);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ContactID = InsertedID;


                }






            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally { connection.Close(); }

            return ContactID;

        }


        public static bool UpdateContact (int ID,string FirstName, string LastName,
            string Email, string Phone, string Address, DateTime DateOfBirth,
            int CountryID, string ImagePath)
        {
            int RowsEffects = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string query = @"Update Contacts
                       Set FirstName = @FirstName,
                       LastName = @LastName,
                       Email = @Email,
                       Phone = @Phone,
                       Address = @Address,
                       DateOfBirth = @DateOfBirth,
                       CountryID = @CountryID,
                       ImagePath = @ImagePath
                       Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);
            command.Parameters.AddWithValue ("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName",LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            

            // handle when ImagePath is Null
            if(ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath",DBNull.Value);
            }


            try
            {

                connection.Open();

                RowsEffects = command.ExecuteNonQuery();

              
            }
            catch (Exception ex)
            {

                return false ;
            }


            finally { connection.Close(); }

            return (RowsEffects > 0);
        }

    }
}
