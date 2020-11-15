using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public interface Icand
    {
        cand Add(cand c);
        IEnumerable<cand> Getc(int id);
        cand Getvtype(int id);

    }
}
