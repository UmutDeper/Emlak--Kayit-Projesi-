using EmlakAppDataAcessLayer.AbstractRepositories;
using EmlakAppDataAcessLayer.AppDBcontext;
using EmlakAppEntityLayer;
using EmlakAppEntityLayer.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakAppDataAcessLayer.ConcreteRepositories
{
    public class Repository<T>:IRepository<T> where T : BaseEntity

    {
        protected readonly EmlakDbContext context;

        public Repository(EmlakDbContext context)
        {
            this.context = context;
        }

        public T Add(T entity)
        {
            return context.Set<T>().Add(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    

        public T GetItem(int id)
        {
            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> List()
        {
            return context.Set<T>().ToList();
        }

        public void Remove(int id)
        {

            context.Set<T>().Remove(GetItem(id));
        }

        public void Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
