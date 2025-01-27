﻿using ClosedXML.Excel;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenEMRApplication
{
    class DemoTest
    {
        [Test]
        public void JSONread()
        {
            StreamReader reader = new StreamReader(@"D:\Sollers\Azure Full Stack June 2021\SDET Track\SeleniumWebdriverConcept\OpenEMRApplication\OpenEMRApplication\TestData\data.json");
            string text = reader.ReadToEnd();
            Console.WriteLine(text);

            dynamic json=JsonConvert.DeserializeObject(text);

            Console.WriteLine(json["browser"]);
            Console.WriteLine(json["url"]);

        }



        [Test]

        public void ExcelRead1()
        {   //print one cell value

            XLWorkbook book = new XLWorkbook(@"D:\Sollers\Azure Full Stack June 2021\SDET Track\SeleniumWebdriverConcept\OpenEMRApplication\OpenEMRApplication\TestData\OpenEMRData.xlsx");
            IXLWorksheet sheet = book.Worksheet("InvalidCredentialTest");
            IXLRange range = sheet.RangeUsed();

            int rowCount = range.RowCount();
            Console.WriteLine(rowCount);
            int colCount = range.ColumnCount();
            Console.WriteLine(colCount);
            string cellValue = Convert.ToString(range.Cell(1, 1).Value);

            Console.WriteLine(cellValue);

            book.Dispose();
        }


        [Test]
        public void ExcelRead2()
        {
            XLWorkbook book = new XLWorkbook(@"D:\Sollers\Azure Full Stack June 2021\SDET Track\SeleniumWebdriverConcept\OpenEMRApplication\OpenEMRApplication\TestData\OpenEMRData.xlsx");
            IXLWorksheet sheet = book.Worksheet("InvalidCredentialTest");
            IXLRange range = sheet.RangeUsed();

            int rowCount = range.RowCount();
            Console.WriteLine(rowCount);
            int colCount = range.ColumnCount();
            Console.WriteLine(colCount);

            object[] main = new object[rowCount - 1];

            for (int r = 2; r <= rowCount; r++)
            {
                //create temp object

                object[] temp=new object[colCount];
                for (int c = 1; c <= colCount; c++)
                {
                    string cellValue = Convert.ToString(range.Cell(r, c).Value);
                    Console.WriteLine(cellValue);
                    //load temp object
                    temp[c - 1] = cellValue;
                }
                //add it to main object
                
               main[r-2]=temp;
            }

            book.Dispose();
        }

        //john,john123
        //peter,peter123
        //mark,mark123

        //how many testcase? --> how many temp object and size of main object
        //how many parameter in each testcase? --> size of tempobject
        public static object[] ValidData()
        {
            object[] temp1 = new object[2];
            temp1[0] = "john";
            temp1[1] = "john123";

            object[] temp2 = new object[2];
            temp2[0] = "peter";
            temp2[1] = "peter123";

            object[] temp3 = new object[2];
            temp3[0] = "mark";
            temp3[1] = "mark123";

            object[] main = new object[3];
            main[0] = temp1;
            main[1] = temp2;
            main[2] = temp3;

            return main;
        }

        [Test, TestCaseSource("ValidData"), Ignore("Demo Method")]
        public void ValidTest(string username, string password)
        {
            Console.WriteLine(username + password);
        }
    }
}

