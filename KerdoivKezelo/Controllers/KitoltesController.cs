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
    public class KitoltesController : Controller
    {

        public KitoltesService KitoltesService { get; }

        public KitoltesController(KitoltesService kitoltesService)
        {
            KitoltesService = kitoltesService;
        }

        [HttpGet]
        public IEnumerable<Kerdoiv> GetKerdoivek()
        {
            return KitoltesService.GetKerdoivek();
        }

        [HttpGet("{id}")]
        public IEnumerable<KerdoivKitoltes> GetKitoltesek(int id)
        {
            return KitoltesService.GetKitoltesek(id);
        }
    }
}