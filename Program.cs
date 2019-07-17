using System;

namespace GeoDataGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var c = new Geometry.Hedron1();
            Console.WriteLine(c.ExportToObj());
            Console.ReadKey();
        }
    }
}
