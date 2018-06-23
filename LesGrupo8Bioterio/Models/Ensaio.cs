using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LesGrupo8Bioterio
{
    public partial class Ensaio
    {
        public int IdEnsaio { get; set; }
        [Display(Name = "Data de Inicio")]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Data de Fim")]
        public DateTime DataFim { get; set; }
        [Display(Name = "Descrição de Tratamento")]
        public string DescTratamento { get; set; }
        [Display(Name = "Grau de Severidade")]
        public int GrauSeveridade { get; set; }
        [Display(Name = "Projeto")]
        public int ProjetoIdProjeto { get; set; }
        [Display(Name = "Lote")]
        public int LoteIdLote { get; set; }
        [Display(Name = "Lote")]
        public Lote LoteIdLoteNavigation { get; set; }
        [Display(Name = "Projeto")]
        public Projeto ProjetoIdProjetoNavigation { get; set; }
        public Projeto Selected;
        public int isarchived { get; set; }
    }
}
