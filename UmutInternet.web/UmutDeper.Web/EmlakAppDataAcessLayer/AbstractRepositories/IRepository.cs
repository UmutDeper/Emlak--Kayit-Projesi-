using EmlakAppEntityLayer;
using System;
using System.Collections.Generic;

namespace EmlakAppDataAcessLayer.AbstractRepositories
{
    public interface IRepository<T>:IDisposable
    {
        List<T> List();
        T GetItem(int id);
        T Add(T entity);
        void Update(T entity);  
        void Remove(int id);
   
    }
}
