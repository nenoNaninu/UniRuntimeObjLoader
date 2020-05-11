using System;

namespace ObjSharp.Types
{
    public class VertexColor
    {
        public int Index { get; set; }

        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }

        public VertexColor()
        {

        }

        public VertexColor(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static VertexColor LoadFromStringArray(string[] data)
        {
            var success = float.TryParse(data[4], out var x);
            if (!success) throw new ArgumentException("Could not parse x parameter as double");

            success = float.TryParse(data[5], out var y);
            if (!success) throw new ArgumentException("Could not parse y parameter as double");

            success = float.TryParse(data[6], out var z);
            if (!success) throw new ArgumentException("Could not parse z parameter as double");

            return new VertexColor(x, y, z);
        }
    }
}