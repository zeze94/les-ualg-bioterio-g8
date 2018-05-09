using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class RegAlimentar
    {
        public int IdRegAlim { get; set; }
        public DateTime Data { get; set; }
        public float Peso { get; set; }
        public float? Sobras { get; set; }
        public int PlanoAlimentarIdPlanAlim { get; set; }
        public int TanqueIdTanque { get; set; }

        public PlanoAlimentar PlanoAlimentarIdPlanAlimNavigation { get; set; }
        public Tanque TanqueIdTanqueNavigation { get; set; }
    }
}
