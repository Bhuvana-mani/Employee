using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlTypes;
using System.Linq;

namespace EmployeeLibrary
{
    public class CsvCreation
    {
        private readonly string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private readonly string _applicationDirectory = "EmployeeManagement";
        private readonly string _fileName = "EmployeeProject.csv";
        public string path;

        public CsvCreation()
        { 

            var directory = Path.Combine(_appData, _applicationDirectory);
               if (!Directory.Exists(directory))
               {
                   Directory.CreateDirectory(directory);
               }
                  path = Path.Combine(directory, _fileName);
               if (!File.Exists(path))
               {
                   using (File.Create(path)) { }
               }

    }

    List<string> fields = new List<string>();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        public static Dictionary<string, string> Employees = new Dictionary<string, string>();
        Dictionary<string, object> currentRow { get { return rows[rows.Count - 1]; } }

       
        public object this[string field]
        {
            set
            {
                
                if (!fields.Contains(field)) fields.Add(field);
                currentRow[field] = value;
            }
        }

       
        public void AddRow()
        {
            rows.Add(new Dictionary<string, object>());
        }

        public  string ExportUpdatedData()
        {
            StringBuilder sb = new StringBuilder();

            // The rows
            foreach (var pair in Employees)
            {
                sb.Append(pair.Value);
                sb.AppendLine();
            }

            return sb.ToString();
        }
        string MakeValueCsvFriendly(object value)
        {
            if (value == null) return "";
            
            string output = value.ToString();
            
            return output;
        }
        
       
        public string Export()
        {
            StringBuilder sb = new StringBuilder();

            
            foreach (string field in fields)
                sb.Append(field).Append(",");
            sb.AppendLine();

           
            foreach (Dictionary<string, object> row in rows)
            {
                foreach (string field in fields)
                    sb.Append(MakeValueCsvFriendly(row[field])).Append(",");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void ExportToFile(string path)
        {
            File.WriteAllText(path, Export());
        }

        public byte[] ExportToBytes()
        {
            return Encoding.UTF8.GetBytes(Export());
        }
        

           public void Creation()
           {

                 string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                 string _applicationDirectory = "EmployeeManagement";
                 string _fileName = "EmployeeProject.csv";
           


               var directory = Path.Combine(_appData, _applicationDirectory);
               if (!Directory.Exists(directory))
               {
                   Directory.CreateDirectory(directory);
               }
               var path = Path.Combine(directory, _fileName);
               if (!File.Exists(path))
               {
                   using (File.Create(path)) { }
               }

                       CsvCreation myExport = new CsvCreation();
               
               myExport.AddRow();
               myExport["FirstName"] = "Sahanaa";
               myExport["LastName"] = "Mani";
               myExport["Password"] = "saha";
               myExport["Privilege"] = "Admin";
               myExport["Email"] = "saha@gmail.com";

               myExport.AddRow();
               myExport["FirstName"] = "Nandhana";
               myExport["LastName"] = "Mani";
               myExport["Password"] = "nandu";
               myExport["Privilege"] = "Employee";
               myExport["Email"] = "nandu@gmail.com";
               myExport.ExportToFile(path);
               byte[] myCsvData = myExport.ExportToBytes();
            Console.WriteLine("Your file has been created");
               
           } 

    }
}

