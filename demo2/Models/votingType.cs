using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public class votingType
    {
        public int Id { get; set; }
        public string voting_type { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int no { get; set; }

    }
}
