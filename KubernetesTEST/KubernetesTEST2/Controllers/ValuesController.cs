using Microsoft.AspNetCore.Mvc;

namespace KubernetesTEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello from KubernetesTEST2";
        }
    }
}
