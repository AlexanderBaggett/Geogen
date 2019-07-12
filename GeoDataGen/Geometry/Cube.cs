using System;
using System.Collections.Generic;
using System.Text;

namespace GeoDataGen.Geometry
{
    public class Cube : Polyhedron
    {

        public Cube ()
        {

            var v1 = new Coordinate(-1,-1,-1);
            var v2 = new Coordinate(-1,-1, 1);
            var v3 = new Coordinate(-1, 1,-1);
            var v4 = new Coordinate(-1, 1, 1);
            var v5 = new Coordinate( 1,-1,-1);
            var v6 = new Coordinate( 1,-1, 1);
            var v7 = new Coordinate( 1, 1,-1);
            var v8 = new Coordinate( 1, 1, 1);

            this.AddVertex(v1)
                .AddVertex(v2)
                .AddVertex(v3)
                .AddVertex(v4)
                .AddVertex(v5)
                .AddVertex(v6)
                .AddVertex(v7)
                .AddVertex(v8);

            this.AddFace(v1,v5,v6,v2)
                .AddFace(v2,v4,v3,v1)
                .AddFace(v2,v6,v8,v4)
                .AddFace(v3,v7,v5,v1)
                .AddFace(v4,v8,v7,v3)
                .AddFace(v5,v7,v8,v6);

        }
    }
}
