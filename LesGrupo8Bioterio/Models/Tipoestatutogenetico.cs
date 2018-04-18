using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio.Models
{
    public partial class Tipoestatutogenetico
    {
        public Tipoestatutogenetico()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdTipoEstatutoGenetico { get; set; }
        public string TipoEstatutoGeneticocol { get; set; }

        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
