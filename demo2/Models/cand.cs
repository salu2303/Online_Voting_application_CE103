using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public class cand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string profession { get; set; }

        public int vtypeId { get; set; }
        public vtype vt{ get; set; }
    }
}
