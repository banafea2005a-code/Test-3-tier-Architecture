using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    static class clsCountriesDataAccess
    {
        static bool GetCountryInfoByID(int ID, ref string CountryName)
        {
            bool IsFound = false;



            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string query = "select * from Countries where CountryName = @CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // Country Is Found
                    IsFound = true;

                    CountryName = (string)reader["CountryName"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
            }
            finally
            {

                connection.Close();
            }

            return IsFound;
        }
    
    static bool IsExist(int CountryID)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string query = "select Found=1 from Countries where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    IsExist = reader.HasRows;
                }


            }
            catch (Exception ex)
            {


            }

            finally
            {
                connection.Close();

            }
            
            return IsExist;
        }
    }

}
