using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LesGrupo8Bioterio
{
    public partial class Motivo
    {
        public Motivo()
        {
            RegRemocoes = new HashSet<RegRemocoes>();
        }

        public int IdMotivo { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Tipo de Motivo")]
        public string TipoMotivo { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Designação do Motivo")]
        public string NomeMotivo { get; set; }
        public Boolean isDeletable;

        public IQueryable<RegRemocoes> regRemocoes;
        public RegRemocoes dummyRemocoes;
        public ICollection<RegRemocoes> RegRemocoes { get; set; }
    }
}
