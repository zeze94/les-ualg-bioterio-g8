using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio.Models
{
    public partial class Fornecedorcolector
    {
        public Fornecedorcolector()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdFornColect { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public int? Nif { get; set; }
        public int? NroLicenca { get; set; }
        public string Morada { get; set; }
        public string Telefone { get; set; }

        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
