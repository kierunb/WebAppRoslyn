using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAppRoslyn.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        public IActionResult Test1(byte[] input)
        {
            HashAlgorithm hash = new SHA1CryptoServiceProvider();
            byte[] bytes = hash.ComputeHash(input);

            return Ok();
        }
        public IActionResult Test2(string filename)
        {
            Process p = Process.Start(filename);
            return Ok(p.ExitCode);
        }

        public IActionResult Test3()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "AbCdEf123456");

            return Ok();
        }
    }
}
