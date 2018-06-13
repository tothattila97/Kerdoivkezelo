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
        // GET: api/Kerdoiv
        [HttpGet]
        public IEnumerable<Kerdoiv> GetKerdoivek()
        {
            //return new string[] { "value1", "value2" };
            KerdoivService kerdoivService = new KerdoivService();
            var mockData = kerdoivService.GetMockKerdoivek();
            return mockData;

        }

        [HttpGet("{querystr}")]
        public IEnumerable<Kerdoiv> GetKerdoivekByMegnevezes(string querystr)
        {
            KerdoivService kerdoivService = new KerdoivService();
            var kerdoivekMegnevezesselSzurve = kerdoivService.GetSzurtKerdoivekByMegnevezes(querystr);
            return kerdoivekMegnevezesselSzurve;
        }

        [HttpGet("{alsoIdoKorlat}/{felsoIdoKorlat}")]
        public IEnumerable<Kerdoiv> GetKerdoivekByIdoIntervallum(int alsoIdoKorlat, int felsoIdokorlat)
        {
            KerdoivService kerdoivService = new KerdoivService();
            var kerdoivekIdoIntervallummalSzurve = kerdoivService.GetSzurtKerdoivekByIdoIntervallum(alsoIdoKorlat, felsoIdokorlat);
            return kerdoivekIdoIntervallummalSzurve;
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
