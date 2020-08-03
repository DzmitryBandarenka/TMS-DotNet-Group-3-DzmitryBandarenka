using System;
using System.Text;
using System.IO;
using TMS.Nbrb.Core.Interfaces;

namespace TMS.Nbrb.Core.Services
{

    /// <inheritdoc cref="IFileService">
    public class FileService : IFileService
    {
        public void WriteToFileAsync(string text)
        {
            WriteAsync(text, Helpers.Constants.FileName);
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
