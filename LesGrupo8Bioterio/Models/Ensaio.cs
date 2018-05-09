using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class Ensaio
    {
        public int IdEnsaio { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string DescTratamento { get; set; }
        public int GrauSeveridade { get; set; }
        public int ProjetoIdProjeto { get; set; }
        public int LoteIdLote { get; set; }
        public int MembroEquipaIdEquipa { get; set; }

        public Lote LoteIdLoteNavigation { get; set; }
        public Projeto ProjetoIdProjetoNavigation { get; set; }
    }
}
