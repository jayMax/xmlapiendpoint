using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Razor.Text;

namespace XmlApiEndpoint.Services
{
    public class FileStorageService : IStorageService
    {
        public async Task SaveDataAsync(string data)
        {
            var document = new XmlDocument();
            document.LoadXml(data);

            var regionCodes = document.GetElementsByTagName("RegionCode");
            var regionNames = document.GetElementsByTagName("RegionName");
            var details = document.GetElementsByTagName("Details");

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < regionCodes.Count; i++)
            {
                builder.AppendLine($"{regionCodes[i].InnerText} - {regionNames[i].InnerText} - {details[i].InnerText}");
            }
            
            using (var file = new StreamWriter(File.Create("file.txt")))
            {
                await file.WriteAsync(builder.ToString());
            }
        }
    }
}
