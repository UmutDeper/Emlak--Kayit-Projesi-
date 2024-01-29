using EmlakAppEntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakAppEntityLayer
{
    [Table("tblDukkan")]
    public class Dukkan:BaseEntity
    {
        public string aciklama_ { get; set; }
        public string dukkan_adres { get; set; }
        public int genislik { get; set; }
        public string geliri { get; set; }
        
        public int Fiyat { get; set; }

    }
}
