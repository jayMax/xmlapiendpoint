using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XmlApiEndpoint.Services;

namespace XmlApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly IStorageService _storageService;

        public FileController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost]
        [Route("createbigfile")]
        public async Task<IActionResult> SaveBigFile()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var content = await reader.ReadToEndAsync();

                await _storageService.SaveDataAsync(content);

                return Ok();
            }
        }
    }
}