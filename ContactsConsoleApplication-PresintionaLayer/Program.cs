using System;
using System.Collections.Generic;
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
        static void Main(string[] args)
        {
            //TestFind(1);

            //TestAddNewContact("Mohammed", "bassam", "A@gmail.com", "884522","USA-Aden", new DateTime(2003, 4, 30,10,30,0),
            //    1, "");

            TestUpdateContact(1009);
        }
    }
}
