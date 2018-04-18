using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio.Models
{
    public partial class Elementoequipa
    {
        public string Função { get; set; }
        public int ProjetoIdProjeto { get; set; }
        public int FuncionarioIdFuncionario { get; set; }

        public Funcionario FuncionarioIdFuncionarioNavigation { get; set; }
        public Projeto ProjetoIdProjetoNavigation { get; set; }
    }
}
