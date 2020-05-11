using UnityEngine;
using ObjSharp.Types;

namespace ObjSharp.Extensions
{
    public static class NormalVectorExtensions
    {
        public static Vector3 AsVector3(this NormalVector obj)
        {
            return new Vector3(obj.X, obj.Y, obj.Z);
        }
    }
}
