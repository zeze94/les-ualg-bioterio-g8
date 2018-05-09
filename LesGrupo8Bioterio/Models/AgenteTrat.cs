using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class AgenteTrat
    {
        public AgenteTrat()
        {
            RegTratamento = new HashSet<RegTratamento>();
        }

        public int IdAgenTra { get; set; }
        public string NomeAgenTra { get; set; }

        public ICollection<RegTratamento> RegTratamento { get; set; }
    }
}
