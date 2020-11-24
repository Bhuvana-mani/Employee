using System;
using EmployeeLibrary;
using System.IO;
using System.Collections.Generic;

namespace AdminUI
{
    class Program
    {       
        static void Main(string[] args)
        {
            CsvCreation calling = new CsvCreation();
            calling.Creation();
            LoginCheck check = new LoginCheck();
            check.checkIn();
        }
    }
}
