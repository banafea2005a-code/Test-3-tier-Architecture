using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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
        public string Code { get; set; }
        public string PhoneCode { get; set; }

        private clsCountries(int ID,string CountryName,string Code,string PhoneCode) { 
        
            Mode = enMode.Update;
            CountryID = ID;
            this.CountryName = CountryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;

        
        }
        public clsCountries()
        {
            this.Mode = enMode.AddNew;
            this.CountryID = 0;
            this.CountryName = string.Empty;
            this.Code = string.Empty;
            this.PhoneCode = string.Empty;
        }

        public static clsCountries Find(int ID)
        {
            string CountryName = ""; string Code = "";string PhoneCode = "";


            if(clsCountriesDataAccess.GetCountryInfoByID(ID,ref CountryName,ref Code,ref PhoneCode))
            {

                return new clsCountries(ID,CountryName,Code,PhoneCode);

            }
            else
            {
                return null;
            }
        }
        public static clsCountries Find(string Name)
        {

            int ID = -1;
            string Code = ""; string PhoneCode = "";

            if (clsCountriesDataAccess.GetCountryByName(Name,ref ID,ref Code,ref PhoneCode))
            {

                return new clsCountries(ID,Name,Code,PhoneCode);
            }
            else
            {
                return null;
            }


        }
        private bool _AddNew()
        {
            this.CountryID = clsCountriesDataAccess.AddNewCountry(this.CountryName,this.Code,this.PhoneCode);

            return (this.CountryID > -1);


        }
        private bool _Update()
        {

            return clsCountriesDataAccess.UpdateCountry(this.CountryID, this.CountryName,this.Code,this.PhoneCode);

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
        public static DataTable GetAllCountries()
        {

            return clsCountriesDataAccess.GetAllCountries();


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

        static public bool DeleteCountryByID(int ID)
        {

            return clsCountriesDataAccess.DeleteCountryByID(ID);
        }
    }
}
