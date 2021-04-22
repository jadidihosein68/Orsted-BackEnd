using Common.Model;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class ExcelReader : IExcelReader
    {
        public IEnumerable<Employee> DecerializeInMemoryExcelToClass(Stream stream, bool hasHeadere)
        {

            List<Employee> users = new List<Employee>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            try
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        users.Add(new Employee
                        {
                            EmployeeNumber = reader.GetValue(0).ToString(),
                            FirstName = reader.GetValue(1).ToString(),
                            LastName = reader.GetValue(2).ToString(),
                            EmployeeStatus = reader.GetValue(3).ToString()
                        });
                    }
                }
                return hasHeadere ? users.Skip(1) : users;
            }
            catch
            {
                throw new InvalidDataException("Invalid excel file stream");
            }
        }
    }
}
