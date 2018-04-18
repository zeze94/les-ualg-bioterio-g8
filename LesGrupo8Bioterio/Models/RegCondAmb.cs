using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio.Models
{
    public partial class RegCondAmb
    {
        public int IdRegCondAmb { get; set; }
        public DateTime Data { get; set; }
        public float? Temperatura { get; set; }
        public float? VolAgua { get; set; }
        public float? SalinidadeAgua { get; set; }
        public float? NivelO2 { get; set; }
        public int CircuitoTanqueIdCircuito { get; set; }

        public CircuitoTanque CircuitoTanqueIdCircuitoNavigation { get; set; }
    }
}
