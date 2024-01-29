using EmlakAppEntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakAppEntityLayer
{
    [Table("tblArsa")]
    public class Arsa :BaseEntity
    {
        public string aciklama_ { get; set; }
        public string arsa_adres { get; set; }
        public int genislik { get; set; }

        public int Fiyat { get; set; }
    }
}
