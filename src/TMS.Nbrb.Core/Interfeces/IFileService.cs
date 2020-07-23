using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Nbrb.Core.Interfeces
{
    public interface IFileService
    {
        public void WriteToFileAsync(string text);
        public void WriteToFileAsync(string text, string path);
    }
}
