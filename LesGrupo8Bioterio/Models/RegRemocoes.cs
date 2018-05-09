using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class RegRemocoes
    {
        public int IdRegRemo { get; set; }
        public DateTime Date { get; set; }
        public int? NroRemoções { get; set; }
        public int MotivoIdMotivo { get; set; }
        public string CausaMorte { get; set; }
        public int TanqueIdTanque { get; set; }

        public Motivo MotivoIdMotivoNavigation { get; set; }
        public Tanque TanqueIdTanqueNavigation { get; set; }
    }
}
