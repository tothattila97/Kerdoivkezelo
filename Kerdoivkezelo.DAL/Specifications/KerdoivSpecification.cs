using System;
using System.Collections.Generic;
using System.Text;

namespace Kerdoivkezelo.DAL.Specifications
{
    public class KerdoivSpecification
    {
        public string Nev { get; set; }
        public int? IdoKorlat { get; set; }
        public int? KitoltesSzam { get; set; }
        public double? AtlagPontszam { get; set; }
        public int? MaxPontszam { get; set; }

    }

     public enum KerdoivOrder
    {
        NevAscending,
        NevDescending,
        IdoKorlatAscending,
        IdoKorlatDescending,
        KitoltesSzamAscending,
        KitoltesSzamDescending,
        AtlagPontszamAscending,
        AtlagPontszamDescending,
        MaxPontszamAscending,
        MaxPontszamDescending
    }
}
