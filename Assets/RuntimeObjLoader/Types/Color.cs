using System;

namespace ObjSharp.Types
{
    public class Color
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }

        public Color()
        {
        }

        public Color(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static Color LoadFromStringArray(string[] data)
        {
            var success = float.TryParse(data[1], out var x);
            if (!success) throw new ArgumentException("Could not parse x parameter as double");

            success = float.TryParse(data[2], out var y);
            if (!success) throw new ArgumentException("Could not parse y parameter as double");

            success = float.TryParse(data[3], out var z);
            if (!success) throw new ArgumentException("Could not parse z parameter as double");

            return new Color(x, y, z);
        }
    }
}