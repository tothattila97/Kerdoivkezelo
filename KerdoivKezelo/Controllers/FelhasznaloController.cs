using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kerdoivkezelo.DAL;
using Kerdoivkezelo.DAL.Entities;
using Kerdoivkezelo.DAL.Helpers;
using Kerdoivkezelo.DAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KerdoivKezelo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FelhasznaloController : Controller
    {

        private readonly KerdoivKezeloDbContext _appDbContext;
        private readonly UserManager<Felhasznalo> _userManager;
        private readonly IMapper _mapper;

        public FelhasznaloController(UserManager<Felhasznalo> userManager, IMapper mapper, KerdoivKezeloDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        [HttpGet("users")]
        public IEnumerable<Felhasznalo> GetUsers()
        {
            return _appDbContext.Felhasznalok.ToList();
        }


        // POST api/accounts
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<Felhasznalo>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.Felhasznalok.AddAsync(userIdentity);
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }

    }
}