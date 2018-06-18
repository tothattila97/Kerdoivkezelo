using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kerdoivkezelo.DAL.Entities;
using Kerdoivkezelo.DAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace KerdoivKezelo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class FelhasznaloController : Controller
    {

        [HttpGet]
        public IEnumerable<MockFelhasznalo> GetFelhasznalok()
        {
            FelhasznaloService fs = new FelhasznaloService();
            return fs.GetMockFelhasznalok();
        }

        [HttpPost]
        public IActionResult FelhasznaloFrissitese(int id, [FromBody]MockFelhasznalo kerdoiv)
        {
            if (kerdoiv == null) {
                throw new ArgumentNullException();
            }
            return Ok();
        }
    }
}