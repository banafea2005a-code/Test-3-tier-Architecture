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


        

    }
}
