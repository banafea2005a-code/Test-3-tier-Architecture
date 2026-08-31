using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;

namespace ContactsBussinesLayer
{
    public class clsContacts
    {
        enum enMode { AddNew =0,Update=1 };
        private enMode Mode = enMode.AddNew;
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }

        public clsContacts( int contactID, string firstName, string lastName, string email, string phone, string address, DateTime dateOfBirth, int countryID, string imagePath)
        {
            
            ContactID = contactID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            DateOfBirth = dateOfBirth;
            CountryID = countryID;
            ImagePath = imagePath;
        }

        public static clsContacts Find(int ID)
        {
            string FirstName = "";string LastName = "";string Email="";
            string Phone = ""; string Address = "";
            DateTime DateOfBirth = DateTime.Now; int CountryID = 1;
            string ImagePath = "";

            if(clsContactsDataAccess.GetContact(ID,ref FirstName, ref LastName,
               ref Email, ref Phone, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath)){

                return new clsContacts(ID, FirstName, LastName, Email, Phone, Address,
                    DateOfBirth, CountryID, ImagePath);


            }
            return null;

        }
        

    }
}
