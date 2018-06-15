using Kerdoivkezelo.DAL.Entities;
using Kerdoivkezelo.DAL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KerdoivKezelo.Controllers
{
    [Route("Kerdes/[Action]")]
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
            if (kerdesek.Count == 0)
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
    }
