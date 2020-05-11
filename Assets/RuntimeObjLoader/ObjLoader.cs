using System;
using System.Linq;
using ObjSharp.Types;


namespace ObjSharp
{
    public static class ObjLoader
    {
        private static readonly char[] _separator = { ' ' };

        /// <summary>
        /// wavefront objのIndexは1スタート。ローダはこっちに合わせる。
        /// </summary>  
        /// <param name="data"></param>
        /// <returns></returns>
        public static Obj LoadObj(string[] data)
        {
            var obj = new Obj();

            foreach (var line in data)
            {
                string[] parts = line.Split(_separator, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length > 0)
                {
                    switch (parts[0])
                    {
                        case "usemtl":
                            obj.CurrentMtl = parts[1];
                            break;
                        
                        case "mtllib":
                            obj.MtlList.Add(parts[1]);
                            break;
                        
                        case "v":
                            var v = Vertex.LoadFromStringArray(parts);
                            obj.VertexList.Add(v);
                            v.Index = obj.VertexList.Count;

                            if (parts.Length == 7)
                            {
                                var vc = VertexColor.LoadFromStringArray(parts);
                                obj.VertexColorList.Add(vc);
                                vc.Index = obj.VertexColorList.Count;
                            }

                            break;
                        
                        case "f":
                            var f = Face.LoadFromStringArray(parts);
                            f.UseMtl = obj.CurrentMtl;
                            obj.FaceList.Add(f);
                            break;
                        
                        case "vt":
                            var uv = Uv.LoadFromStringArray(parts);
                            obj.UvList.Add(uv);
                            uv.Index = obj.UvList.Count;
                            break;

                        case "vn":
                            var vn = NormalVector.LoadFromStringArray(parts);
                            obj.NormalVectorList.Add(vn);
                            vn.Index = obj.NormalVectorList.Count;
                            break;
                    }
                }
            }

            if (obj.VertexColorList.Count != 0)
            {
                obj.ColorType = ColorType.VertexColor;
            }

            var hasTexture = obj.FaceList.FirstOrDefault()?.IsTextureEnable ?? false;

            if (hasTexture)
            {
                obj.ColorType = ColorType.TextureColor;
            }

            return obj;
        }
    }
}