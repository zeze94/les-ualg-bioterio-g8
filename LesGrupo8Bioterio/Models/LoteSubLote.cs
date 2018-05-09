using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class LoteSubLote
    {
        public int LoteIdLotePrev { get; set; }
        public int LoteIdLoteAtual { get; set; }
        public string CodigoSubLote { get; set; }

        public Lote LoteIdLoteAtualNavigation { get; set; }
        public Lote LoteIdLotePrevNavigation { get; set; }
    }
}
