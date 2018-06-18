using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kerdoivkezelo.DAL.Services
{
    public class FelhasznaloService
    {

        public List<MockFelhasznalo> GetMockFelhasznalok()
        {
            List<MockFelhasznalo> ret = new List<MockFelhasznalo>();
            ret.Add(new MockFelhasznalo()
            {
                Name = "Admin",
                Admin = true,
                AdminJog = true
            });
            ret.Add(new MockFelhasznalo()
            {
                Name = "user1",
                Admin = false,
                AdminJog = true
            });
            ret.Add(new MockFelhasznalo()
            {
                Name = "user2",
                Admin = false,
                AdminJog = false
            });
            return ret;
        }
    }

    public class MockFelhasznalo {
        public string Name { get; set; }
        public bool Admin { get; set; }
        public bool AdminJog { get; set; }
    }
}
