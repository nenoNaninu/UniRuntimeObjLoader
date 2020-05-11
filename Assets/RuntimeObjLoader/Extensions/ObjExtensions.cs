using System.Numerics;
using ObjSharp.Types;

namespace ObjSharp.Extensions
{
    public static class ObjExtensions
    {

        public static Vertex MakeVertex(this Obj obj, float x, float y, float z)
        {
            var vertex = new Vertex(x, y, z)
            {
                Index = obj.VertexList.Count + 1
            };

            obj.VertexList.Add(vertex);

            return vertex;
        }

        public static Vertex MakeVertex(this Obj obj, Vector3 v)
        {
            var vertex = new Vertex(v.X, v.Y, v.Z)
            {
                Index = obj.VertexList.Count + 1
            };

            obj.VertexList.Add(vertex);

            return vertex;
        }

        public static NormalVector MakeNormalVector(this Obj obj, float x, float y, float z)
        {
            var normalVec = new NormalVector(x, y, z)
            {
                Index = obj.NormalVectorList.Count + 1,
            };

            obj.NormalVectorList.Add(normalVec);

            return normalVec;
        }

        public static NormalVector MakeNormalVector(this Obj obj, Vector3 v)
        {
            var normalVec = new NormalVector(v.X, v.Y, v.Z)
            {
                Index = obj.NormalVectorList.Count + 1,
            };

            obj.NormalVectorList.Add(normalVec);

            return normalVec;
        }

        /// <summary>
        /// Set v1, v2, and v3 to be counterclockwise when viewed from the front of the face.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="normVector"></param>
        /// <returns></returns>
        public static Face MakeFace(this Obj obj, Vertex v1, Vertex v2, Vertex v3)
        {
            //表からみて半時計まわりに頂点が回らないとダメ。
            var face = new Face(3);
            face.VertexIndexList[0] = v1.Index;
            face.VertexIndexList[1] = v2.Index;
            face.VertexIndexList[2] = v3.Index;

            face.UseMtl = obj.CurrentMtl;

            obj.FaceList.Add(face);
            return face;
        }

        /// <summary>
        /// Set v1, v2, and v3 to be counterclockwise when viewed from the front of the face.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="normVector"></param>
        /// <returns></returns>
        public static Face MakeFace(this Obj obj, Vertex v1, Vertex v2, Vertex v3, NormalVector normVector)
        {
            var face = new Face(3);
            face.VertexIndexList[0] = v1.Index;
            face.VertexIndexList[1] = v2.Index;
            face.VertexIndexList[2] = v3.Index;

            face.NormalVectorList[0] = normVector.Index;
            face.NormalVectorList[1] = normVector.Index;
            face.NormalVectorList[2] = normVector.Index;

            face.UseMtl = obj.CurrentMtl;

            face.IsNormalEnable = true;

            obj.FaceList.Add(face);
            return face;
        }

        /// <summary>
        /// Set v1, v2, and v3 to be counterclockwise when viewed from the front of the face.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="normVector"></param>
        /// <param name="textureIndex"></param>
        /// <returns></returns>
        public static Face MakeFace(this Obj obj, Vertex v1, Vertex v2, Vertex v3, NormalVector normVector, int textureIndex)
        {
            //表からみて半時計まわりに頂点が回らないとダメ。

            var face = new Face(3);
            face.IsNormalEnable = true;
            face.IsTextureEnable = true;

            face.VertexIndexList[0] = v1.Index;
            face.VertexIndexList[1] = v2.Index;
            face.VertexIndexList[2] = v3.Index;

            face.NormalVectorList[0] = normVector.Index;
            face.NormalVectorList[1] = normVector.Index;
            face.NormalVectorList[2] = normVector.Index;

            face.TextureVertexIndexList[0] = textureIndex;
            face.TextureVertexIndexList[1] = textureIndex;
            face.TextureVertexIndexList[2] = textureIndex;

            face.UseMtl = obj.CurrentMtl;

            obj.FaceList.Add(face);
            return face;
        }
    }
}
