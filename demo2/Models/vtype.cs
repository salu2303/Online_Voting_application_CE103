using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public class vtype
    {
        public int vtypeId { get; set; }
        [Required]
        public string voting_type { get; set; }
        [Required]

        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        [Required]

        public int no { get; set; }
        public ICollection<avoter> avoters { get; set; }
        public ICollection<cand> cands { get; set; }
        public ICollection<result> results { get; set; }

    }
}
