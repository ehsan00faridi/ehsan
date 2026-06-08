using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICacheService
    {
        Task<string> GetValueAsync(string key);
        Task SetValueAsync(string key, string value, TimeSpan expiry);
    }
}
