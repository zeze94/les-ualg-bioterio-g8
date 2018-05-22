using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation

namespace LesGrupo8Bioterio
{
    public partial class Elementoequipa
    {
        public int IdElementoEquipa { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Função")]
        public string Função { get; set; }
        [Display(Name = "Projeto")]
        public int ProjetoIdProjeto { get; set; }
        [Display(Name = "Funcionário")]
        public int FuncionarioIdFuncionario { get; set; }
        [Display(Name = "Funcionário")]
        public Funcionario FuncionarioIdFuncionarioNavigation { get; set; }
        [Display(Name = "Projeto")]
        public Projeto ProjetoIdProjetoNavigation { get; set; }
    }
}
