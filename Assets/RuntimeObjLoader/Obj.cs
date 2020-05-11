using System.Collections.Generic;
using ObjSharp.Types;


namespace ObjSharp
{
    public class Obj
    {
        public ColorType ColorType { get; set; } = ColorType.None;

        public List<Vertex> VertexList { get; }
        public List<VertexColor> VertexColorList { get; }

        public List<Mtl> MtlList { get; }
        public List<string> MtlFileList { get; }

        public List<Face> FaceList { get; }

        public List<NormalVector> NormalVectorList { get; }

        public List<Uv> UvList { get; }

        public string CurrentMtl { get; set; }

        public Obj(int capacity)
        {
            VertexList = new List<Vertex>(capacity);
            FaceList = new List<Face>(capacity);
            NormalVectorList = new List<NormalVector>(capacity);
            UvList = new List<Uv>(capacity);
            VertexColorList = new List<VertexColor>(capacity);

            MtlList = new List<Mtl>();
            MtlFileList = new List<string>();
        }

        public Obj() : this(4096) { }


    }
}