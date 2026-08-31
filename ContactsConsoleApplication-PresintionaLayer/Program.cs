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
        static void Main(string[] args)
        {
            TestFind(1);
        }
    }
}
