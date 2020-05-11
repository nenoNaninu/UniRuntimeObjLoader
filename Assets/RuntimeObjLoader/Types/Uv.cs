using System;

namespace ObjSharp.Types
{
    public class Uv
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int Index { get; set; }

        public Uv()
        {

        }

        public Uv(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Uv LoadFromStringArray(string[] data)
        {
            var success = float.TryParse(data[1], out var x);
            if (!success) throw new ArgumentException("Could not parse x parameter as double");

            success = float.TryParse(data[2], out var y);
            if (!success) throw new ArgumentException("Could not parse y parameter as double");

            return new Uv(x, y);
        }
    }
}