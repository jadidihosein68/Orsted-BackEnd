using Common.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Services
{
    public interface IExcelReader
    {
        IEnumerable<Employee> DecerializeInMemoryExcelToClass(Stream stream, bool hasHeadere);
    }
}
