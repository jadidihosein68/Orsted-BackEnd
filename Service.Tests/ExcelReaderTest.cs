using Services.Extentions;
using Xunit;
using System;
using System.IO;
using Xunit;
using Services;
using System.Linq;

namespace Service.Tests
{
    public class ExcelReaderTest
    {


        public ExcelReaderTest()
        {

            ExcelDataReaderHelper.AddEncodingSupport();
        }



        [Fact]

        public void DecerializeInMemoryExcelToClass_ShouldReturnCorrectValue() {
            using var excelFileStream = File.Open(Path.Combine(Environment.CurrentDirectory + "\\MockData", "Orsted.xlsx"), FileMode.Open, FileAccess.Read);
            var results = new ExcelReader().DecerializeInMemoryExcelToClass(excelFileStream,true).ToList();
            Assert.Equal(3, results.Count());

            Assert.Equal("001", results[0].EmployeeNumber);
            Assert.Equal("John", results[0].FirstName);
            Assert.Equal("Doe", results[0].LastName);
            Assert.Equal("Regular", results[0].EmployeeStatus);

            Assert.Equal("002", results[1].EmployeeNumber);
            Assert.Equal("Jane", results[1].FirstName);
            Assert.Equal("Doe", results[1].LastName);
            Assert.Equal("Contractor", results[1].EmployeeStatus);

            Assert.Equal("003", results[2].EmployeeNumber);
            Assert.Equal("Harry", results[2].FirstName);
            Assert.Equal("Potter", results[2].LastName);
            Assert.Equal("Regular", results[2].EmployeeStatus);

        }


        [Fact]
        public void DecerializeInMemoryExcelToClass_ShouldThrowInvalidDataException_WhenStreamDataIsInvalid()
        {

            var exception = Assert.Throws<InvalidDataException>(() => new ExcelReader().DecerializeInMemoryExcelToClass(null , true));
            Assert.Equal("Invalid excel file stream", exception.Message);
        }

    }
}
