using EmlakAppDataAcessLayer.AbstractRepositories;
using EmlakAppDataAcessLayer.AppDBcontext;
using EmlakAppDataAcessLayer.ConcreteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakAppDataAcessLayer
{
    public class UnitOfWork : IDisposable
        
    
    {
        private readonly EmlakDbContext context;

        public UnitOfWork()
        {
            context = new EmlakDbContext();
        }

        private IDaireReposity _daireRepo;
        private IArsaReposity _arsaRepo;
        private IDukkanReposity _dukkanRepo;

       
        public IDaireReposity DaireRepo
        {
            get { if (_daireRepo == null)
                    _daireRepo = new DaireRepository(context);
                return _daireRepo;            
            }

        }
        public IArsaReposity ArsaRepo
        {
            get
            {
                if (_arsaRepo == null)
                    _arsaRepo = new ArsaRepository(context);
                return _arsaRepo;
            }

        }
        public IDukkanReposity DukkanRepo
        {
            get
            {
                if (_dukkanRepo == null)
                    _dukkanRepo = new DukkanRepository(context);
                return _dukkanRepo ;
            }

        }


        public void Save()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void Dispose()
        {

            context?.Dispose();
            _dukkanRepo?.Dispose();
            _daireRepo?.Dispose();
            _arsaRepo?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
  
      
    }

