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

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string query = "select * from Countries where CountryName = @CountryName";



        }
    }
}
