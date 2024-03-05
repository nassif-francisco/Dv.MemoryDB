using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.TypeConversion;
using Dv.MemoryDB;

namespace Dv.IOFileManager
{
    public class DvIOFileController//<T> where T: DvTable
    {
        public DvIOFileController(string path)
        {
            Path = path;
        }

        public string Path { get; private set; }

        public string? Class { get; private set; }
        public string? FileContent { get; private set; }

        public string? LineContent { get; private set; }

        public StreamReader StreamReader { get; private set; }

        public async Task<string> ReadCsvFile()
        {
            try
            {
                using (var sr = new StreamReader(Path))
                {  
                    FileContent = await sr.ReadToEndAsync();                                  
                }
            }
            catch (FileNotFoundException ex)
            {
                FileContent = ex.Message;
            }
            return FileContent;
        }
        
        public void InitializeStreamReader()
        {
            try
            {
                StreamReader = new StreamReader(Path);
                
            }
            catch
            {
                Console.WriteLine("Can not find file");
            }
            
        }

        public async Task<string> ReadCsvFirstLine()
        {                      
            LineContent = await StreamReader.ReadLineAsync();
            return LineContent;         
        }

        public async Task<string> ReadCsvParametersLine()
        {         
            LineContent = await StreamReader.ReadLineAsync();
            return LineContent;          
        }

        public async IAsyncEnumerable<string> ReadCsvFileLineByLineAsync()
        {
            //can not be enclosed in try/catch block
            using (StreamReader)
            {
                while (StreamReader.Peek() >= 0)
                {
                    LineContent = await StreamReader.ReadLineAsync();
                    yield return LineContent;
                }
                     
            }

        }

        public IEnumerable<string> ReadCsvFileLine()
        {
            //try
            //{
            using (var sr = new StreamReader(Path))
            {
                while (sr.Peek() >= 0)
                {
                    FileContent = sr.ReadLine();
                    yield return FileContent;
                }
            }
               
            //}
            //catch (FileNotFoundException ex)
            //{
            //    FileContent = ex.Message;
            //}
        }

        static async IAsyncEnumerable<string> ReadCharacters()
        {
            String result;
            using (StreamReader reader = File.OpenText("existingfile.txt"))
            {
                Console.WriteLine("Opened file.");
                result = await reader.ReadLineAsync();
                yield return result;
                Console.WriteLine("First line contains: " + result);
            }
        }
    }
}
