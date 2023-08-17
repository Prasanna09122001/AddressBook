using AddressBookProblem;
using System.Text;

internal class Program
{
    static string filepath = @"D:\Bridgelabz Statement\Address Book\AddressBook\AddressBook\ContactFile.txt";
    static string filepath1 = @"D:\Bridgelabz Statement\Address Book\AddressBook\AddressBook\ContactFile.CSV";
    public static void Main(string[] args)
    {
        
        Console.WriteLine("Welcome to Address book Problem :");
        AddressBook book = new AddressBook();
        string key = null;
        bool flag = true;
        while(flag)
        {
            Console.WriteLine( "1.Create Contact \n2.Add to Dictionary\n3.Edit Contact\n4.Display\n5.Delete Contact\n6.SearchByCityOrState\n7.CityCount\n8.StateCount\n9.Sort By name,city,State or Zipcode\n10.Write in the File\n11.Read the Text File");
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
                default:
                    flag = false;
                    break;
            }
        }
    }
}