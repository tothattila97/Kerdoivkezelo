using Kerdoivkezelo.DAL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kerdoivkezelo.DAL.Seed
{
    public static class DbInitializer
    {        
        public static void Initialize(KerdoivKezeloDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (context.Kerdoivek.Any())
            {
                return;   // DB has been seeded
            }

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

            Kerdes[] kerdesek = new Kerdes[3];
            KerdesOsszerendeles[] kerdesOsszerendelesek = new KerdesOsszerendeles[3];
            ValaszOsszerendeles[] valaszOsszerendelesek = new ValaszOsszerendeles[6];
            KerdoivKerdes[] kerdoivKerdesek = new KerdoivKerdes[3];

            for (int i = 0; i < 3; i++)
            {
                kerdesek[i] = new Kerdes();
                context.Kerdesek.Add(kerdesek[i]);
            }
            context.SaveChanges();

            for (int i = 0; i < 3; i++)
            {
                kerdoivKerdesek[i] = new KerdoivKerdes
                {
                    KerdesId = kerdesek[i].Id,
                    KerdoivId = k1.Id
                };
                context.KerdoivKerdesek.Add(kerdoivKerdesek[i]);
            };
            context.SaveChanges();

            KezdoKerdes[] kezdoKerdesek;
            kezdoKerdesek = JsonConvert.DeserializeObject<KezdoKerdes[]>(File.ReadAllText(@"C:\Users\koppanyp\source\repos\elso.json"));
            KerdesElem[] kerdesElemek = new KerdesElem[3];
            ValaszElem[] valaszElemek = new ValaszElem[6];
            var valaszOsszerendelesIndex = 0;
            for (int i = 0; i < 3; i++)
            {
                var aktualisKezdoKerdes = kezdoKerdesek[i];
                //var aktualisKerdesElem = kerdesElemek[i];

                kerdesElemek[i] = new KerdesElem
                {
                    Szoveg = aktualisKezdoKerdes.Text
                };
                context.KerdesElemek.Add(kerdesElemek[i]);

                kerdesOsszerendelesek[i] = new KerdesOsszerendeles
                {
                    KerdesElemId = kerdesElemek[i].Id,
                    KerdesId = kerdesek[i].Id
                };
                context.KerdesOsszerendelesek.Add(kerdesOsszerendelesek[i]);

                for (int j = 0; j < aktualisKezdoKerdes.Valaszok.Count; j++)
                {
                    var aktualisKezdoValasz = aktualisKezdoKerdes.Valaszok.ElementAt(j);
                    //var aktualisValaszElem = valaszElemek[j];
                    valaszElemek[j] = new ValaszElem
                    {
                        Tartalom = aktualisKezdoValasz.Text
                    };
                    context.ValaszElemek.Add(valaszElemek[j]);

                    valaszOsszerendelesek[valaszOsszerendelesIndex] = new ValaszOsszerendeles
                    {
                        Helyes = aktualisKezdoValasz.Igaz,
                        KerdesId = kerdesek[i].Id,
                        ValaszElemId= valaszElemek[j].Id,                        
                    };
                    context.ValaszOsszerendelesek.Add(valaszOsszerendelesek[valaszOsszerendelesIndex]);
                    ++valaszOsszerendelesIndex;
                }
            }
            context.SaveChanges();

        }

        class KezdoKerdes
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Text { get; set; }
            public ICollection<KezdoValasz> Valaszok { get; set; }
        }
        class KezdoValasz
        {
            public int Id { get; set; }
            public string KerdesName { get; set; }
            public string Text { get; set; }
            public bool Igaz { get; set; }
        }
    }
}
