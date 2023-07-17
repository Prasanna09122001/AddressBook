using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProblem
{
    public class AddressBook
    {
        List<Contact> addressBook = new List<Contact>(); //created list to store multiple contact
        public void CreateContact()
        {
            Console.WriteLine("Enter the detais :\n 1.First Name \n2.Last name \n3.Address \n4.City Name \n5.State Name \n.6.Zip code \n7.Phone Number \n8.Email Address ");
            Contact contact = new Contact()
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Address = Console.ReadLine(),
                City = Console.ReadLine(),
                State = Console.ReadLine(),
                Zip = Convert.ToInt32(Console.ReadLine()),
                PhoneNumber = Convert.ToInt32(Console.ReadLine()),
                Email = Console.ReadLine(),
            };
            Console.WriteLine(contact.FirstName + "\n " + contact.LastName + "\n " + contact.Address + "\n " + contact.City + "\n " + contact.State + "\n " + contact.Zip + "\n " + contact.PhoneNumber + "\n " + contact.Email);
            addressBook.Add(contact);
        }
        public void EditContact(string name)
        {
            foreach(var contact in addressBook)
            {
                if (contact.FirstName.Equals(name) || contact.LastName.Equals(name) || contact.Address.Equals(name) || contact.City.Equals(name) || contact.State.Equals(name) || contact.Zip.Equals(name) || contact.PhoneNumber.Equals(name) || contact.Email.Equals(name))
                    Console.WriteLine("Enter the Option to Edit\n1.Last Name\n2.Address\n3.city\n4.state\n5.zip\n6.phone number \n7.Email");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)

                {
                    case 1: contact.LastName = Console.ReadLine();
                        break;
                    case 2:
                        contact.Address = Console.ReadLine();
                        break;
                    case 3:
                        contact.City = Console.ReadLine();
                        break;
                    case 4:
                        contact.State = Console.ReadLine();
                        break;
                    case 5:
                        contact.Zip = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 6:
                        contact.PhoneNumber = Convert.ToInt64( Console.ReadLine());
                        break;
                    case 7:
                        contact.Email = Console.ReadLine();
                        break;
                }
            }
        }
        public void Display()
        {
            foreach (var data in addressBook)
            {
                Console.WriteLine("First name --->"+data.FirstName+"\nLast Name ----->"+data.LastName);
            }
        }
        public void DeleteContact(string name)
        {
            Contact contact = new Contact();
            foreach (var data in addressBook)
            {
                if (data.FirstName.Equals(name) || data.LastName.Equals(name))
                {
                    contact = data;
                }
            }
            addressBook.Remove(contact);
            Console.WriteLine("Contact removed");
        }
    }
}