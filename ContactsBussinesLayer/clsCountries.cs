using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBussinesLayer
{
    public class clsCountries
    {
       
         public int CountryID {  get; set; }
        public string CountryName { get; set; }


        private clsCountries(int ID,string CountryName) { 
        
            
            CountryID = ID;
            this.CountryName = CountryName;

        
        }


        public clsCountries Find(int ID)
        {
            string CountryName = "";

            if(clsCountriesDataAccess.GetCountryInfoByID(ID,ref CountryName))
            {

                return new clsCountries(ID,CountryName);

            }
            else
            {
                return null;
            }
        }

    }
}
