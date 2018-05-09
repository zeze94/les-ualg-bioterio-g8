using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class Grupo
    {
        public Grupo()
        {
            Familia = new HashSet<Familia>();
        }

        public int IdGrupo { get; set; }
        public string NomeGrupo { get; set; }

        public ICollection<Familia> Familia { get; set; }
    }
}
