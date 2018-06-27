using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LesGrupo8Bioterio
{
    public partial class Ensaio
    {
        public int IdEnsaio { get; set; }
        [Required(ErrorMessage = "É necessário preecnher este campo para Prosseguir")]
        [Display(Name = "Data de Inicio")]
        public DateTime DataInicio { get; set; }
        [Required(ErrorMessage = "É necessário preecnher este campo para Prosseguir")]
        [Display(Name = "Data de Fim")]
        public DateTime DataFim { get; set; }
        [Required(ErrorMessage = "É necessário preecnher este campo para Prosseguir")]
        [Display(Name = "Descrição de Tratamento")]
        public string DescTratamento { get; set; }
        [Required(ErrorMessage = "É necessário preecnher este campo para Prosseguir")]
        [Display(Name = "Grau de Severidade")]
        public int GrauSeveridade { get; set; }
        [Required(ErrorMessage = "É necessário preecnher este campo para Prosseguir")]
        [Display(Name = "Projeto")]
        public int ProjetoIdProjeto { get; set; }
        [Required(ErrorMessage = "É necessário preecnher este campo para Prosseguir")]
        [Display(Name = "Lote")]
        public int LoteIdLote { get; set; }
        [Required(ErrorMessage = "É necessário preecnher este campo para Prosseguir")]
        [Display(Name = "Lote")]
        public Lote LoteIdLoteNavigation { get; set; }
        [Required(ErrorMessage = "É necessário preecnher este campo para Prosseguir")]
        [Display(Name = "Projeto")]
        public Projeto ProjetoIdProjetoNavigation { get; set; }
        public Projeto Selected;
        public string data;
        public string data2;
       
        public int isarchived { get; set; }
    }
}
