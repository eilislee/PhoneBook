using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhoneBook
{
    public class Contact // Define, get, write Contact
    {
        private const string TEXT_FILE_NAME = "ContactTextFile.txt";
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
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, contactData);

        }

        public async static Task<ICollection<Contact>> GetContactsAsync()
        {
            var contacts = new List<Contact>();
            var fileContent = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            var lines = fileContent.Split('\r', '\n');
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var lineParts = line.Split(',');
                var contact = new Contact
                {
                    FirstName = lineParts[0],
                    LastName = lineParts[1],
                    PhoneNumber = lineParts[2]
                };
                contacts.Add(contact);
            }
            return contacts;
        }


    }
}
