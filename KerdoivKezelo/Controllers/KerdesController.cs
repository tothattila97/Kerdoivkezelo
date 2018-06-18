using Kerdoivkezelo.DAL.Entities;
using Kerdoivkezelo.DAL.Services;
using KerdoivKezelo.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KerdoivKezelo.Controllers
{
    [Route("Kerdes/[Action]")]
    [ExceptionFilter]
    public class KerdesController : Controller
    {
        public KerdesService _kerdesService { get; }

        public KerdesController(KerdesService KerdesService)
        {
            _kerdesService = KerdesService;
        }

        [HttpGet]
        public IActionResult GetKerdesByKerdoiv(int _kerdoivID)
        {
            var kerdesek = _kerdesService.GetKerdesByKerdoiv(_kerdoivID);
            if (kerdesek == null)
                return NotFound();

            var kerdeselemek = new List<KerdesOsszerendeles>();

            foreach (var item in kerdesek)
            {

                var kerdeselem = _kerdesService.getKerdesElemek(item.KerdesId);
                foreach (var i in kerdeselem)
                {
                    kerdeselemek.Add(i);
                }

            }
            var elemek = new List<KerdesElem>();

            foreach (var item in kerdeselemek)
            {
                elemek.Add(_kerdesService.getElemek(item.KerdesElemId));
            }
            return Ok(kerdeselemek);
        }

        //    [HttpGet]
        //    public IActionResult GetkerdesElemek(int _kerdoivId)
        //    {
        //        var elemek = _kerdesService.Mukodj(_kerdoivId);

        //        return Ok(elemek);
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> GetValaszokByKerdes(int kerdesID)
        {
            var valaszok = await _kerdesService.GetValaszok(kerdesID);
            if (valaszok == null)
                return NotFound();
            return Ok(valaszok);

        }
    }
}
