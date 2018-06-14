using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kerdoivkezelo.DAL.Services;
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
        public IEnumerable<Kerdoiv> GetKerdoivek()
        {
            KerdoivService kerdoivService = new KerdoivService();
            return kerdoivService.GetMockKerdoivek();
        }

        [HttpGet("{querystr}/{pagenumber}")]
        public IEnumerable<Kerdoiv> GetKerdoivekByMegnevezes(string querystr, int pagenumber)
        {
            KerdoivService kerdoivService = new KerdoivService();
            return kerdoivService.GetSzurtKerdoivekByMegnevezes(querystr, pagenumber);
        }

        [HttpGet("{alsoIdoKorlat}/{felsoIdoKorlat}/{oldalszam}")]
        public IEnumerable<Kerdoiv> GetKerdoivekByIdoIntervallum(int alsoIdoKorlat, int felsoIdokorlat, int oldalszam)
        {
            KerdoivService kerdoivService = new KerdoivService();
            return kerdoivService.GetSzurtKerdoivekByIdoIntervallum(alsoIdoKorlat, felsoIdokorlat, oldalszam);
        }

        [HttpGet("{oldalszam}")]
        public IEnumerable<Kerdoiv> GetPage(int oldalszam)
        {
            KerdoivService kerdoivService = new KerdoivService();
            return kerdoivService.GetKerdoivekAdottOldalon(oldalszam);
        }

        [HttpGet]
        public int GetMaxPage()
        {
            KerdoivService kerdoivService = new KerdoivService();
            return kerdoivService.GetMaxOldalszam();
        }

        //TODO:   paraméter:  querystring   return: hány oldalon át illeszkedik INT
        [HttpGet("{querystring}")]
        public int GetMatchingPagesNumber(string querystring)
        {
            KerdoivService kerdoivService = new KerdoivService();
            return kerdoivService.GetNumberOfPagesByQuerystring(querystring);
        }

        [HttpGet("{alsoIdokorlat}/{felsoIdokorlat}")]
        public int GetPagesNumberByTimeInterval(int alsoIdokorlat, int felsoIdokorlat)
        {
            KerdoivService kerdoivService = new KerdoivService();
            return kerdoivService.GetNumberOfPagesByTimeInterval(alsoIdokorlat, felsoIdokorlat);
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
