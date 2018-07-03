using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation
using System.Linq;

namespace LesGrupo8Bioterio
{
    public partial class AgenteTrat
    {
        public AgenteTrat()
        {
            RegTratamento = new HashSet<RegTratamento>();
        }

        public int IdAgenTra { get; set; }
        [Required(ErrorMessage = "É necessário preencher este campo para prosseguir.")]
        [Display(Name = "Nome")]
        public string NomeAgenTra { get; set; }

        public Boolean isDeletable;

        public IQueryable<RegTratamento> regAgente;
      
        public ICollection<RegTratamento> RegTratamento { get; set; }
    }
}
