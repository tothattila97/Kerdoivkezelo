﻿using System;
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
        public async Task<IActionResult> GetKerdoivek() =>
            Ok(await KerdoivService.GetMockKerdoivek());

        [HttpGet("{querystr}/{pagenumber}")]
        public async Task<IActionResult> GetKerdoivekByMegnevezes(string querystr, int pagenumber)
        {
            return Ok(await KerdoivService.GetSzurtKerdoivekByMegnevezes(querystr, pagenumber));
        }

        [HttpGet("{alsoIdoKorlat}/{felsoIdoKorlat}/{oldalszam}")]
        public async Task<IActionResult> GetKerdoivekByIdoIntervallum(int alsoIdoKorlat, int felsoIdokorlat, int oldalszam)
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(await KerdoivService.GetSzurtKerdoivekByIdoIntervallum(alsoIdoKorlat, felsoIdokorlat, oldalszam));
        }

        [HttpGet("{oldalszam}")]
        public async Task<IActionResult> GetPage(int oldalszam)
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(await KerdoivService.GetKerdoivekAdottOldalon(oldalszam));
        }

        [HttpGet]
        public async Task<IActionResult> GetMaxPage()
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(await KerdoivService.GetMaxOldalszam());
        }

        //TODO:   paraméter:  querystring   return: hány oldalon át illeszkedik INT
        [HttpGet("{querystring}")]
        public async Task<IActionResult> GetMatchingPagesNumber(string querystring)
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(await KerdoivService.GetNumberOfPagesByQuerystring(querystring));
        }

        [HttpGet("{alsoIdokorlat}/{felsoIdokorlat}")]
        public async Task<IActionResult> GetPagesNumberByTimeInterval(int alsoIdokorlat, int felsoIdokorlat)
        {
            //KerdoivService kerdoivService = new KerdoivService();
            return Ok(await KerdoivService.GetNumberOfPagesByTimeInterval(alsoIdokorlat, felsoIdokorlat));
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
        public async Task<IActionResult> Delete(int id)
        {
            await KerdoivService.Delete(id);
            return Ok();
        }
    }
}
