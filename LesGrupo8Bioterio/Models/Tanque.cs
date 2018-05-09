using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class Tanque
    {
        public Tanque()
        {
            RegAlimentar = new HashSet<RegAlimentar>();
            RegAmostragens = new HashSet<RegAmostragens>();
            RegManutencao = new HashSet<RegManutencao>();
            RegRemocoes = new HashSet<RegRemocoes>();
            RegTratamento = new HashSet<RegTratamento>();
        }

        public int IdTanque { get; set; }
        public int NroAnimais { get; set; }
        public string Sala { get; set; }
        public string Observacoes { get; set; }
        public int LoteIdLote { get; set; }
        public int CircuitoTanqueIdCircuito { get; set; }

        public CircuitoTanque CircuitoTanqueIdCircuitoNavigation { get; set; }
        public Lote LoteIdLoteNavigation { get; set; }
        public ICollection<RegAlimentar> RegAlimentar { get; set; }
        public ICollection<RegAmostragens> RegAmostragens { get; set; }
        public ICollection<RegManutencao> RegManutencao { get; set; }
        public ICollection<RegRemocoes> RegRemocoes { get; set; }
        public ICollection<RegTratamento> RegTratamento { get; set; }
    }
}
