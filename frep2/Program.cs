using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frep2
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings settings =
#if DEBUG
                Settings.DummyParse();
#else
                Settings.Parse(args);
#endif
            (new Renderer(new DataBase(settings), settings)).Export();
            Console.ReadLine();
        }
    }
}
