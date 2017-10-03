using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XmlApiEndpoint.Models;

namespace XmlApiEndpoint.Data
{
    public class TrafficContext
    {
        private readonly List<Traffic> _trafficData;

        public TrafficContext()
        {
            _trafficData = new List<Traffic>();

            for (int i = 0; i < 10; i++)
            {
                _trafficData.Add(new Traffic
                {
                    RegionCode = i.ToString(),
                    RegionName = i + Guid.NewGuid().ToString(),
                    Details = "Traffic details"
                });
            }
        }

        public Task<List<Traffic>> GetAllAsync()
        {
            return Task.FromResult(_trafficData);
        }

        public Task<Traffic> GetByRegionCodeAsync(string regionCode)
        {
            return Task.FromResult(_trafficData.FirstOrDefault(t => t.RegionCode.Equals(regionCode)));
        }
    }
}
