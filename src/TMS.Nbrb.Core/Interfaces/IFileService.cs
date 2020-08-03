/// <summary>
/// Сервис для работы с файловой системой.
/// </summary>
namespace TMS.Nbrb.Core.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Записать в файл.
        /// </summary>
        /// <param name="text">Текст.</param>
        public void WriteToFileAsync(string text);
        /// <summary>
        /// Записать в файл.
        /// </summary>
        /// <param name="text">Текст.</param>
        /// <param name="path">Путь.</param>
        public void WriteToFileAsync(string text, string path);
    }
}
