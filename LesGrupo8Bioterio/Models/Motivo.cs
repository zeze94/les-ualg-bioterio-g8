using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LesGrupo8Bioterio
{
    public partial class Motivo
    {
        public Motivo()
        {
            RegRemocoes = new HashSet<RegRemocoes>();
        }

        public int IdMotivo { get; set; }
        [Display(Name = "Tipo de Motivo")]
        public string TipoMotivo { get; set; }
        [Display(Name = "Designação do Motivo")]
        public string NomeMotivo { get; set; }

        public ICollection<RegRemocoes> RegRemocoes { get; set; }
    }
}
