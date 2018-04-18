using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio.Models
{
    public partial class RegAmostragens
    {
        public int IdRegAmo { get; set; }
        public DateTime Data { get; set; }
        public float PesoMedio { get; set; }
        public int NroIndividuos { get; set; }
        public float PesoTotal { get; set; }
        public int TanqueIdTanque { get; set; }

        public Tanque TanqueIdTanqueNavigation { get; set; }
    }
}
