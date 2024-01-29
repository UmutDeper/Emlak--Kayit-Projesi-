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
    public interface IDukkanReposity : IRepository<Dukkan>
    {
        Dukkan GetItem(int? ıd);
        void Remove(Dukkan dukkan);
        List<Dukkan> ToListFULL();
    }
}
