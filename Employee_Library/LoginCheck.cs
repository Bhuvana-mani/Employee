using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Data.SqlTypes;
using EmployeeLibrary;

namespace EmployeeLibrary
{
   public class LoginCheck : CsvCreation
    {
       

        public void checkIn()
        {
            CsvCreation root = new CsvCreation();
            string FileName = root.path;
            

            Console.WriteLine("Enter the user name: ");
            var user_name = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            var password = Console.ReadLine();

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(',');
                    Employees.Add(values[0], line);
                }
            }
            var emp_record = Employees[user_name];

            if (emp_record == null && emp_record != user_name)
            {
                Console.WriteLine("Invalid User!");
            }
            else
            {
                var values = emp_record.Split(',');
                if (password == values[2] && values[3] == "Admin")
                {
                    Console.WriteLine("Admin User! - You can edit all records in csv files");
                    Console.WriteLine("Do you like to edit (Y/N): ");
                    var result = Console.ReadLine();

                    if (result == "Y" || result == "y")
                    {
                        Console.WriteLine("Enter username to edit: ");
                        var u_name = Console.ReadLine();
                        var user_data = Employees[u_name];
                        if (user_data != null)
                        {
                            Console.WriteLine("Which attribute should be edited\n\nLastName=1\nEmail=2\n\nEnter Option: ");
                            var edit_option = Console.ReadLine();
                            if (edit_option == "1")
                            {
                                Console.WriteLine("Enter new value for LastName: ");
                                var last_name = Console.ReadLine();
                                var temp = user_data.Split(',');

                                result = temp[0] + "," + last_name + "," + temp[2] + "," + temp[3] + "," + temp[4];
                                Employees[u_name] = result;

                                //Update csv file
                                File.WriteAllText(path, String.Empty);
                                File.WriteAllText(path, ExportUpdatedData());
                            }
                            else if (edit_option == "2")
                            {
                                Console.WriteLine("Enter new value for Email: ");
                                var email = Console.ReadLine();

                                var temp = user_data.Split(',');

                                result = temp[0] + "," + temp[1] + "," + temp[2] + "," + temp[3] + "," + email;
                                Employees[u_name] = result;

                                //Update csv file
                                File.WriteAllText(path, String.Empty);
                                File.WriteAllText(path, ExportUpdatedData());
                            }
                            else
                            {
                                Console.WriteLine("\n Invalid Option!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n No User record found!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("General User! - You can edit only your data");
                    Console.WriteLine("Do you like to edit (Y/N): ");
                    var result = Console.ReadLine();

                    if (result == "Y" || result == "y")
                    {
                        Console.WriteLine("Which attribute should be edited\n\nLastName=1\nEmail=2\n\nEnter Option: ");
                        var edit_option = Console.ReadLine();
                        if (edit_option == "1")
                        {
                            Console.WriteLine("Enter new value for LastName: ");
                            var last_name = Console.ReadLine();

                            result = values[0] + "," + last_name + "," + values[2] + "," + values[3] + "," + values[4];
                            Employees[user_name] = result;

                            //Update csv file
                            File.WriteAllText(path, String.Empty);
                            File.WriteAllText(path, ExportUpdatedData());
                        }
                        else if (edit_option == "2")
                        {
                            Console.WriteLine("Enter new value for Email: ");
                            var email = Console.ReadLine();

                            result = values[0] + "," + values[1] + "," + values[2] + "," + values[3] + "," + email;
                            Employees[user_name] = result;

                            //Update csv file
                            File.WriteAllText(path, String.Empty);
                            File.WriteAllText(path, ExportUpdatedData());
                        }
                        else
                        {
                            Console.WriteLine("\n Invalid Option!");
                        }
                    }

                }
            }



        }
    }
}
