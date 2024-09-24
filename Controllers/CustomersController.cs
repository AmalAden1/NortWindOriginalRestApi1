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
            try
            { 
                var asiakkaat = db.Customers.ToList();
                return Ok(asiakkaat);

            }
            catch (Exception ex)
            { 
                return BadRequest("Tapahtui virhe. Lue lisää: " + ex.InnerException);
            
            }
            
        }



        //luodaa metodi get määritellyllä  ID  joka Hakee kaikki asiakkaat id eli pääavaimella
        [HttpGet("{id}")]
       
        public ActionResult GetOneCustomersById(string id)
        {
            try
            {
                var asiakas = db.Customers.Find(id);
                if (asiakas != null)
                {
                    return Ok(asiakas);
                }
                else
                {
                    //return BadRequest("Asikasta id:llä " + "ei löydy");
                    return NotFound($"Asiakasta id:llä {id} ei löydy");// string interpolation
                }
            }
            catch (Exception ex) 
            {
                return BadRequest("Tapahtui Virhe. Lue Lisää:" + ex.InnerException);

            
            }
            /// muista tarkistaa connection string "esim. tietokannan nimi" -- jos haluat nähdä virhee niin muista muuttaa tietokanta 
            
        }

        [HttpPost]

        public ActionResult Addnew([FromBody] Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return Ok($"Lisäättiin uusi asiakas{customer.CompanyName} from {customer.City}");

            }
            catch (Exception ex)
            {
                return BadRequest("Tapahtui virhe. Lue Lisää: " + ex.InnerException);
            }
        }

    }
       
}
