using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GeoDataGen
{
   public class Polyhedron
    {

        List<Coordinate> Vertices = new List<Coordinate>();
        List<List<Coordinate>> Faces = new List<List<Coordinate>>();
        
        public double GoldenMean {get { return (1 + Math.Sqrt(5)) / 2; } }

        public int GetVertexCount()
        {
            return Vertices.Count;
        }
        public int GetFaceCount()
        {
            return Faces.Count;
        }

        public Polyhedron AddFace(params Coordinate[] vertices  )
        {
            return this.AddFace(vertices.ToList());
        }

        public Polyhedron AddFace(List<Coordinate> face)
        {
            foreach(var vertex in face)
            {
                if(!Vertices.Contains(vertex))
                {
                    return this;
                }
            }
            Faces.Add(face);
            return this;
        }

        public Polyhedron AddVertices(params Coordinate [] vertices)
        {
            return this.AddVertices(vertices.ToList());
        }

        public Polyhedron AddVertices(IEnumerable<Coordinate> vertices)
        {
            this.Vertices.AddRange(vertices);
            this.Vertices = this.Vertices.Distinct().ToList();
            return this;
        }


        public Polyhedron AddVertex(double x, double y, double z)
        {
            return this.AddVertex(new Coordinate(x, y, z));
        }
        public Polyhedron AddVertex(Coordinate vertex)
        {
            if(this.Vertices.Contains(vertex))
            {
                return this;
            }
            Vertices.Add(vertex);
            return this;
        }
        public string ExportToObj()
        {
            
            int i(Coordinate c)
            {
                return Vertices.IndexOf(c) +1; //obj doesn't use array indexing
            }

            StringBuilder sb = new StringBuilder();
            var name = this.GetType().ToString();
            sb.AppendLine("o "+name+"1");
            foreach(var vertex in Vertices)
            {
                sb.AppendLine(vertex.GetFormated());
            }
            sb.AppendLine("g " + name + "1");
            sb.AppendLine("s 1"); //smooth shading
            
            //think about performance from strings are evil
            foreach(var face in Faces)
            {
                var vsb = new StringBuilder();   
                foreach(var vertex in face)
                {
                    vsb.Append(i(vertex) + "// ");
                }
                sb.AppendLine(vsb.ToString());
            }
            return sb.ToString();
        }

        public void ScaleX(double factor)
        {

        }
        public void ScaleY(double factor)
        {

        }
        public void ScaleZ(double factor)
        {
           
        }
        /*
        public void ApplyScalar(Func<double,void> scalarFunction)
        {
            foreach(var vertex in Vertices)
            {
                scalarFunction(vertex);
            }
            foreach(var face in Faces)
            {
                foreach(var vertex in face)
                {

                }
            }
        }

        public void ApplyMatrix()
        {

        }
        */

    }

    public struct Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Coordinate(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public override string ToString()
        {
            return "x: " + X + ", y: " + Y + ", z: " + Z;
        }
        public string GetFormated()
        {
            return string.Format("v {0,5} {0,5} {0,5}", X, Y, Z);
        }
    }

}
