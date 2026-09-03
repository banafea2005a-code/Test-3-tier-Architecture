using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBussinesLayer
{
    public class clsCountries
    {
       enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;
         public int CountryID {  get; set; }
        public string CountryName { get; set; }


        private clsCountries(int ID,string CountryName) { 
        
            Mode = enMode.Update;
            CountryID = ID;
            this.CountryName = CountryName;

        
        }
        public clsCountries()
        {
            this.Mode = enMode.AddNew;
            this.CountryID = 0;
            this.CountryName = string.Empty;

        }

        public static clsCountries Find(int ID)
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
        public static clsCountries Find(string Name)
        {

            int ID = -1;

            if(clsCountriesDataAccess.GetCountryByName(Name,ref ID))
            {

                return new clsCountries(ID,Name);
            }
            else
            {
                return null;
            }


        }
        private bool _AddNew()
        {
            this.CountryID = clsCountriesDataAccess.AddNewCountry(this.CountryName);

            return (this.CountryID > -1);


        }
        private bool _Update()
        {

            return clsCountriesDataAccess.UpdateCountry(this.CountryID, this.CountryName);

        }
        public static bool IsExist(int ID)
        {



            if (clsCountriesDataAccess.IsExist(ID))
            {

                return true;

            }
            else
            {
                return false;
            }

        }
        public static bool IsExist(string CountryName)
        {

            return clsCountriesDataAccess.IsExist(CountryName);

        }

        public bool Save()
        {

            switch(this.Mode)
            {


                case enMode.AddNew:

                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {

                        return false;
                    }

                case enMode.Update:
                   
                    if(_Update())
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }

            return false;
        }

    }
}
