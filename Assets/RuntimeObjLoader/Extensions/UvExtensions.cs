using ObjSharp.Types;
using UnityEngine;

namespace ObjSharp.Extensions
{
    public static class UvExtensions
    {
        public static Vector2 AsVector2(this Uv uv)
        {
            return new Vector2(uv.X, uv.Y);
        }
    }
}