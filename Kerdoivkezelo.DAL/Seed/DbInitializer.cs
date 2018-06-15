using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kerdoivkezelo.DAL.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(KerdoivKezeloDbContext context)
        {

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            if (context.Kerdoivek.Any())
            {
                return;   // DB has been seeded
            }
            var kerdeselemek = Enumerable.Range(1, 5).Select(x =>
                new KerdesElem
                {
                    Szoveg = "Kerdesszoveg" + x,
                });
            context.KerdesElemek.AddRange(kerdeselemek);
            context.SaveChanges();

            var kerdesek = Enumerable.Range(1, 5).Select(x =>
                new Kerdes { }

             );
            context.Kerdesek.AddRange(kerdesek);
            context.SaveChanges();

            var valaszelemek = Enumerable.Range(1, 5).Select(x => new ValaszElem
            {
                Tartalom = "valaszelemek" + x,
            });
            context.ValaszElemek.AddRange(valaszelemek);
            context.SaveChanges();

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
            context.Kerdoivek.Add(k1);
            context.Kerdoivek.Add(k2);
            context.Kerdoivek.Add(k3);
            context.Kerdoivek.Add(k4);
            context.Kerdoivek.Add(k5);
            context.Kerdoivek.Add(k6);
            context.Kerdoivek.Add(k7);
            context.Kerdoivek.Add(k8);
            context.Kerdoivek.Add(k9);
            context.Kerdoivek.Add(k10);
            context.Kerdoivek.Add(k11);
            context.Kerdoivek.Add(k12);
            context.Kerdoivek.Add(k13);
            context.Kerdoivek.Add(k14);
            context.Kerdoivek.Add(k15);
            context.Kerdoivek.Add(k16);
            context.SaveChanges();

            context.AddRange(
                new KerdesOsszerendeles { KerdesId = 1, KerdesElemId = 1 },
                new KerdesOsszerendeles { KerdesId = 2, KerdesElemId = 1 },
                new KerdesOsszerendeles { KerdesId = 3, KerdesElemId = 1 },
                new KerdesOsszerendeles { KerdesId = 4, KerdesElemId = 1 },
                new KerdesOsszerendeles { KerdesId = 5, KerdesElemId = 1 },
                new KerdesOsszerendeles { KerdesId = 1, KerdesElemId = 2 },
                new KerdesOsszerendeles { KerdesId = 2, KerdesElemId = 2 },
                new KerdesOsszerendeles { KerdesId = 2, KerdesElemId = 3 },
                new KerdesOsszerendeles { KerdesId = 3, KerdesElemId = 4 }
                );
            context.SaveChanges();

            ValaszOsszerendeles v1 = new ValaszOsszerendeles { ValaszElemId = 1, KerdesId = 1 };
            ValaszOsszerendeles v2 = new ValaszOsszerendeles { ValaszElemId = 2, KerdesId = 1 };
            ValaszOsszerendeles v3 = new ValaszOsszerendeles { ValaszElemId = 3, KerdesId = 1 };
            ValaszOsszerendeles v4 = new ValaszOsszerendeles { ValaszElemId = 4, KerdesId = 1 };
            ValaszOsszerendeles v5 = new ValaszOsszerendeles { ValaszElemId = 1, KerdesId = 2 };
            ValaszOsszerendeles v6 = new ValaszOsszerendeles { ValaszElemId = 2, KerdesId = 2 };
            ValaszOsszerendeles v7 = new ValaszOsszerendeles { ValaszElemId = 3, KerdesId = 2 };
            ValaszOsszerendeles v9 = new ValaszOsszerendeles { ValaszElemId = 4, KerdesId = 2 };
            ValaszOsszerendeles v10 = new ValaszOsszerendeles { ValaszElemId = 1, KerdesId = 3 };
            ValaszOsszerendeles v11 = new ValaszOsszerendeles { ValaszElemId = 2, KerdesId = 3 };
            ValaszOsszerendeles v12 = new ValaszOsszerendeles { ValaszElemId = 1, KerdesId = 4 };
            ValaszOsszerendeles v13 = new ValaszOsszerendeles { ValaszElemId = 1, KerdesId = 5 };
            context.ValaszOsszerendelesek.Add(v1);
            context.ValaszOsszerendelesek.Add(v2);
            context.ValaszOsszerendelesek.Add(v3);
            context.ValaszOsszerendelesek.Add(v4);
            context.ValaszOsszerendelesek.Add(v5);
            context.ValaszOsszerendelesek.Add(v6);
            context.ValaszOsszerendelesek.Add(v7);
            context.ValaszOsszerendelesek.Add(v9);
            context.ValaszOsszerendelesek.Add(v10);
            context.ValaszOsszerendelesek.Add(v11);
            context.ValaszOsszerendelesek.Add(v12);
            context.ValaszOsszerendelesek.Add(v13);
            context.SaveChanges();


            context.AddRange(
                new KerdoivKerdes { KerdoivId = 1, KerdesId = 1 },
                new KerdoivKerdes { KerdoivId = 1, KerdesId = 2 },
                new KerdoivKerdes { KerdoivId = 1, KerdesId = 3 },
                new KerdoivKerdes { KerdoivId = 1, KerdesId = 4 },
                new KerdoivKerdes { KerdoivId = 1, KerdesId = 5 }
                );
            context.SaveChanges();




        }
    }
}
