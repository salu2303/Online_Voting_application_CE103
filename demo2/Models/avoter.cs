using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public class avoter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
        public int vtypeId { get; set; }
        public vtype vt { get; set; }
    }
}
