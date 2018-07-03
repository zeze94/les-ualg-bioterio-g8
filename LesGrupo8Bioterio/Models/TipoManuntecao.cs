using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation
using System.Linq;
namespace LesGrupo8Bioterio
{
    public partial class TipoManuntecao
    {
        internal object regManutencao;

        public TipoManuntecao()
        {
            RegManutencao = new HashSet<RegManutencao>();
        }

        public int IdTManutencao { get; set; }
        [Required(ErrorMessage = "É necessário preencher este campo para prosseguir.")]
        [Display(Name = "Nome da Manutenção")]
        public string TManutencao { get; set; }
        [Display(Name = "Registo de Manutenção")]
        public ICollection<RegManutencao> RegManutencao { get; set; }
        public Boolean isDeletable;
        public IQueryable<RegTratamento> regManutecao;
    }
}
