using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class Especie
    {
        public int IdEspecie { get; set; }
        public string NomeCient { get; set; }
        public string NomeVulgar { get; set; }
        public int FamiliaIdFamilia { get; set; }
        public int FamiliaGrupoIdGrupo { get; set; }

        public Familia Familia { get; set; }
    }
}
