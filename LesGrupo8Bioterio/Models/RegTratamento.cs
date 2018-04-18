using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio.Models
{
    public partial class RegTratamento
    {
        public int IdRegTra { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Tempo { get; set; }
        public float Concentracao { get; set; }
        public int FinalidadeIdFinalidade { get; set; }
        public int AgenteTratIdAgenTra { get; set; }
        public int? ConcAgenTra { get; set; }
        public int TanqueIdTanque { get; set; }

        public AgenteTrat AgenteTratIdAgenTraNavigation { get; set; }
        public Finalidade FinalidadeIdFinalidadeNavigation { get; set; }
        public Tanque TanqueIdTanqueNavigation { get; set; }
    }
}
