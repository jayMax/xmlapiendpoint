using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlApiEndpoint.Services
{
    public interface IStorageService
    {
        Task SaveDataAsync(string data);
    }
}
