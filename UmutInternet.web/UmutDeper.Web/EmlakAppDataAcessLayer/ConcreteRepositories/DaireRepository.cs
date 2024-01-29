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
    public class DaireRepository : Repository<Daire>, IDaireReposity
    {
    
        public DaireRepository(EmlakDbContext context) : base(context)
        {
        }

        public Daire GetItem(int? ıd)
        {
            return context.Set<Daire>().Find(ıd);
        }

        public void Remove(Daire daire)
        {
            context.Set<Daire>().Remove(daire);
        }

        public List<Daire> ToListFULL()
        {
            return context.Daireler.ToList();
        }
    }
    }

