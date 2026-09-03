using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    public static class clsCountriesDataAccess
    {
        public static bool GetCountryInfoByID(int ID, ref string CountryName)
        {
            bool IsFound = false;



            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string query = "select * from Countries where CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);
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
        public static bool GetCountryByName(string Name, ref int ID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand("GetCountriestByName", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", Name);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;
                    ID = (int)reader["CountryID"];
                }

                reader.Close ();


            }
            catch (Exception ex)
            {

                //Console.WriteLine(ex.ToString());
                IsFound = false;

            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }
        public static int AddNewCountry(string CountryName)
        {

            // return -1 if not found Country

            int ID = -1;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand("AddNewCountry", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open ();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(),out int insertedID))
                {
                     ID = insertedID;
                }

               
            }
            catch (Exception ex)
            {

                ID = -1;
            }

            finally { connection.Close(); }


            return ID;
        }
        public static bool UpdateCountry(int CountryID, string CountryName)
        {

            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @"update Countries 
                           SET CountryName = @CountryName
                           where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {

                connection.Open();

                int IsRowEffects = command.ExecuteNonQuery();
                if (IsRowEffects > 0)
                {
                    isUpdated = true;

                }
                else
                {
                    isUpdated = false;
                }


            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
            }
            finally { connection.Close(); }

            return isUpdated;
        }
        public static bool IsExist(int CountryID)
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
        public static bool IsExist(string CountryName)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand("IsExistByName",connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CountryName", CountryName);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    IsExist = reader.HasRows;
                }

                else
                {
                    IsExist = reader.HasRows;
                }

                reader.Close();


            }
            catch (Exception ex)
            {

                //Console.WriteLine(ex.Message);
            }

            finally
            {
                connection.Close() ;
            }

            return IsExist;
        }



    }
}