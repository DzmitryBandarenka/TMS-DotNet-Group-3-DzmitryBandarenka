using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using Microsoft.VisualBasic;
using TMS.Nbrb.Core.Helpers;

namespace TMS.Nbrb.Core.Services
{
    public class FileService
    {
        public void WriteToFileAsync(string text)
        {
            WriteAsync(text, Helpers.Constants.path);
        }

        public void WriteToFileAsync(string text, string path)
        {
                WriteAsync(text, path);
        }
        
        private async void WriteAsync(string text, string path)
        { 
                try
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    await sw.WriteLineAsync(text);
                }
                Console.WriteLine("Данные успешно записаны в файл");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
