using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio
{
    public partial class RegNovosAnimais
    {
        public RegNovosAnimais()
        {
            Lote = new HashSet<Lote>();
        }

        public int IdRegAnimal { get; set; }
        public int NroExemplares { get; set; }
        public int? NroMachos { get; set; }
        public int? NroFemeas { get; set; }
        public int? Imaturos { get; set; }
        public int? Juvenis { get; set; }
        public int? Larvas { get; set; }
        public int? Ovos { get; set; }
        public DateTime? DataNasc { get; set; }
        public int? Idade { get; set; }
        public float? PesoMedio { get; set; }
        public float? CompMedio { get; set; }
        public TimeSpan? DuracaoViagem { get; set; }
        public int? TempPartida { get; set; }
        public int? TempChegada { get; set; }
        public int? NroContentores { get; set; }
        public string TipoContentor { get; set; }
        public float? VolContentor { get; set; }
        public float? VolAgua { get; set; }
        public int? NroCaixasIsoter { get; set; }
        public int? NroMortosCheg { get; set; }
        public float? SatO2transp { get; set; }
        public float? Anestesico { get; set; }
        public sbyte? Gelo { get; set; }
        public sbyte? AdicaoO2 { get; set; }
        public sbyte? Arejamento { get; set; }
        public sbyte? Refrigeracao { get; set; }
        public sbyte? Sedação { get; set; }
        public string RespTransporte { get; set; }
        public int EspecieIdEspecie { get; set; }
        public int FornecedorIdFornColect { get; set; }
        public int TOrigemIdTOrigem { get; set; }
        public int? LocalCapturaIdLocalCaptura { get; set; }
        public int TipoEstatutoGeneticoIdTipoEstatutoGenetico { get; set; }
        public int FuncionarioIdFuncionario { get; set; }

        public Fornecedorcolector FornecedorIdFornColectNavigation { get; set; }
        public Funcionario FuncionarioIdFuncionarioNavigation { get; set; }
        public TOrigem TOrigemIdTOrigemNavigation { get; set; }
        public Tipoestatutogenetico TipoEstatutoGeneticoIdTipoEstatutoGeneticoNavigation { get; set; }
        public ICollection<Lote> Lote { get; set; }
    }
}
