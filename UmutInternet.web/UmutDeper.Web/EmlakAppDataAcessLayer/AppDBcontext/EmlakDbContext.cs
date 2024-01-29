using EmlakAppEntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakAppDataAcessLayer.AppDBcontext
{
    public class EmlakDbContext:DbContext
    {
        public DbSet<Daire>Daireler  { get; set; }
        public DbSet<Arsa> Arsalar { get; set; }
        public DbSet <Dukkan>Dukkanlar { get; set; }

        public EmlakDbContext ():base("UmutDB")
        {
            Database.SetInitializer<EmlakDbContext>(new MyDatabaseInitializer());
        }
        public class MyDatabaseInitializer : CreateDatabaseIfNotExists<EmlakDbContext>
        {
            protected override void Seed(EmlakDbContext context)
            {
                base.Seed(context);


                var Daire = context.Daireler.Add(new Daire { daire_adres = "sahibinden",aciklama_="sahin",genislik=6,Id=1,Fiyat=13,oda_sayi="sea" });

               

                var Arsa = context.Arsalar.Add(new Arsa { aciklama_ = "sahibinden", arsa_adres = "kartal", Fiyat = 200, genislik = 100 });
                var Arsa1 = context.Arsalar.Add(new Arsa { aciklama_ = "sahibinden", arsa_adres = "adil", Fiyat = 400, genislik = 200 });
                var Arsa2 = context.Arsalar.Add(new Arsa { aciklama_ = "sahibinden", arsa_adres = "yavuz", Fiyat = 600, genislik = 300 });


                var Dukkan = context.Dukkanlar.Add(new Dukkan { aciklama_ = "sahibinden", dukkan_adres="maltep",geliri="10000",genislik=150,Fiyat=452 });









            }


        }

    }
}
