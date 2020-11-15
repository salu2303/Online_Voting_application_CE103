using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo2.Models
{
    public interface Iaddvoter
    {
        avoter Add(avoter av);
        avoter Getv(String Name,String password);
        avoter Getvote(String Name);
        avoter delete(int id);

    }
}
