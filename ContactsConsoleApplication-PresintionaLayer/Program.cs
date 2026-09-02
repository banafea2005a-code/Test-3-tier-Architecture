using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsBussinesLayer;
namespace ContactsConsoleApplication_PresintionaLayer
{
    
    internal class Program
    {
        static void TestFind(int ID)
        {

            clsContacts contact = clsContacts.Find(ID);


            if (contact != null)
            {
                Console.WriteLine($"ContactID : {contact.ContactID}");
                Console.WriteLine($"Name  : {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Email : {contact.Email}");
                Console.WriteLine($"Phone : {contact.Phone}");
                Console.WriteLine($"Address : {contact.Address}");
                Console.WriteLine("Date Of Birth : {0:yyyy-MM-dd}", contact.DateOfBirth);
                Console.WriteLine($"CountryID : {contact.CountryID}");
                Console.WriteLine($"ImagePath : {contact.ImagePath}");

            }

            else
            {
                Console.WriteLine($"Contact with ID {ID} not found.");
            }

        }
        static void TestAddNewContact(string FirstName, string LastName,String Email,string Phone,
            string Address,DateTime DateOfBirth,int CountryID,string ImagePath)
        {

           clsContacts NewContact = new clsContacts();

            NewContact.FirstName = FirstName;
            NewContact.LastName = LastName;
            NewContact.Email = Email;
            NewContact.Phone = Phone;
            NewContact.Address = Address;
            NewContact.DateOfBirth = DateOfBirth;
            NewContact.CountryID = CountryID;
            NewContact.ImagePath = ImagePath;


            if (NewContact.Save())
            {
                Console.WriteLine("Contact is Added Successfuly");

            }
            else
            {
                Console.WriteLine("Contact is Failed Addedd");
            }

        }

        static void TestUpdateContact(int ID)
        {
            clsContacts contact = clsContacts.Find(ID);

            contact.FirstName = "SABRY";
            contact.LastName = "Mansor";
            contact.Email = "Sabry@gmail.com";
            contact.Phone = "778554996";
            contact.Address = "ADEN-SAKANEH";
            contact.DateOfBirth = new DateTime(2006, 5, 4, 12, 30, 10);
            contact.CountryID = 1;
            contact.ImagePath = string.Empty;


            if (contact.Save())
            {
                Console.WriteLine("Contact Updated Successfuly");

            }
            else
            {
                Console.WriteLine("Contact Updated Failed");
            }

        }
        static void TestDeleteContact(int ID)
        {

            if (clsContacts.IsContactExsist(ID))
            {
                if (clsContacts.DeletContactByID(ID))
                {

                    Console.WriteLine("Contact Deleted SuccessFully");

                }
                else
                {
                    Console.WriteLine("Contact Deleted Failed");
                }
            }
            else
            {
                Console.WriteLine($"The Contact With ID : {ID} Is Not Found ");
            }
        }
        static void TestListContacts()
        {

            DataTable dtContacts = clsContacts.GetAllContact();


            foreach (DataRow row in dtContacts.Rows)
            {
                Console.WriteLine($"{row["ContactID"]}, {row["FirstName"]} {row["LastName"]}");

            }

        }
        static void TestIsContactExist(int ID)
        {

            if (clsContacts.IsContactExsist(ID))
            {

                Console.WriteLine("yes, Contact is Exists");

            }
            else
            {
                Console.WriteLine("No, Contact is not Exists");

            }

        }

        static void TestFindCountriesByID(int ID)
        {

            clsCountries Country = clsCountries.Find(ID);

            if (Country != null)
            {
                Console.WriteLine("CountryID : " + Country.CountryID);
                Console.WriteLine("CountryName : " + Country.CountryName);


            }

            else
            {

                Console.WriteLine($"Country With ID : {Country.CountryID} is Not FOund ");
            }

        }
        static void Main(string[] args)
        {
            //TestFind(1);

            //TestAddNewContact("Mohammed", "bassam", "A@gmail.com", "884522","USA-Aden", new DateTime(2003, 4, 30,10,30,0),
            //    1, "");

            //TestUpdateContact(1009);


            //TestDeleteContact(1009);

            //TestListContacts();

            //TestIsContactExist(5);


            TestFindCountriesByID(1);
        }
    }
}
