using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CsvHelper;
using Newtonsoft.Json;

namespace AddressBookProblem
{
    public class AddressBook
    {
        int Count = 0;
        List<Contact> addressBook = new List<Contact>();
        static Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();
        Dictionary<string, List<Contact>> CityCount = new Dictionary<string, List<Contact>>();
        Dictionary<string, List<Contact>> StateCount = new Dictionary<string, List<Contact>>();
        Dictionary<string, List<Contact>> sort = new Dictionary<string, List<Contact>>();
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
                PhoneNumber = Convert.ToInt64(Console.ReadLine()),
                Email = Console.ReadLine(),
            };
            foreach (var data in dict)
            {
                foreach (var item in data.Value)
                {
                    if (item.FirstName.Equals(contact.FirstName))
                    {
                        Console.WriteLine("Your name is Already Registred in the Address Book");
                        Count++;
                    }
                }
            }
            if (Count == 0)
            {
                Console.WriteLine(contact.FirstName + " " + contact.LastName + " is added to the contact");
                addressBook.Add(contact);
            }
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
                Console.WriteLine("Data key --->" + data.Key);
                foreach (var contact in data.Value)
                {
                    Console.WriteLine("First name --->" + contact.FirstName + "\nLast Name ----->" + contact.LastName);
                }
            }
        }
        public void DeleteContact(string name, string contactName)
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
        public void SearchByCityOrState()
        {

            Console.WriteLine("Enter the number to Search\n1.City\n2.State");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                Console.WriteLine("Enter the city to search");
                string city = Console.ReadLine();
                List<Contact> contact = new List<Contact>();
                Console.WriteLine("The persons in the City are: ");
                foreach (var data in dict)
                {
                    contact = data.Value.Where(x => x.City == city).ToList();
                    foreach (var Contact in contact)
                    {
                        Console.WriteLine(Contact.FirstName + " " + Contact.LastName);
                        CityCount.Add(data.Key, contact);
                    }
                }

                Console.WriteLine("Enter the Persone Name to Search in the city");
                string name = Console.ReadLine();
                foreach (var Contact in contact)
                {
                    if (Contact.FirstName.Equals(name))
                    {
                        Console.WriteLine("The Person is found in the given city and his phone number is");
                        Console.WriteLine(Contact.FirstName + " " + Contact.LastName + " " + Contact.PhoneNumber);
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter the State to search");
                string state = Console.ReadLine();
                List<Contact> contact = new List<Contact>();
                foreach (var data in dict)
                {
                    contact = data.Value.Where(x => x.State.Equals(state)).ToList();
                }
                foreach (var Contact in contact)
                {
                    Console.WriteLine(Contact.FirstName + " " + Contact.LastName + "is found in that State");
                    StateCount.Add(state, contact);

                }

                Console.WriteLine("Enter the Persone Name to Search in this State");
                string name = Console.ReadLine();
                foreach (var Contact in contact)
                {
                    if (Contact.FirstName.Equals(name))
                    {
                        Console.WriteLine("The Person is found in the given state and his phone number is");
                        Console.WriteLine(Contact.FirstName + " " + Contact.LastName + " " + Contact.PhoneNumber);
                    }
                }
            }
        }
        public void CountCity()
        {
            int cityCount = 0;
            foreach (var data in CityCount)
            {
                Console.WriteLine("Data key --->" + data.Key);
                foreach (var contact in data.Value)
                {
                    Console.WriteLine("First name --->" + contact.FirstName + "\nLast Name ----->" + contact.LastName);
                    cityCount++;
                }
            }
            Console.WriteLine("The Number of the count in the city " + cityCount);
        }
        public void CountState()
        {
            int stateCount = 0;
            foreach (var data in StateCount)
            {
                Console.WriteLine("Data key --->" + data.Key);
                foreach (var contact in data.Value)
                {
                    Console.WriteLine("First name --->" + contact.FirstName + "\nLast Name ----->" + contact.LastName);
                    stateCount++;
                }
            }
            Console.WriteLine("The Number of the count in the State " + stateCount);
        }
        public void Sort()
        {
            Console.WriteLine("Write the number to Sort \n1.Name\n2.City\n3.State\n4.Zip");
            int num = Convert.ToInt32(Console.ReadLine());
            foreach (var data in dict.Values)
            {
                if (num == 1)
                {
                    data.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
                }
                if (num == 2)
                {
                    data.Sort((a, b) => a.City.CompareTo(b.City));
                }
                if (num == 3)
                {
                    data.Sort((a, b) => a.State.CompareTo(b.State));
                }
                if (num == 4)
                {
                    data.Sort((a, b) => a.Zip.CompareTo(b.Zip));
                }
            }
            Display();
        }
        public void ReadFromStreamWriter(string filepath)
        {
            using (StreamWriter stream = File.AppendText(filepath))
            {
                foreach (var data in dict)
                {
                    stream.WriteLine(data.Key);
                    foreach (var contact in data.Value)
                    {
                        stream.WriteLine(contact.FirstName + "," + contact.LastName + "," + contact.Address + "," + contact.City + "," + contact.State + "," + contact.Zip + "," + contact.PhoneNumber
                            + "," + contact.Email);
                    }
                }
                stream.Close();
            }
        }
        public void ReadFromStreamReader(string filepath)
        {
            using (StreamReader stream = File.OpenText(filepath))
            {
                string s = "";
                while ((s = stream.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        public void ReadCSVFile(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            {
                using (var CSV = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = CSV.GetRecords<Contact>().ToList();
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.FirstName + "---" + data.LastName + "---" + data.Address + "---" + data.City + "---" + data.State + "---" + data.Zip + "---" + data.PhoneNumber + "---" + data.Email);
                    }
                }
            }
        }
        public void WriteCSVfile(string filepath)
        {
            using (var writer = new StreamWriter(filepath))
            {
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (var data in dict)
                    {
                        csvExport.WriteRecords(data.Value);
                    }
                }
            }
        }
        public void WriteToJsonFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(dict);
            File.WriteAllText(filepath, json);
        }
        public void ReadFromJsonFile(string filepath)
        {
            var json = File.ReadAllText(filepath);
            dict = JsonConvert.DeserializeObject<Dictionary<string, List<Contact>>>(json);
            Display();
        }
        public void CreateDataBase()
        {
            SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog=master; integrated Security= true");
            try
            {
                string query = "Create Database AdvanceAddressBook";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("DataBase Created Sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no database created ");
            }
            finally
            {
                con.Close();
            }
        }
        public static SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog=AdvanceAddressBook; integrated Security= true");
        public void CreateTable()
        {
            try
            {
                string query = "Create table AddressBookDetails(id int primary key identity(1,1),firstName varchar(20),lastName varchar(20),address varchar(30),city varchar(20),state varchar(20),zip bigint,phonenumber bigint,email varchar(30),ContactTime datetime);";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no Table created " + ex);
            }
            finally
            {
                con.Close();
            }
        }
        public void AddDetails()
        {
            try
            {
                using (var reader = new StreamReader(@"D:\Bridgelabz Statement\Address Book\AddressBook\AddressBook\ContactFile.CSV"))
                {
                    using (var CSV = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = CSV.GetRecords<Contact>().ToList();
                        foreach (var data in records)
                        {

                            SqlCommand com = new SqlCommand("AddContactDetails", con);
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@firstName", data.FirstName);
                            com.Parameters.AddWithValue("@lastName", data.LastName);
                            com.Parameters.AddWithValue("@address", data.Address);
                            com.Parameters.AddWithValue("@city", data.City);
                            com.Parameters.AddWithValue("@state", data.State);
                            com.Parameters.AddWithValue("@zip", data.Zip);
                            com.Parameters.AddWithValue("@phonenumber", data.PhoneNumber);
                            com.Parameters.AddWithValue("@email", data.Email);
                            com.Parameters.AddWithValue("@ContactTime","") ;
                            con.Open();
                            com.ExecuteNonQuery();
                            Console.WriteLine("Contact Added");
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void GetAllDetails()
        {
            List<Contact> details = new List<Contact>();
            SqlCommand com = new SqlCommand("GetAllDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                details.Add(
                   new Contact
                   {
                       id = Convert.ToInt32(dr["id"]),
                       FirstName = Convert.ToString(dr["firstName"]),
                       LastName = Convert.ToString(dr["lastName"]),
                       contactdate = Convert.ToDateTime(dr["ContactTime"]),
                       Address = Convert.ToString(dr["address"]),
                       City = Convert.ToString(dr["city"]),
                       State = Convert.ToString(dr["state"]),
                       Email = Convert.ToString(dr["email"]),
                       Zip = Convert.ToInt32(dr["zip"]),
                       PhoneNumber = Convert.ToInt64(dr["phonenumber"])
                   }
                   );
            }
            foreach (var data in details)
            {
                Console.WriteLine(data.id + " " + data.FirstName + " " + data.LastName+ " " + data.Address + " " + data.City + " " + data.State+" "+data.Zip+" "+data.PhoneNumber+" "+data.Email+" "+data.contactdate);
            }
        }
        public void UpdateDetails(Contact contact)
        {
            try
            {
                SqlCommand com = new SqlCommand("EditContactDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@firstName", contact.FirstName);
                com.Parameters.AddWithValue("@lastName", contact.LastName);
                com.Parameters.AddWithValue("@address", contact.Address);
                com.Parameters.AddWithValue("@city", contact.City);
                com.Parameters.AddWithValue("@state", contact.State);
                com.Parameters.AddWithValue("@zip", contact.Zip);
                com.Parameters.AddWithValue("@phonenumber", contact.PhoneNumber);
                com.Parameters.AddWithValue("@email", contact.Email);
               // com.Parameters.AddWithValue("@ContactTime", contact.contactdate);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("DataBase Updated");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
