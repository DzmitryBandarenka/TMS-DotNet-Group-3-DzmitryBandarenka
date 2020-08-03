using System.Threading.Tasks;

namespace TMS.Nbrb.Core.Interfaces
{
    /// <summary>
    /// Сервис для работы с файловой системой.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Записать в файл.
        /// </summary>
        /// <param name="text">Текст.</param>
        Task WriteToFileAsync(string text);

        /// <summary>
        /// Записать в файл.
        /// </summary>
        /// <param name="text">Текст.</param>
        /// <param name="path">Путь.</param>
        Task WriteToFileAsync(string text, string path);
    }
}
