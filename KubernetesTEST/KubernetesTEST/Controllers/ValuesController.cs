using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace KubernetesTEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ValuesController(IConfiguration config)
        {
            _config = config;
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
    }
}
