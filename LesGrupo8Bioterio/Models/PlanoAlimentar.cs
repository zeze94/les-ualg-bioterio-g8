using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio.Models
{
    public partial class PlanoAlimentar
    {
        public PlanoAlimentar()
        {
            RegAlimentar = new HashSet<RegAlimentar>();
        }

        public int IdPlanAlim { get; set; }
        public string Nome { get; set; }
        public string MarcaAlim { get; set; }
        public int Tipo { get; set; }
        public float Temperatura { get; set; }
        public float? Racao { get; set; }
        public float RacaoDia { get; set; }

        public ICollection<RegAlimentar> RegAlimentar { get; set; }
    }
}
