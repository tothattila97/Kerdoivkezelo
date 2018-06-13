using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kerdoivkezelo.DAL.Entities
{
    public class Kerdes
    {
        public int Id { get; set; }
        public ICollection<KerdesOsszerendeles> KerdesOsszerendelesek{ get; set; }

        public ICollection<ValaszOsszerendeles> Valaszlehetosegek { get; set; }

        //public ICollection<ValaszOsszerendeles> HelyesValaszok { get; set; }
        public string HelyesValaszIdk { get; set; }
        [NotMapped]
        public double[] HelyesIdk
        {
            get
            {
                return Array.ConvertAll(HelyesValaszIdk.Split(';'), Double.Parse);
            }
            set
            {
                HelyesValaszIdk = String.Join(";", value.Select(p => p.ToString()).ToArray());
            }
        }

        public string JeloltValaszIdk { get; set; }
        [NotMapped]
        public double[] JeloltIdk
        {
            get
            {
                return Array.ConvertAll(JeloltValaszIdk.Split(';'), Double.Parse);
            }
            set
            {
                JeloltValaszIdk = String.Join(";", value.Select(p => p.ToString()).ToArray());
            }
        }

        //public ICollection<ValaszOsszerendeles> JeloltValaszok { get; set; }
    }
}
