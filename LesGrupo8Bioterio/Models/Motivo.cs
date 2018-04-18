using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio.Models
{
    public partial class Motivo
    {
        public Motivo()
        {
            RegRemocoes = new HashSet<RegRemocoes>();
        }

        public int IdMotivo { get; set; }
        public string TipoMotivo { get; set; }
        public string NomeMotivo { get; set; }

        public ICollection<RegRemocoes> RegRemocoes { get; set; }
    }
}
