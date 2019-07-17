using System;
using System.Collections.Generic;
using System.Text;

namespace GeoDataGen.Geometry
{
    class Hedron1 : Polyhedron
    {

        /*
         * 
         * 
         *  (±1, 0, ±φ)
            ( 0, ±1/φ,  0)
            (±φ, 0, ±1)
         */

        public Hedron1()
       {

            var v1  = new Coordinate(1, 0, GoldenMean);
            var v2  = new Coordinate(1, 0, -GoldenMean);
            var v3  = new Coordinate(-1, 0, GoldenMean);
            var v4  = new Coordinate(-1, 0, -GoldenMean);
            var v5  = new Coordinate(0, 1 / GoldenMean, 0);
            var v6  = new Coordinate(0, -1 / GoldenMean, 0);
            var v7  = new Coordinate(GoldenMean, 0, 1);
            var v8  = new Coordinate(-GoldenMean, 0, 1);
            var v9  = new Coordinate(GoldenMean, 0, -1);
            var v10 = new Coordinate(-GoldenMean, 0, -1);

            this.AddVertex(v1)
                .AddVertex(v2)
                .AddVertex(v3)
                .AddVertex(v4)
                .AddVertex(v5)
                .AddVertex(v6)
                .AddVertex(v7)
                .AddVertex(v8) 
                .AddVertex(v9)
                .AddVertex(v10);

            /*
            this.AddFace(v1, v7, v5);
            this.AddFace(v1, v7, v6);

            this.AddFace(v3, v8, v5);
            this.AddFace(v3, v8, v6);

            this.AddFace(v2, v9, v5);
            this.AddFace(v2, v9, v6);

            this.AddFace(v4, v8, v5);
            this.AddFace(v4, v8, v6);

            this.AddFace(v4, v5, v3);
            this.AddFace(v4, v6, v3);

            this.AddFace(v7, v5, v9);
            this.AddFace(v7, v6, v9);

            this.AddFace(v1, v5, v3);
            this.AddFace(v1, v6, v3);

            this.AddFace(v2, v5, v4);
            this.AddFace(v2, v6, v4);

            this.AddFace(v8, v5, v10);
            this.AddFace(v8, v6, v10);

            this.AddFace(v4, v5, v10);
            this.AddFace(v4, v6, v10);
            */

            this.GenerateShortestDistanceFaces(2);
        }


    }
}
