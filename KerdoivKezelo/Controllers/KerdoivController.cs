using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAngular.Data.Kerdoiv;

namespace KerdoivKezelo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class KerdoivController : Controller
    {
        // GET: api/Kerdoiv
        [HttpGet]
        public IEnumerable<string> GetKerdoivek()
        {
            return new string[] { "value1", "value2" };

        }

        // GET: api/Kerdoiv/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Kerdoiv
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Kerdoiv/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
