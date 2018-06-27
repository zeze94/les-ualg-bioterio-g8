using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LesGrupo8Bioterio
{
    public partial class PlanoAlimentar
    {
        public PlanoAlimentar()
        {
            RegAlimentar = new HashSet<RegAlimentar>();
        }

        public int IdPlanAlim { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Produto Alimentar")]
        public string MarcaAlim { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Tipo")]
        public int Tipo { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Temperatura")]
        public float Temperatura { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Quantidade de Ração")]
        public float? Racao { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Nº de Alimentações por dia")]
        public float RacaoDia { get; set; }

        public ICollection<RegAlimentar> RegAlimentar { get; set; }
        public Boolean isDeletable;
        public IQueryable<RegAlimentar> regAli;
    }
}
