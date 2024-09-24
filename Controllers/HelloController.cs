using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NortWindOriginalRestApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        //get metodi julkinen ja palauttaa hello word string
        [HttpGet]
        public string Get()
        {
            return ("Hello Word");
        }
    }
}
