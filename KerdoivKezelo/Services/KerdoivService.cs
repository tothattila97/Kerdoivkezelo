using Kerdoivkezelo.DAL.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kerdoivkezelo.DAL.Exceptions;
using KerdoivKezelo.Filters;
using KerdoivKezelo.Exceptions;

namespace Kerdoivkezelo.DAL.Services
{
    [ExceptionFilter]
    public class KerdoivService
    {
        public KerdoivService(KerdoivKezeloDbContext context)
        {
            Context = context;
        }
        private static int oldalMeret = 5;

        IList<Kerdoiv> mockKerdoivek = new List<Kerdoiv>();

        public KerdoivKezeloDbContext Context { get; }

        /*
        public void init()
        {
        Kerdoiv k1 = new Kerdoiv { Nev = "könnyű", IdoKorlat = 30, KitoltesSzam = 10, AtlagPontszam = 30, ElertPontszamSzumma = 170, MaxPontszam = 21 };
        Kerdoiv k2 = new Kerdoiv { Nev = "brutál", IdoKorlat = 60, KitoltesSzam = 4, AtlagPontszam = 45, ElertPontszamSzumma = 220, MaxPontszam = 33 };
        Kerdoiv k3 = new Kerdoiv { Nev = "nehéz", IdoKorlat = 24, KitoltesSzam = 47, AtlagPontszam = 14, ElertPontszamSzumma = 178, MaxPontszam = 18 };
        Kerdoiv k4 = new Kerdoiv { Nev = "közepes", IdoKorlat = 19, KitoltesSzam = 18, AtlagPontszam = 22, ElertPontszamSzumma = 95, MaxPontszam = 25 };
        Kerdoiv k5 = new Kerdoiv { Nev = "test1", IdoKorlat = 30, KitoltesSzam = 10, AtlagPontszam = 30, ElertPontszamSzumma = 170, MaxPontszam = 21 };
        Kerdoiv k6 = new Kerdoiv { Nev = "test2", IdoKorlat = 60, KitoltesSzam = 4, AtlagPontszam = 45, ElertPontszamSzumma = 220, MaxPontszam = 33 };
        Kerdoiv k7 = new Kerdoiv { Nev = "test3", IdoKorlat = 24, KitoltesSzam = 47, AtlagPontszam = 14, ElertPontszamSzumma = 178, MaxPontszam = 18 };
        Kerdoiv k8 = new Kerdoiv { Nev = "test4", IdoKorlat = 19, KitoltesSzam = 18, AtlagPontszam = 22, ElertPontszamSzumma = 95, MaxPontszam = 25 };
        Kerdoiv k9 = new Kerdoiv { Nev = "test5", IdoKorlat = 30, KitoltesSzam = 10, AtlagPontszam = 30, ElertPontszamSzumma = 170, MaxPontszam = 21 };
        Kerdoiv k10 = new Kerdoiv { Nev = "test6", IdoKorlat = 60, KitoltesSzam = 4, AtlagPontszam = 45, ElertPontszamSzumma = 220, MaxPontszam = 33 };
        Kerdoiv k11 = new Kerdoiv { Nev = "test7", IdoKorlat = 24, KitoltesSzam = 47, AtlagPontszam = 14, ElertPontszamSzumma = 178, MaxPontszam = 18 };
        Kerdoiv k12 = new Kerdoiv { Nev = "test8", IdoKorlat = 19, KitoltesSzam = 18, AtlagPontszam = 22, ElertPontszamSzumma = 95, MaxPontszam = 25 };
        Kerdoiv k16 = new Kerdoiv { Nev = "test9", IdoKorlat = 30, KitoltesSzam = 10, AtlagPontszam = 30, ElertPontszamSzumma = 170, MaxPontszam = 21 };
        Kerdoiv k13 = new Kerdoiv { Nev = "test10", IdoKorlat = 60, KitoltesSzam = 4, AtlagPontszam = 45, ElertPontszamSzumma = 220, MaxPontszam = 33 };
        Kerdoiv k14 = new Kerdoiv { Nev = "test11", IdoKorlat = 24, KitoltesSzam = 47, AtlagPontszam = 14, ElertPontszamSzumma = 178, MaxPontszam = 18 };
        Kerdoiv k15 = new Kerdoiv { Nev = "test12", IdoKorlat = 19, KitoltesSzam = 18, AtlagPontszam = 22, ElertPontszamSzumma = 95, MaxPontszam = 25 };
        mockKerdoivek.Add(k1);
        mockKerdoivek.Add(k2);
        mockKerdoivek.Add(k3);
        mockKerdoivek.Add(k4);
        mockKerdoivek.Add(k5);
        mockKerdoivek.Add(k6);
        mockKerdoivek.Add(k7);
        mockKerdoivek.Add(k8);
        mockKerdoivek.Add(k9);
        mockKerdoivek.Add(k10);
        mockKerdoivek.Add(k11);
        mockKerdoivek.Add(k12);
        mockKerdoivek.Add(k13);
        mockKerdoivek.Add(k14);
        mockKerdoivek.Add(k15);
        mockKerdoivek.Add(k16);
        }
        */
        public async Task<List<Kerdoiv>> GetMockKerdoivek()
        {
            //init();
            return await Context.Kerdoivek.ToListAsync();
        }

        public async Task<List<Kerdoiv>> GetSzurtKerdoivekByMegnevezes(string querystr, int pagenumber)
        {
            var kerdoivek = await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(querystr.ToLower())).Skip(pagenumber * oldalMeret).Take(oldalMeret).ToListAsync();
            return kerdoivek;
        }

        public async Task<List<Kerdoiv>> GetSzurtKerdoivekByIdoIntervallum(int alsoIdoKorlat, int felsoIdokorlat, int oldalszam)
        { 
            //init();
            return await Context.Kerdoivek.Where(t => (alsoIdoKorlat <= t.IdoKorlat && felsoIdokorlat >= t.IdoKorlat)).Skip(oldalszam*oldalMeret).Take(oldalMeret).ToListAsync();
        }

        public async Task<List<Kerdoiv>> GetKerdoivekAdottOldalon(int oldalszam)
        {
            //init();
            return await Context.Kerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToListAsync();
        }

        public async Task<int> GetMaxOldalszam()
        {
            //init();
            return (await Context.Kerdoivek.CountAsync() / oldalMeret) + 1;
        }

        public async Task<int> GetNumberOfPagesByQuerystring(string querystring)
        {
            //init();
            return (await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(querystring.ToLower())).CountAsync() / oldalMeret)+1;
        }

        public async Task<int> GetNumberOfPagesByTimeInterval(int alsoIdokorlat, int felsoIdokorlat)
        {
            //init();
            return (await Context.Kerdoivek.Where(t => (alsoIdokorlat <= t.IdoKorlat && felsoIdokorlat >= t.IdoKorlat)).CountAsync() / oldalMeret) + 1;
        }

        public async Task<Kerdoiv> Create(Kerdoiv kerdoiv)
        {
            if(kerdoiv == null)
            {
                throw new BadRequestException();
            }
            Context.Add(kerdoiv);
            await Context.SaveChangesAsync();
            return kerdoiv;
        }

        public async Task Delete(int id)
        {
            var kerdoiv = Context.Kerdoivek.SingleOrDefault(k => k.Id == id);
            if(kerdoiv == null)
            {
                throw new KerdoivKezelo.Exceptions.NotFoundException();
            }
            Context.Kerdoivek.Remove(kerdoiv);
            await Context.SaveChangesAsync();
        }

        public async Task<Kerdoiv> Edit(int id, Kerdoiv _kerdoiv)
        {
            if(id != _kerdoiv.Id)
            {
                throw new BadRequestException();
            }
            Context.Update(_kerdoiv);
            await Context.SaveChangesAsync();

            if (!KerdoivExist(_kerdoiv.Id))
            {
                throw new BadRequestException();
            }

            return _kerdoiv;
        }

        private bool KerdoivExist(int id)
        {
            return Context.Kerdoivek.Any(k => k.Id == id);
        }


        public async Task<List<Kerdoiv>> SortNevAscendingFilterByNev(string queryString, int oldalszam)
        {
            if (queryString == null)
            {
                var kerdoivek = await Context.Kerdoivek.OrderBy(k => k.Nev).ToListAsync();
                kerdoivek = kerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
            else
            {
                var kerdoivek = await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(queryString.ToLower())).ToListAsync();
                kerdoivek = kerdoivek.OrderBy(k => k.Nev).Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
        }

        public async Task<List<Kerdoiv>> SortMaxPontAscendingFilterByNev(string queryString, int oldalszam)
        {
            if (queryString == null)
            {
                var kerdoivek = await Context.Kerdoivek.OrderBy(k => k.MaxPontszam).ToListAsync();
                kerdoivek = kerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
            else
            {
                var kerdoivek = await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(queryString.ToLower())).ToListAsync();
                kerdoivek = kerdoivek.OrderBy(k => k.MaxPontszam).Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
        }

        public async Task<List<Kerdoiv>> SortMaxPontDescendingFilterByNev(string queryString, int oldalszam)
        {
            if (queryString == null)
            {
                var kerdoivek = await Context.Kerdoivek.OrderByDescending(k => k.MaxPontszam).ToListAsync();
                kerdoivek = kerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
            else
            {
                var kerdoivek = await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(queryString.ToLower())).ToListAsync();
                kerdoivek = kerdoivek.OrderByDescending(k => k.MaxPontszam).Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
        }

        public async Task<List<Kerdoiv>> SortNevDescendingFilterByNev(string queryString, int oldalszam)
        {
            if (queryString == null)
            {
                var kerdoivek = await Context.Kerdoivek.OrderByDescending(k => k.Nev).ToListAsync();
                kerdoivek = kerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
            else
            {
                var kerdoivek = await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(queryString.ToLower())).ToListAsync();
                kerdoivek = kerdoivek.OrderByDescending(k => k.Nev).Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
        }

        public async Task<List<Kerdoiv>> SortIdokorlatAscendingFilterByNev(string queryString, int oldalszam)
        {
            if (queryString == null)
            {
                var kerdoivek = await Context.Kerdoivek.OrderBy(k => k.IdoKorlat).ToListAsync();
                kerdoivek = kerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
            else
            {
                var kerdoivek = await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(queryString.ToLower())).ToListAsync();
                kerdoivek = kerdoivek.OrderBy(k => k.IdoKorlat).Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
        }

        public async Task<List<Kerdoiv>> SortIdokorlatDescendingFilterByNev(string queryString, int oldalszam)
        {
            if (queryString == null)
            {
                var kerdoivek = await Context.Kerdoivek.OrderByDescending(k => k.IdoKorlat).ToListAsync();
                kerdoivek = kerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
            else
            {
                var kerdoivek = await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(queryString.ToLower())).ToListAsync();
                kerdoivek = kerdoivek.OrderByDescending(k => k.IdoKorlat).Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
        }

        public async Task<List<Kerdoiv>> SortKitoltesekSzamaAscendingFilterByNev(string queryString, int oldalszam)
        {
            if (queryString == null)
            {
                var kerdoivek = await Context.Kerdoivek.OrderBy(k => k.IdoKorlat).ToListAsync();
                kerdoivek = kerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
            else
            {
                var kerdoivek = await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(queryString.ToLower())).ToListAsync();
                kerdoivek = kerdoivek.OrderBy(k => k.IdoKorlat).Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
        }

        public async Task<List<Kerdoiv>> SortKitoltesekSzamaDescendingFilterByNev(string queryString, int oldalszam)
        {
            if (queryString == null)
            {
                var kerdoivek = await Context.Kerdoivek.OrderByDescending(k => k.KitoltesSzam).ToListAsync();
                kerdoivek = kerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
            else
            {
                var kerdoivek = await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(queryString.ToLower())).ToListAsync();
                kerdoivek = kerdoivek.OrderByDescending(k => k.KitoltesSzam).Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
        }

        public Task<List<Kerdoiv>> SortSajatEredmenyAscendingFilterByNev(string queryString, int oldalszam)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Kerdoiv>> SortSajatEredmenyDescendingFilterByNev(string queryString, int oldalszam)
        {
            if (queryString == null)
            {
                var kerdoivek = await Context.Kerdoivek.OrderByDescending(k => k.ElertPontszamSzumma).ToListAsync();
                kerdoivek = kerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
            else
            {
                var kerdoivek = await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(queryString.ToLower())).ToListAsync();
                kerdoivek = kerdoivek.OrderByDescending(k => k.ElertPontszamSzumma).Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
        }

        public async Task<List<Kerdoiv>> SortAtlagPontszamDescendingFilterByNev(string queryString, int oldalszam)
        {
            if (queryString == null)
            {
                var kerdoivek = await Context.Kerdoivek.OrderByDescending(k => k.AtlagPontszam).ToListAsync();
                kerdoivek = kerdoivek.Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
            else
            {
                var kerdoivek = await Context.Kerdoivek.Where(t => t.Nev.ToLower().Contains(queryString.ToLower())).ToListAsync();
                kerdoivek = kerdoivek.OrderByDescending(k => k.AtlagPontszam).Skip(oldalszam * oldalMeret).Take(oldalMeret).ToList();
                return kerdoivek;
            }
        }

        public Task<List<Kerdoiv>> SortAtlagPontszamAscendingFilterByNev(string queryString, int oldalszam)
        {
            throw new NotImplementedException();
        }
    }
}
