using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio.Models
{
    public partial class RegManutencao
    {
        public int IdRegMan { get; set; }
        public DateTime Data { get; set; }
        public int TipoManuntecaoIdTManutencao { get; set; }
        public int TanqueIdTanque { get; set; }

        public Tanque TanqueIdTanqueNavigation { get; set; }
        public TipoManuntecao TipoManuntecaoIdTManutencaoNavigation { get; set; }
    }
}
