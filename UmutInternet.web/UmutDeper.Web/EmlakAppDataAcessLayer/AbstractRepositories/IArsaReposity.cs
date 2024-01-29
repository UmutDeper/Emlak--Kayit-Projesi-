using EmlakAppDataAcessLayer.AppDBcontext;
using EmlakAppDataAcessLayer.ConcreteRepositories;
using EmlakAppEntityLayer;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakAppDataAcessLayer.AbstractRepositories
{
    public interface IArsaReposity : IRepository<Arsa>
    {
        Arsa GetItem(int? ıd);
        void Remove(Arsa arsa);
        List<Arsa> ToListFULL();
    }
}
