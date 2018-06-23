using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LesGrupo8Bioterio
{
    public partial class Finalidade
    {
        public Finalidade()
        {
            RegTratamento = new HashSet<RegTratamento>();
        }

        public int IdFinalidade { get; set; }
        [Required(ErrorMessage = "É necessário preencher este campo para prosseguir.")]
        [Display(Name = "Finalidade")]
        public string TFinalidade { get; set; }

        public ICollection<RegTratamento> RegTratamento { get; set; }
    }
}
