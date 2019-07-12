using System;

namespace GeoDataGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var c = new Geometry.Cube();
            Console.WriteLine(c.ExportToObj());
            Console.ReadKey();
        }
    }
}
