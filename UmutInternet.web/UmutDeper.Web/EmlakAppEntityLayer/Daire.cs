using EmlakAppEntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakAppEntityLayer
{
    [Table("tblDaire")]
    public class Daire:BaseEntity
    {
        public string aciklama_ { get; set; }
        public string daire_adres { get; set; }
        public int genislik { get; set; }

        public string oda_sayi { get; set; }
        public int Fiyat { get; set; }
    }
}
