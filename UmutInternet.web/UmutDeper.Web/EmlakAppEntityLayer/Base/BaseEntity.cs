using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakAppEntityLayer.Base
{
    public class BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int Id { get; set; }
    }
}
