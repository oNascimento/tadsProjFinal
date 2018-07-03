using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projFinal.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
        public string email { get; set; }
    }
}
