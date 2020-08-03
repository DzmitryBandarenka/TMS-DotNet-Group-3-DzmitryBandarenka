using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Interfaces;
using TMS.Nbrb.Core.Models;
using TMS.Nbrb.Core.Helpers;
namespace TMS.Nbrb.Core.Services
{
    /// <inherindoc cref="IRequestService">
    public class RequestService : IRequestService
    {
        public async Task<IEnumerable <Currency>> GetAllCurreciesAsync()
        {
            var currency = await Constants.UrlApiCurriency
             .GetJsonAsync <List<Currency>>();

            return currency;
        }
        /// <summary>
        /// Получить курсы валют.
        /// </summary>
        /// <param name="code">код валюты</param>
        /// <returns></returns>
        public async Task<Rates> GetRatesAsync(string code) {
            var rate = await Constants.UrlApiRates
             .AppendPathSegment(code)
             .GetJsonAsync<Rates>();

            return rate;
        }


        
    }
}
