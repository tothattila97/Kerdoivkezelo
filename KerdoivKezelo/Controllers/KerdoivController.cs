using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kerdoivkezelo.DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kerdoivkezelo.DAL.Entities;

namespace KerdoivKezelo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class KerdoivController : Controller
    {
        public KerdoivService KerdoivService { get; }

        public KerdoivController(KerdoivService kerdoivService)
        {
            KerdoivService = kerdoivService;
        }
        // GET: api/Kerdoiv
        [HttpGet]
        public IActionResult GetKerdoivek()
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(KerdoivService.GetMockKerdoivek());
        }

        [HttpGet("{querystr}/{pagenumber}")]
        public IActionResult GetKerdoivekByMegnevezes(string querystr, int pagenumber)
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(KerdoivService.GetSzurtKerdoivekByMegnevezes(querystr, pagenumber));
        }

        [HttpGet("{alsoIdoKorlat}/{felsoIdoKorlat}/{oldalszam}")]
        public IActionResult GetKerdoivekByIdoIntervallum(int alsoIdoKorlat, int felsoIdokorlat, int oldalszam)
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(KerdoivService.GetSzurtKerdoivekByIdoIntervallum(alsoIdoKorlat, felsoIdokorlat, oldalszam));
        }

        [HttpGet("{oldalszam}")]
        public IActionResult GetPage(int oldalszam)
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(KerdoivService.GetKerdoivekAdottOldalon(oldalszam));
        }

        [HttpGet]
        public IActionResult GetMaxPage()
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(KerdoivService.GetMaxOldalszam());
        }

        //TODO:   paraméter:  querystring   return: hány oldalon át illeszkedik INT
        [HttpGet("{querystring}")]
        public IActionResult GetMatchingPagesNumber(string querystring)
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(KerdoivService.GetNumberOfPagesByQuerystring(querystring));
        }

        [HttpGet("{alsoIdokorlat}/{felsoIdokorlat}")]
        public IActionResult GetPagesNumberByTimeInterval(int alsoIdokorlat, int felsoIdokorlat)
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(KerdoivService.GetNumberOfPagesByTimeInterval(alsoIdokorlat, felsoIdokorlat));
        }
       

        // POST: api/Kerdoiv
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Kerdoiv _kerdoiv)
        {
            if (_kerdoiv == null)
            {
                return BadRequest();
            }
            await KerdoivService.Create(_kerdoiv);
            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody]Kerdoiv _kerdoiv)
        {
            if(id != _kerdoiv.Id)
            {
                return BadRequest();
            }
            await KerdoivService.Edit(id, _kerdoiv);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            KerdoivService.Delete(id);
            return Ok();
        }

        //[HttpGet]
        //public async Task<IActionResult> SortByNev(bool direction,int oldalszam)
        //{
        //    if(direction == true)
        //    {
        //        var kerdoivek = await KerdoivService.SortNevAscending(oldalszam);
        //        return Ok(kerdoivek);
        //    }
        //    else if(direction == false)
        //    {
        //        var kerdoivek = await KerdoivService.SortNevDescending(oldalszam);
        //        return Ok(kerdoivek);
        //    }
        //    return BadRequest();        
        //}

        [HttpGet]
        public async Task<IActionResult> SortByNevAndFilterByNev(string queryString, bool direction, int oldalszam)
        {
            if(direction == true)
            {
                var kerdoivek = await KerdoivService.SortNevAscendingFilterByNev(queryString, oldalszam);
                return Ok(kerdoivek);
            }
            if(direction == false)
            {
                var kerdoivek = await KerdoivService.SortNevDescendingFilterByNev(queryString, oldalszam);
                return Ok(kerdoivek);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> SortByMaxPontAndFilterByNev(string queryString, bool direction, int oldalszam)
        {
            if (direction == true)
            {
                var kerdoivek = await KerdoivService.SortMaxPontAscendingFilterByNev(queryString, oldalszam);
                return Ok(kerdoivek);
            }
            if (direction == false)
            {
                var kerdoivek = await KerdoivService.SortMaxPontDescendingFilterByNev(queryString, oldalszam);
                return Ok(kerdoivek);
            }
            return BadRequest();
        }
    }
}
