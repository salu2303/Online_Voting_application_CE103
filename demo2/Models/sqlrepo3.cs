using demo2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public class sqlrepo3:Iresult
    {
        private readonly ApplicationDbContext context;
        public sqlrepo3(ApplicationDbContext context)
        {
            this.context = context;
        }
        public result Add(result c)
        {
            context.result.Add(c);
            context.SaveChanges();
            return c;

        }
        public IEnumerable<result> Getrec(int id,int cid)
        {
            return context.result.Where(i => i.vtypeId == id && i.cid==cid);
        } 
    }
}
