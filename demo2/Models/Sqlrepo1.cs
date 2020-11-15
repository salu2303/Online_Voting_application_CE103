using demo2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public class Sqlrepo1:Iaddvoter
    {
        private readonly ApplicationDbContext context;
        public Sqlrepo1(ApplicationDbContext context)
        {
            this.context = context;
        }

        public avoter Add(avoter v)
        {
            context.avoter.Add(v);
            context.SaveChanges();
            return v;

        }
        public avoter Getv(String name,String password)
        {
            avoter a = context.avoter.Where(i => i.Name == name && i.password == password).FirstOrDefault();
            return a;
          
        }
        public avoter Getvote(String name)
        {
            avoter a = context.avoter.Where(i => i.Name == name).FirstOrDefault();
            return a;

        }
        public avoter delete(int id)
        {
            avoter a = context.avoter.Find(id);
            if(a!=null)
            {
                context.avoter.Remove(a);
                context.SaveChanges();
            }
            return a;

        }

    }
}
