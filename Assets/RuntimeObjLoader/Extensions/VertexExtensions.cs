using UnityEngine;
using ObjSharp.Types;

namespace ObjSharp.Extensions
{
    public static class VertexExtensions
    {
        public static Vector3 AsVector3(this Vertex v)
        {
            return new Vector3(v.X, v.Y, v.Z);
        }
    }
}
