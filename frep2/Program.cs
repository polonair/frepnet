using System;
using System.Collections.Generic;
using System.Text;

namespace frep2
{
    class Program
    {
        static void Main(string[] args)
        {
            DotLiquid.Template.RegisterFilter(typeof(FrepFilters));
            Settings settings =
#if DEBUG
                Settings.DummyParse();
#else
                Settings.Parse(args);
#endif
            (new Renderer(new DataBase(settings), settings)).Export();
            Console.WriteLine("that's all, folks!");
        }
    }
}
