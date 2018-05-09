using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Elementoequipa = new HashSet<Elementoequipa>();
            Lote = new HashSet<Lote>();
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdFuncionario { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeUtilizador { get; set; }
        public string Password { get; set; }
        public string Telefone { get; set; }

        public ICollection<Elementoequipa> Elementoequipa { get; set; }
        public ICollection<Lote> Lote { get; set; }
        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
