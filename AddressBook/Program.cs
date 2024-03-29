﻿using AddressBookProblem;
using System.Text;

public class Program
{
    static string filepath = @"D:\Bridgelabz Statement\Address Book\AddressBook\AddressBook\ContactFile.txt";
    static string filepath1 = @"D:\Bridgelabz Statement\Address Book\AddressBook\AddressBook\ContactFile.CSV";
    static string filepath2 = @"D:\Bridgelabz Statement\Address Book\AddressBook\AddressBook\ContactFile.json";
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Address book Problem :");
        AddressBook book = new AddressBook();
        string key = null;
        bool flag = true;
        while(flag)
        {
            Console.WriteLine( "1.Create Contact \n2.Add to Dictionary\n3.Edit Contact\n4.Display\n5.Delete Contact\n6.SearchByCityOrState\n7.CityCount\n8.StateCount\n9.Sort By name,city,State or Zipcode" +
                "\n10.Write in the File\n11.Read the Text File\n12.Read the CSV file\n13.Write CSV File\n14.Write Json File\n15.Read Json File\n16.Retreive Data from the Database\n17.Update Data in Database" +
                "\n18.get records in particular period\n19.Count in city\n20.count in state\n21.Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    book.CreateContact();
                    break;
                case 2:
                    book.AddAddressBookToDictionary();
                    break;
                case 3:
                    Console.WriteLine("Enter Key");
                    key = Console.ReadLine();
                    Console.WriteLine("Enter the  First name");
                    string fname = Console.ReadLine();
                    book.EditContact(key,fname);
                    book.EditContact(key, fname);
                    break;
                case 4:
                    book.Display();
                    break;
                case 5:
                    Console.WriteLine("Enter Key");
                    key = Console.ReadLine();
                    string name = Console.ReadLine();
                    book.DeleteContact(key,name);
                    book.DeleteContact(key, name);
                    break;
                case 6:
                    book.SearchByCityOrState();
                    break;
                case 7:
                    book.CountCity();
                    break;
                case 8:
                    book.CountState();
                    break;
                case 9:
                    book.Sort();
                    break;
                case 10:
                    book.ReadFromStreamWriter(filepath);
                    break;
                case 11:
                    book.ReadFromStreamReader(filepath);
                    break;
                case 12:
                    book.ReadCSVFile(filepath1);
                    break;
                case 13:
                    book.WriteCSVfile(filepath1);
                    break;
                case 14:
                    book.WriteToJsonFile(filepath2);
                    break;
                case 15:
                    book.ReadFromJsonFile(filepath2);
                    break;
                case 16:
                    book.CreateDataBase();
                    book.CreateTable();
                    book.AddDetails();
                    book.GetAllDetails();
                    break;
                case 17:

                    Contact details = new Contact()
                    {
                        FirstName = "naren",
                        LastName = "Kishore R S",
                        Address = "street2",
                        City = "Cbe",
                        State = "TamilNadu",
                        Zip = 600001,
                        PhoneNumber = 9876543210,
                        Email = "naren@gmail.com"
                    };
                    book.UpdateDetails(details);
                    break;
                case 18:
                    book.RetreivedatainaParticularPeriod("04-09-2023 15:00:00");
                    break;
                case 19:
                    book.CityCountinDatabase();
                    break;
                case 20:
                    book.StateCountinDatabase();
                    break;
                case 21:
                   Contact contact = new Contact()
                    {
                        FirstName = "Mukesh",
                        LastName = "Mukkara",
                        Address = "street1",
                        City = "Andhra",
                        State = "Andhra Pradesh",
                        Zip = 500001,
                        PhoneNumber = 9567654356,
                        Email = "mukesh@gmail.com"
                    };
                    book.AddNewContactDetails(contact);
                    break;
                default:
                    flag = false;
                    break;
            }
        }
    }
}