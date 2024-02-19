using System.Formats.Asn1;
using System.Globalization;
using System;
using CsvHelper;
using System.Xml.Linq;
using System.Text;

namespace Dv.IOFileManager
{
    public class DvIOFileManager
    {
        public DvIOFileManager(string path) 
        {
            Path = path;
        }

        public string Path { get; private set; }

        public string Class { get; private set; }

        public List<string> ReadCsvFile() {
            var csvRows = System.IO.File.ReadAllLines(Path, Encoding.Default).ToList();

            foreach (var row in csvRows.Skip(1))
            {
                var columns = row.Split(';');

                var field1 = columns[0];
                var field2 = columns[1];
                var field3 = columns[2];
            }

            return csvRows;
        }

        //public IEnumerable<dynamic>? ReadCsvFile()
        //{
        //    IEnumerable<dynamic>? records = null;
        //    var recx = new List<dynamic>();
        //    using (var reader = new StreamReader(Path))
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        foreach(var rec in csv.GetRecords<dynamic>().ToList())
        //        {
        //            Console.WriteLine(rec);
        //        }
        //        //records = csv.GetRecords<dynamic>();
        //        //recx= records.ToList();
        //    }
        //    foreach(var rec in records)
        //    {
        //        Console.WriteLine(rec);
        //    }
        //    var recordsList = records.ToList();
        //    return recordsList;
        //}

        public List<string> WriteCsvFile(object instance)
        {

            return new List<string>();
        }


    }
}