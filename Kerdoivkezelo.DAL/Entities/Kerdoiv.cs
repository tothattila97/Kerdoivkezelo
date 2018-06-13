using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular.Data.Kerdoiv
{
    public class Kerdoiv
    {
        public int Id { get; set; }
        public string Nev { get; set; }

        public int? IdoKorlat { get; set; }

        public int? KitoltesSzam { get; set; }

        public double? AtlagPontszam { get; set; }

        public int? MaxPontszam { get; set; }

        public ICollection<Kerdes> Kerdesek { get; set; }

        public int? ElertPontszamSzumma { get; set; }
    }
}
