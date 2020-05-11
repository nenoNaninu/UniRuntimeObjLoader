using ObjSharp.Types;

namespace ObjSharp.Extensions
{
    public static class VertexColorExtensions
    {
        public static UnityEngine.Color AsColor(this VertexColor v)
        {
            return new UnityEngine.Color(v.R, v.G, v.B);
        }
    }
}