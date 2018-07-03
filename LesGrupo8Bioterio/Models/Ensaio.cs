using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        [Display(Name = "Nº de Animais Autorizados")]
        public int? NroAnimaisAutoriz { get; set; }
        [Display(Name = "Projeto")]
        public int ProjetoIdProjeto { get; set; }
        public int LoteIdLote { get; set; }
        public Lote LoteIdLoteNavigation { get; set; }
        public Projeto ProjetoIdProjetoNavigation { get; set; }
        public Projeto Selected;
        public string data;
        public string data2;
        public IQueryable<Projeto> objetoP;
        public int isarchived { get; set; }
    }
}
