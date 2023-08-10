using AddressBookProblem;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Address book Problem :");
        AddressBook book = new AddressBook();
        string key = null;
        bool flag = true;
        while(flag)
        {
            Console.WriteLine( "1.Create Contact \n2.Add to Dictionary\n3.Edit Contact\n4.Display\n5.Delete Contact\n6.SearchByCityOrState\n7.Exit");
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
                    flag = false;
                    break;
            }
        }
           
    }
}