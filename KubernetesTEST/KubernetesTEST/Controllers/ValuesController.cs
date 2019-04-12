using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KubernetesTEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _clientFactory;

        public ValuesController(IConfiguration config, IHttpClientFactory clientFactory)
        {
            _config = config;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello";
        }

        [HttpGet]
        [Route("env")]
        public ActionResult<List<KeyValuePair<string, string>>> GetEnvs()
        {
            var result = _config.AsEnumerable().ToList();
            return result;
        }

        [HttpGet("env/{key}")]
        public ActionResult<string> GetEnv(string key)
        {
            var result = _config.GetValue<string>(key);
            return result;
        }

        [HttpGet("result")]
        public async Task<ActionResult<string>> GetResult(string address)
        {
            //string result = null;
            
            //if (string.IsNullOrWhiteSpace(address))
            //{
            //    result = "Nowhere to go!";
            //}
            //else
            //{
            //    using (var client = _clientFactory.CreateClient())
            //    {
            //        using(var request = new HttpRequestMessage(HttpMethod.Get, address))
            //        {
            //            using(var response = await client.SendAsync(request))
            //            {
            //                if (response.IsSuccessStatusCode)
            //                {
            //                    result = await response.Content.ReadAsStringAsync();
            //                }
            //                else
            //                {
            //                    result = "Something went wrong with response!";
            //                }
            //            }
            //        }
            //    }
            //}

            //return result;

            string result = null;

            try
            {
                var client = _clientFactory.CreateClient();

                if (string.IsNullOrWhiteSpace(address))
                {
                    result = "Nowhere to go!";
                }
                else
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, address);
                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        result = "Something went wrong with response!";
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}
