using AddressBookProblem;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Address book Problem :");
        AddressBook book = new AddressBook();
        book.CreateContact();
    }
}