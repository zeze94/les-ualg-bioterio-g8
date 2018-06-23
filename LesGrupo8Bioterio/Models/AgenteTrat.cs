using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation
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

        public ICollection<RegTratamento> RegTratamento { get; set; }
    }
}
