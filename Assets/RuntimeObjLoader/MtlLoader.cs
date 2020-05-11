using System;
using ObjSharp.Types;

namespace ObjSharp
{
    public static class MtlLoader
    {
        private static readonly char[] _separator = { ' ' };
        public static Mtl LoadMtl(string[] data)
        {
            var mtl = new Mtl();

            foreach (var line in data)
            {
                string[] parts = line.Split(_separator, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length > 0)
                {

                    switch (parts[0])
                    {
                        case "newmtl":
                            mtl.Name = parts[1];
                            break;
                        case "map_Kd":
                            mtl.TextureName = parts[1];
                            break;
                        case "Ka":
                            mtl.AmbientReflectivity = Color.LoadFromStringArray(parts);
                            break;
                        case "Kd":
                            mtl.DiffuseReflectivity = Color.LoadFromStringArray(parts);
                            break;
                        case "Ks":
                            mtl.SpecularReflectivity = Color.LoadFromStringArray(parts);
                            break;
                        case "Ke":
                            mtl.EmissiveCoefficient = Color.LoadFromStringArray(parts);
                            break;
                        case "Tf":
                            mtl.TransmissionFilter = Color.LoadFromStringArray(parts);
                            break;
                        case "Ni":
                            mtl.OpticalDensity = float.Parse(parts[1]);
                            break;
                        case "d":
                            mtl.Dissolve = float.Parse(parts[1]);
                            break;
                        case "illum":
                            mtl.IlluminationModel = int.Parse(parts[1]);
                            break;
                        case "Ns":
                            mtl.SpecularExponent = float.Parse(parts[1]);
                            break;
                    }
                }
            }

            return mtl;
        }
    }
}