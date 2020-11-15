using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public interface Icreatev
    {
        vtype Add(vtype v);
        IEnumerable<vtype> Getalltypes();
        vtype Getv(int id);
        vtype deletec(int id);
    }
}
