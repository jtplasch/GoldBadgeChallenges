using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    class Program
    {
        static void Main(string[] args)
        {
            Challenge2UI UI = new Challenge2UI();
            UI.Seed();
            UI.Run();
        }
    }
}
