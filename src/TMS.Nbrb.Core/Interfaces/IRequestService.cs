using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Models;

namespace TMS.Nbrb.Core.Interfaces
{
   public interface IRequestService
    {
        public Task<IEnumerable<Currency>> GetAllCurreciesAsync();
        public Task<Rates> GetRatesAsync(string code);
    }
}
