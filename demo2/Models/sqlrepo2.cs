using demo2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public class sqlrepo2:Icand
    {
        private readonly ApplicationDbContext context;
        public sqlrepo2(ApplicationDbContext context)
        {
            this.context = context;
        }
        public cand Add(cand c)
        {
            context.cand.Add(c);
            context.SaveChanges();
            return c;

        }
        public IEnumerable<cand> Getc(int id)
        {
            return context.cand.Where(i => i.vtypeId == id);

        }
        public cand Getvtype(int id)
        {
            return context.cand.Where(i => i.Id == id).FirstOrDefault();

        }
    }
}
