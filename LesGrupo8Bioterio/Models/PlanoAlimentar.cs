using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LesGrupo8Bioterio
{
    public partial class PlanoAlimentar
    {
        public PlanoAlimentar()
        {
            RegAlimentar = new HashSet<RegAlimentar>();
        }

        public int IdPlanAlim { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Produto Alimentar")]
        public string MarcaAlim { get; set; }
        [Display(Name = "Tipo")]
        public int Tipo { get; set; }
        [Display(Name = "Temperatura")]
        public float Temperatura { get; set; }
        [Display(Name = "Quantidade de Ração")]
        public float? Racao { get; set; }
        [Display(Name = "Nº de Alimentações por dia")]
        public float RacaoDia { get; set; }

        public ICollection<RegAlimentar> RegAlimentar { get; set; }
    }
}
