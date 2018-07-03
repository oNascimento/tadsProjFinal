using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraInterface.Models
{
    class Movie
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }

        public static implicit operator Movie(BindingSource v)
        {
            throw new NotImplementedException();
        }
    }
}
