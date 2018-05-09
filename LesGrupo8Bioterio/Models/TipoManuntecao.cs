using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class TipoManuntecao
    {
        public TipoManuntecao()
        {
            RegManutencao = new HashSet<RegManutencao>();
        }

        public int IdTManutencao { get; set; }
        public string TManutencao { get; set; }

        public ICollection<RegManutencao> RegManutencao { get; set; }
    }
}
