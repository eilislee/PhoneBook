using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Contact // Define, get, write Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public static Contact GetContact()
        {
            var contact = new Contact
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "206.555.5555"
            };
            return contact;
        }

        public static void WriteContact(Contact contact)
        {
            var contactData = $"{contact.LastName}, {contact.FirstName}, {contact.PhoneNumber}";
            FileHelper.WriteTextFileAsync("ContactTextFile.txt", contactData);
        }
    }
}
