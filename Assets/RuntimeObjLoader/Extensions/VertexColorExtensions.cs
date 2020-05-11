using ObjSharp.Types;
using UnityEngine;

namespace ObjSharp.Extensions
{
    public static class VertexColorExtensions
    {
        public static Color AsColor(this VertexColor v)
        {
            return new Color(v.R, v.G, v.B);
        }
    }
}