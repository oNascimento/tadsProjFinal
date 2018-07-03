using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projFinal.Models
{
    [Table("Borrows")]
    public class Borrow
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Users")]
        public int userId { get; set; }
        [ForeignKey("Movies")]
        public int movieId { get; set; }
        public string date { get; set; }
    }
}
