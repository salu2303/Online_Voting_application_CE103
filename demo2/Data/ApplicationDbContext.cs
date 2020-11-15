using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using demo2.Models;

namespace demo2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<demo2.Models.votingType> votingType { get; set; }
        public DbSet<demo2.Models.addvoter> addvoter { get; set; }
        public DbSet<demo2.Models.vtype> vtype { get; set; }
        public DbSet<demo2.Models.avoter> avoter { get; set; }
        public DbSet<demo2.Models.cand> cand { get; set; }

        public DbSet<demo2.Models.result> result { get; set; }

    }
}
