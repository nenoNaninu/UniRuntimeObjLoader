using System.Text;
using ObjSharp.Types;

namespace ObjSharp
{
    public class Mtl
    {
        public string Name { get; set; }
        public Color AmbientReflectivity { get; set; }
        public Color DiffuseReflectivity { get; set; }
        public Color SpecularReflectivity { get; set; }
        public Color TransmissionFilter { get; set; }
        public Color EmissiveCoefficient { get; set; }
        public float SpecularExponent { get; set; }
        public float OpticalDensity { get; set; }
        public float Dissolve { get; set; }
        public float IlluminationModel { get; set; }
        public string TextureName { get; set; }


        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"newmtl {Name}");

            stringBuilder.AppendLine($"Ka {AmbientReflectivity}");
            stringBuilder.AppendLine($"Kd {DiffuseReflectivity}");
            stringBuilder.AppendLine($"Ks {SpecularReflectivity}");
            stringBuilder.AppendLine($"Tf {TransmissionFilter}");
            stringBuilder.AppendLine($"Ke {EmissiveCoefficient}");
            stringBuilder.AppendLine($"Ns {SpecularExponent}");
            stringBuilder.AppendLine($"Ni {OpticalDensity}");
            stringBuilder.AppendLine($"d {Dissolve}");
            stringBuilder.AppendLine($"illum {IlluminationModel}");

            return stringBuilder.ToString();
        }
    }
}