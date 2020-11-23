using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EmployeeLibrary
{
    class LoginCheck : CsvCreation
    {

        public void checkIn()
        {
            CsvCreation root = new CsvCreation();
            string FileName = root.path;
            string firstNameInput;
            string passwordInput;

            Dictionary<string, string> Employees = new Dictionary<string, string>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(',');
                    Employees.Add(values[0], values[2]);

                    foreach (var pair in Employees)
                    {
                        Console.WriteLine($"Employee with key {pair.Key}: password={pair.Value} ");
                    }
                    //Console.WriteLine("Key: {0}, Value: {1}", dictionary.Keys, dictionary.Values);
                }
            }


        }
    }
}
