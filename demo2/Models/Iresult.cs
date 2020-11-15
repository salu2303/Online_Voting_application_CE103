using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public interface Iresult
    {
        result Add(result r);
        IEnumerable<result> Getrec(int id,int cid);
    }
}
