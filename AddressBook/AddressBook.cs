using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProblem
{
    public class AddressBook
    {
        List<Contact> addressBook = new List<Contact>(); 
        Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();
        public void CreateContact()
        {
            Console.WriteLine("Enter the detais :\n 1.First Name \n2.Last name \n3.Address \n4.City Name \n5.State Name \n.6.Zip code \n7.Phone Number \n8.Email Address ");
            Contact contact = new Contact()
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
              //  Address = Console.ReadLine(),
              //  City = Console.ReadLine(),
              //  State = Console.ReadLine(),
              //  Zip = Convert.ToInt32(Console.ReadLine()),
              //  PhoneNumber = Convert.ToInt64(Console.ReadLine()),
              //  Email = Console.ReadLine(),
                Address = "SS",
                City = "SS",
                State = "SS",
                Zip = 11,
                PhoneNumber =11,
                Email = "ss",
            };
            Console.WriteLine(contact.FirstName + " " + contact.LastName + " is added to the contact");
            addressBook.Add(contact);
        }
        public void AddAddressBookToDictionary()
        {
            Console.WriteLine("Enter the unique Name");
            string uniquename = Console.ReadLine();
            dict.Add(uniquename, addressBook);
            addressBook = new List<Contact>();
        }
        public void EditContact(string name, string contactName)
        {
            foreach (var data in dict)
            {
                if (data.Key.Equals(name))
                {
                    foreach (var contact in data.Value)
                    {
                        if (contact.FirstName.Equals(contactName) || contact.LastName.Equals(contactName))
                        {
                            Console.WriteLine("Enter the Option to Edit\n1.Last Name\n2.Address\n3.city\n4.state\n5.zip\n6.phone number \n7.Email");
                            int option = Convert.ToInt32(Console.ReadLine());
                            switch (option)

                            {
                                case 1:
                                    contact.LastName = Console.ReadLine();
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
                                    contact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                                    break;
                                case 7:
                                    contact.Email = Console.ReadLine();
                                    break;
                            }
                        }
                    }
                }
            }
        }
        public void Display()
        {
            foreach (var data in dict)
            {
                Console.WriteLine("Data key --->"+data.Key);
                foreach(var contact in data.Value)
                {
                    Console.WriteLine("First name --->" + contact.FirstName + "\nLast Name ----->" + contact.LastName);
                }
            }
        }
        public void DeleteContact(string name,string contactName)
        {
            Contact contact = new Contact();
            foreach (var data in dict)
            {
                if (data.Key.Equals(name))
                {
                    foreach (var item in data.Value)
                    {
                        if (item.FirstName.Equals(contactName) || item.LastName.Equals(contactName))
                        {
                            contact = item;
                        }
                    }
                    data.Value.Remove(contact);
                    Console.WriteLine("Contact removed");
                }
            }
        }
    }
}