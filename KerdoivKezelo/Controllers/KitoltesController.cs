﻿using System;
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

        [HttpGet]
        public IEnumerable<Kerdoiv> GetKerdoivek()
        {
            KitoltesService ks = new KitoltesService();
            return ks.GetKerdoivek();
        }

        [HttpGet("{id}")]
        public IEnumerable<KerdoivKitoltes> GetKitoltesek(int id)
        {
            KitoltesService ks = new KitoltesService();
            return ks.GetKitoltesek(id);
        }
    }
}