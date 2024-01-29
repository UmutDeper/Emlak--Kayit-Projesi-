    using EmlakAppDataAcessLayer.AppDBcontext;
using EmlakAppDataAcessLayer.ConcreteRepositories;
using EmlakAppEntityLayer;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EmlakAppDataAcessLayer.AbstractRepositories
{
    public interface IDaireReposity : IRepository<Daire>
    {
        Daire GetItem(int? ıd);
        void Remove(Daire daire);
        List<Daire> ToListFULL();
    }

}
