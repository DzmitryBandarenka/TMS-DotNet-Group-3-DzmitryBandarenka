using System.Collections.Generic;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Models;

namespace TMS.Nbrb.Core.Interfaces
{
    /// <summary>
    /// Сервис для отправки запросов.
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Получить список всех валют.
        /// </summary>
        /// <returns>Список всех валют.</returns>
        public Task<IEnumerable<Currency>> GetAllCurreciesAsync();

        /// <summary>
        /// Получить курс валюты.
        /// </summary>
        /// <param name="code">Код валюты.</param>
        /// <returns>Курс валюты.</returns>
        public Task<Rates> GetRatesAsync(string code);
    }
}
