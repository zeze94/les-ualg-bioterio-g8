using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio.Models
{
    public partial class Lote
    {
        public Lote()
        {
            Ensaio = new HashSet<Ensaio>();
            LoteSubLoteLoteIdLoteAtualNavigation = new HashSet<LoteSubLote>();
            LoteSubLoteLoteIdLotePrevNavigation = new HashSet<LoteSubLote>();
            Tanque = new HashSet<Tanque>();
        }

        public int IdLote { get; set; }
        public string CodigoLote { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Observacoes { get; set; }
        public int RegNovosAnimaisIdRegAnimal { get; set; }
        public int FuncionarioIdFuncionario { get; set; }

        public Funcionario FuncionarioIdFuncionarioNavigation { get; set; }
        public RegNovosAnimais RegNovosAnimaisIdRegAnimalNavigation { get; set; }
        public ICollection<Ensaio> Ensaio { get; set; }
        public ICollection<LoteSubLote> LoteSubLoteLoteIdLoteAtualNavigation { get; set; }
        public ICollection<LoteSubLote> LoteSubLoteLoteIdLotePrevNavigation { get; set; }
        public ICollection<Tanque> Tanque { get; set; }
    }
}
