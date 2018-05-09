using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }
        [Display(Name = "Nome de Utilizador")]
        public string NomeUtilizador { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Contacto")]
        public string Telefone { get; set; }

        public ICollection<Elementoequipa> Elementoequipa { get; set; }
        public ICollection<Lote> Lote { get; set; }
        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
