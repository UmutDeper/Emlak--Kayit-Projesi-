using EmlakAppDataAcessLayer.AbstractRepositories;
using EmlakAppDataAcessLayer.AppDBcontext;
using EmlakAppEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakAppDataAcessLayer.ConcreteRepositories
{
    public class ArsaRepository : Repository<Arsa>,IArsaReposity
    {
        public ArsaRepository(EmlakDbContext context) : base(context)
        {
        }

        public Arsa GetItem(int? ıd)
        {
            return context.Set<Arsa>().Find(ıd);
        }

        public void Remove(Arsa arsa)
        {
            context.Set<Arsa>().Remove(arsa);
        }

        public List<Arsa> ToListFULL()
        {

            return context.Arsalar.ToList();
        }
    }
}
