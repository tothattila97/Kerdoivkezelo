using System;
using System.Collections.Generic;
using System.Text;

namespace Kerdoivkezelo.DAL.Dtos
{
    public class KerdoivHeader
    {
        public string Nev { get; set; }
        public int? IdoKorlat { get; set; }
        public int? KitoltesSzam { get; set; }
        public double? AtlagPontszam { get; set; }
        public int? MaxPontszam { get; set; }
        public ICollection<string> Kerdesek { get; set; }
        public int? ElertPontszamSzumma { get; set; }
    }
}
