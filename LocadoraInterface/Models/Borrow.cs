﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraInterface.Models
{
    class Borrow
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int movieId { get; set; }
        public string date { get; set; }
    }
}
