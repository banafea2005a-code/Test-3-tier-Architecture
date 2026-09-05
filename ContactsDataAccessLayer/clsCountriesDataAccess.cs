using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    public static class clsCountriesDataAccess
    {
        public static bool GetCountryInfoByID(int ID, ref string CountryName,ref string Code,ref
            string PhoneCode)
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
                    Code = Convert.ToString(reader["Code"]);
                    PhoneCode = Convert.ToString(reader["PhoneCode"]);
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
        public static bool GetCountryByName(string Name, ref int ID,ref string Code,ref string PhoneCode)
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

                if (reader.Read())
                {
                    IsFound = true;
                    ID = (int)reader["CountryID"];
                    Code = Convert.ToString(reader["Code"]);
                    PhoneCode = Convert.ToString(reader["PhoneCode"]);
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
        public static int AddNewCountry(string CountryName,string Code,string PhoneCode)
        {

            // return -1 if not found Country

            int ID = -1;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand("AddNewCountry", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CountryName", CountryName);
           
            if(!string.IsNullOrEmpty(Code))
            {
                command.Parameters.AddWithValue("@Code", Code);
            }
            else
            {
                command.Parameters.AddWithValue("@Code", DBNull.Value);
            }

            if(!string.IsNullOrEmpty(PhoneCode))
            {
                command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
            }
            else
            {
                command.Parameters.AddWithValue("@PhoneCode", DBNull.Value);
            }

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
        public static bool UpdateCountry(int CountryID, string CountryName,string Code,string PhoneCode)
        {

            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @"update Countries 
                           SET CountryName = @CountryName,
                           Code = @Code,
                           PhoneCode = @PhoneCode
                           where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            if (!string.IsNullOrEmpty(Code))
            {
                command.Parameters.AddWithValue("@Code", Code);
            }
            else
            {
                command.Parameters.AddWithValue("@Code", DBNull.Value);
            }
            
            if (!string.IsNullOrEmpty(PhoneCode))
            {
                command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
            }
            else
            {
                command.Parameters.AddWithValue("@PhoneCode", DBNull.Value);
            }

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

        public static bool DeleteCountryByID(int ID)
        {
            bool IsDeleted = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand("DeleteCountryByID", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ID",ID);


            try
            {

                connection.Open();

                int RowEffects = command.ExecuteNonQuery();

                if(RowEffects > 0)
                {

                    IsDeleted = (RowEffects > 0);   
                }



            }
            catch (Exception ex)
            {


            }


            finally
            {
                connection.Close();
            }

            return IsDeleted;
            }
        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand("GetAllCountries", connection);

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    dt.Load(reader);
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

            return dt;
        }

        
    }
}