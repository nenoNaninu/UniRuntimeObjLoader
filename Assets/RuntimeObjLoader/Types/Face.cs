using System;

namespace ObjSharp.Types
{
    public class Face 
    {
        public string UseMtl { get; set; }

        public int[] VertexIndexList { get; }
        public int[] TextureVertexIndexList { get; }
        public int[] NormalVectorList { get; }

        public bool IsNormalEnable { get; set; }
        public bool IsTextureEnable { get; set; }

        public Face(int vertexNum)
        {
            VertexIndexList = new int[vertexNum];
            TextureVertexIndexList = new int[vertexNum];
            NormalVectorList = new int[vertexNum];
        }

        /// <summary>
        /// {"f", "10918//10918", "10929//10929", "11168//11168"}的な配列が入ってくることを想定
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Face LoadFromStringArray(string[] data)
        {
            if (data.Length < 4)
                throw new ArgumentException("Input array must be of minimum length 4", nameof(data));
            
            int vertexNum = data.Length - 1;
            var face = new Face(vertexNum);

            for (int i = 0; i < vertexNum; i++)
            {
                string[] parts = data[i + 1].Split('/');

                bool success = int.TryParse(parts[0], out int vertexIndex);
                if (!success) throw new ArgumentException("Could not parse parameter as int");
                face.VertexIndexList[i] = vertexIndex;

                if (parts.Length > 1)
                {
                    if (!string.IsNullOrEmpty(parts[1]))
                    {
                        face.IsTextureEnable = true;
                        success = int.TryParse(parts[1], out int textureVertexIndex);
                        if (success)
                        {
                            face.TextureVertexIndexList[i] = textureVertexIndex;
                        }
                    }
                }

                if (parts.Length > 2)
                {
                    if (!string.IsNullOrEmpty(parts[2]))
                    {
                        face.IsNormalEnable = true;
                        success = int.TryParse(parts[2], out int normalVectorIndex);
                        if (success)
                        {
                            face.NormalVectorList[i] = normalVectorIndex;
                        }
                    }
                }
            }

            return face;
        }
    }
}