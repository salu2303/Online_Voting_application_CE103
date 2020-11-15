using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public class addvoter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
        public int votingTypeId { get; set; }
        public votingType vt { get; set; }
    }
}
