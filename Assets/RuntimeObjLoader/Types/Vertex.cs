﻿using System;

namespace ObjSharp.Types
{
    public class Vertex
    {
        public int Index { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vertex()
        {

        }

        public Vertex(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vertex LoadFromStringArray(string[] data)
        {
            var success = float.TryParse(data[1], out var x);
            if (!success) throw new ArgumentException("Could not parse x parameter as double");

            success = float.TryParse(data[2], out var y);
            if (!success) throw new ArgumentException("Could not parse y parameter as double");

            success = float.TryParse(data[3], out var z);
            if (!success) throw new ArgumentException("Could not parse z parameter as double");

            return new Vertex(x, y, z);
        }
    }
}