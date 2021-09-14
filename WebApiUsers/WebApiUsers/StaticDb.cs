using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUsers
{
    public static class StaticDb
    {
        public static List<string> Users = new List<string>
        {
            "Tom",
            "Jack",
            "Fredo"
        };
    }
}
