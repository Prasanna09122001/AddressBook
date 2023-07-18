using AddressBookProblem;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Address book Problem :");
        AddressBook book = new AddressBook();

        bool flag = true;
        while (flag)
        {
            Console.WriteLine("1.Create Contact \n2.Edit Contact\n3.Display\n4.Delete Contact\n5.Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    book.CreateContact();
                    break;
                case 2:
                    Console.WriteLine("Enter the  First name");
                    string fname = Console.ReadLine();
                    book.EditContact(fname);
                    break;
                case 3:
                    book.Display();
                    break;
                case 4:
                    string name = Console.ReadLine();
                    book.DeleteContact(name);
                    break;
                case 5:
                    flag = false;
                    break;
            }
        }

    }
}