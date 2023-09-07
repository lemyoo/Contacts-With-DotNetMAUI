using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.MAUI.Models
{
    public static class ContactRepository
    {
        public static List<Contact> contacts = new List<Contact>() {
            new Contact{Name="John Doe",Email="e@smsms",ContactId=1 },
            new Contact{Name="Jane Doe",Email = "1e@smsms",ContactId = 2},
        };

        public static List<Contact> GetAll() => contacts;

        public static Contact GetContact(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == id);
            if (contact != null)
            {
                return new Contact
                {
                    Name = contact.Name,
                    Email = contact.Email,
                    ContactId = contact.ContactId,
                    Address = contact.Address,
                    Phone = contact.Phone,
                };
            }
            return null;
        }

        public static void UpdateContacts(int contactId,Models.Contact contact )
        {
            if (contactId != contact.ContactId) return;

            var contactToUpdate = contacts.FirstOrDefault(x=> x.ContactId == contactId);

            if(contactToUpdate != null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
            }
        }

        public static void AddContact(Contact contact)
        {
            var maxId = contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            contacts.Add(contact);
        }

        public static void DeletContact(int contactId)
        {
            var contact = contacts.FirstOrDefault( x => x.ContactId == contactId);
            if( contact != null )
            {
                contacts.Remove(contact);
            }
        }
    }
}
