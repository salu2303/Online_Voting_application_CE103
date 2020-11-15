using demo2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public class Sqlrepo : Icreatev
    {
        private readonly ApplicationDbContext context;
        public Sqlrepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public vtype Add(vtype v)
        {
            context.vtype.Add(v);
            context.SaveChanges();
            return v;
            
        }
        public IEnumerable<vtype> Getalltypes()
        {
            return context.vtype;
        }
        public vtype Getv(int id)
        {
            vtype a = context.vtype.Where(i => i.vtypeId == id).FirstOrDefault();
            return a;
        }
        public vtype deletec(int id)
        {
            vtype a = context.vtype.Find(id);
            if (a != null)
            {
                context.vtype.Remove(a);
                context.SaveChanges();
            }
            return a;

        }
    }
}
