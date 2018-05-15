using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation
namespace LesGrupo8Bioterio
{
    public partial class TipoManuntecao
    {
        public TipoManuntecao()
        {
            RegManutencao = new HashSet<RegManutencao>();
        }

        public int IdTManutencao { get; set; }
        [Display(Name = "Nome da Manutenção")]
        public string TManutencao { get; set; }
        [Display(Name = "Registo de Manutenção")]
        public ICollection<RegManutencao> RegManutencao { get; set; }
    }
}
