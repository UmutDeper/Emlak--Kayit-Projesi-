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
    public class DukkanRepository : Repository<Dukkan>, IDukkanReposity
    {
        public DukkanRepository(EmlakDbContext context) : base(context)
        {
        }

        public Dukkan GetItem(int? ıd)
        {
            return context.Set<Dukkan>().Find(ıd);
        }

        public void Remove(Dukkan dukkan)
        {
            context.Set<Dukkan>().Remove(dukkan);
        }

        public List<Dukkan> ToListFULL()
        {
            return context.Dukkanlar.ToList();
        }
    }
}
