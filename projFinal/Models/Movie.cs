using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projFinal.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
        public int year { get; set; }

    }
}
