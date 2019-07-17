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

        public void GenerateShortestDistanceFaces(int AllowAbleDistanceCount) 
        {
            AllowAbleDistanceCount = 2;
            var faces = new List<List<Coordinate>>();
            foreach (var vertex in this.Vertices)
            {
                var copySansOne = this.Vertices.ToArray().ToList();
                copySansOne.Remove(vertex);


                var shortestDistance = copySansOne.GroupBy(x => vertex.Distance(x)).OrderBy(x => x.Key)
                                                  .Take(AllowAbleDistanceCount);

                foreach (var distanceGroup in shortestDistance)  
                {

                   //need to generate unique combinations of items in the distance group
                   //that includes the vertex
                   //add that to a face
                   //faces.add(new List<Coordinate>{v1,v2,v3}; etc
                    
                }
                

            }
        }

        public void GenerateLongestDistanceFaces()
        {

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
            //sb.AppendLine("usemtl default");
            sb.AppendLine("s 1"); //smooth shading
            
            //think about performance from strings are evil
            foreach(var face in Faces)
            {
                var vsb = new StringBuilder();
                vsb.Append("f ");
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

        public double Distance(Coordinate other)
        {
          return  Math.Abs(this.X - other.X) + Math.Abs(this.Y - other.Y) + Math.Abs(this.Z - other.Z);
        }


        public override string ToString()
        {
            return "x: " + X + ", y: " + Y + ", z: " + Z;
        }
        public string GetFormated()
        {
            //return string.Format("v {0:N} {0:N} {0:N}", X, Y, Z);
            return "v " + X.ToString("F6") + " " + Y.ToString("F6") + " " + Z.ToString("F6");
        }
    }

}
