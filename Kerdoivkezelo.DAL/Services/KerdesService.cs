using Kerdoivkezelo.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerdoivkezelo.DAL.Services
{
    public class KerdesService
    {
        public KerdoivKezeloDbContext _context { get; }

        public KerdesService(KerdoivKezeloDbContext Context)
        {
            _context = Context;
        }
        public  IList<KerdoivKerdes> GetKerdesByKerdoiv(int kerdoivID)
        {
            var kerdesek = _context.KerdoivKerdesek.Where(k => k.KerdoivId == kerdoivID).ToList() ;
            return kerdesek;
        }

        public List<KerdesOsszerendeles> getKerdesElemek(int kerdesId)
        {
            var kerdeselemek = _context.KerdesOsszerendelesek.Where(k => k.KerdesId == kerdesId).ToList();
            return kerdeselemek;
        }

        public KerdesElem getElemek(int elemID)
        {
            var elem = _context.KerdesElemek.SingleOrDefault(e => e.Id == elemID);
            elem.KerdesOsszerendelesek = null;
            return elem;
        }

        public async Task<List<ValaszOsszerendeles>> GetValaszok(int kerdesID)
        {
            var valaszok = await _context.ValaszOsszerendelesek.Include(v => v.ValaszElem).Where(vo => vo.KerdesId == kerdesID).ToListAsync(); ;
            return valaszok;
        }


        //public object Mukodj(int? kerdoivId)
        //{
        //    var elemek = _context.Kerdesek.Include(k => k.KerdesOsszerendelesek).ThenInclude(k => k.KerdesElem).Include(k => k.Valaszlehetosegek).ThenInclude(k => k.ValaszElem).AsNoTracking().GroupBy(k => k.Id);
        //    return elemek;
        //}
    }
}
