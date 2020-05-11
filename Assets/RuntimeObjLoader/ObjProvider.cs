using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ObjSharp.Extensions;
using ObjSharp.Types;
using UnityEngine;

namespace ObjSharp
{

    public class ObjProvider : MonoBehaviour
    {
        public GameObject TextureTemplate;
        public GameObject VertexColorTemplate;

        public GameObject Load(string path)
        {
            var lines = File.ReadAllLines(path);
            var obj = ObjLoader.LoadObj(lines);
            var mesh = ConvertMesh(obj);

            if (obj.ColorType == ColorType.VertexColor)
            {
                var template = Instantiate(VertexColorTemplate);
                var meshFilter = template.GetComponent<MeshFilter>();

                meshFilter.mesh = mesh;

                return template;
            }
            else
            {
                var template = Instantiate(TextureTemplate);
                var meshFilter = template.GetComponent<MeshFilter>();

                meshFilter.mesh = mesh;
                return template;
            }
        }


        public GameObject Load(string[] data)
        {
            var obj = ObjLoader.LoadObj(data);
            var mesh = ConvertMesh(obj);

            if (obj.ColorType == ColorType.VertexColor)
            {
                var template = Instantiate(VertexColorTemplate);
                var meshFilter = template.GetComponent<MeshFilter>();

                meshFilter.mesh = mesh;

                return template;
            }
            else
            {
                var template = Instantiate(TextureTemplate);
                var meshFilter = template.GetComponent<MeshFilter>();

                meshFilter.mesh = mesh;
                return template;
            }
        }

        /// <summary>
        /// 頂点のインデックスに対応する法線のインデックスを探す。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="index">頂点のインデックス</param>
        /// <returns></returns>
        private static int FindNormalIndex(Obj obj, int index)
        {
            foreach (var face in obj.FaceList)
            {
                var result = Array.IndexOf(face.VertexIndexList, index);
                if (result < 0)
                {
                    continue;
                }

                return face.NormalVectorList[result];
            }

            return -1;
        }

        /// <summary>
        /// 頂点のインデックスに対応する法線のインデックスを探す。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="index">頂点のインデックス</param>
        /// <returns></returns>
        private static int FindTextureIndex(Obj obj, int index)
        {
            foreach (var face in obj.FaceList)
            {
                var result = Array.IndexOf(face.VertexIndexList, index);
                if (result < 0)
                {
                    continue;
                }

                return face.TextureVertexIndexList[result];
            }

            return -1;
        }

        /// <summary>
        /// ObjはUnityに全く関係ない(依存しない)形式。なので、それをUnityに依存する形に変換する。
        /// </summary>
        /// <param name="obj"></param>
        public static Mesh ConvertMesh(Obj obj)
        {
            var mesh = new Mesh();

            //頂点はそのまま。
            var vertices = obj.VertexList.Select(x => x.AsVector3()).ToList();
            mesh.SetVertices(vertices);

            if (obj.NormalVectorList.Count != 0)
            {
                //Unityの法線はどうやら頂点ごとに決まっているが、Objは面ごとに決まっているので若干変換をしないと行けない。
                var normalsList = new List<Vector3>(vertices.Count);
                for (int i = 0; i < obj.VertexList.Count; i++)
                {
                    // obj.VertexList[i]が含まれているfaceを探してくる。
                    // objのindexは1スタートなので1を足す。
                    var normalIndex = FindNormalIndex(obj, i + 1);

                    var normal = obj.NormalVectorList[normalIndex - 1].AsVector3();
                    normalsList.Add(normal);
                }

                mesh.SetNormals(normalsList);
            }


            //頂点カラーの設定
            if (obj.ColorType == ColorType.VertexColor)
            {
                var colors = obj.VertexColorList.Select(x => x.AsColor()).ToList();
                mesh.SetColors(colors);
            }

            //uvの設定
            if (obj.ColorType == ColorType.TextureColor)
            {
                var uvList = new List<Vector3>(vertices.Count);
                for (int i = 0; i < obj.VertexList.Count; i++)
                {
                    // obj.VertexList[i]が含まれているfaceを探してくる。
                    // objのindexは1スタートなので1を足す。
                    var uvIndex = FindTextureIndex(obj, i + 1);

                    var uv = obj.UvList[uvIndex - 1].AsVector2();
                    uvList.Add(uv);
                }

                mesh.SetUVs(0, uvList);
            }

            //Unityは表からみて時計回り、
            //Wavefront objは反時計周り.
            //このあたりを修正する。
            var triangleArray = new List<int>(obj.FaceList.Count * 3);
            foreach (var face in obj.FaceList)
            {
                var v1 = face.VertexIndexList[0] - 1;
                var v2 = face.VertexIndexList[1] - 1;
                var v3 = face.VertexIndexList[2] - 1;

                triangleArray.Add(v1);
                triangleArray.Add(v2);
                triangleArray.Add(v3);
            }

            mesh.SetTriangles(triangleArray, 0);

            return mesh;
        }
    }
}