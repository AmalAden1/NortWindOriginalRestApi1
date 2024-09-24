using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NortWindOriginalRestApi1.Models;


namespace NortWindOriginalRestApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        NorthwindOriginalContext db = new NorthwindOriginalContext();

        //luodaa metodi get joka Hakee kaikki asiakkaat
        [HttpGet]
        public ActionResult GetAllCustomers() 
        {
             var asiakkaat = db.Customers.ToList();
            return Ok(asiakkaat);
        }
    }
       
}
