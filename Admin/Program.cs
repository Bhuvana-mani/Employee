using System;
using EmployeeLibrary;

namespace Admin
{
    class Admin  
    {

        //private static IEmployeeRepository _applicantRepository;
        public void Creation()
        {
            // writing admin detail to csv file
            string[] Admin_detail = new string[5] { "Bhuvana", "Mani", true, "bhuvana@yahoo.com", "bhuvana!7" };
            using (var file = File.CreateText(path))
            {
                foreach (var arr in Admin_detail)
                {
                    if (String.IsNullOrEmpty(arr)) continue;
                    file.Write(arr[0]);
                    for (int i = 1; i < arr.Length; i++)
                    {
                        file.Write(',');
                        file.Write(arr[i]);
                    }
                    file.WriteLine();
                }
            }
        }
            
        static void Main(string[] args)
        {
           
        }
    }
}
