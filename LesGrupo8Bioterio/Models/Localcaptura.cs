using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class Localcaptura
    {
        public int IdLocalCaptura { get; set; }
        public string Localidade { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public int ConselhoId { get; set; }
        public int ConselhoDistritoId { get; set; }

        public Conselho Conselho { get; set; }
    }
}
