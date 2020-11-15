using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public class roleViewModel
    {

        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
