using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation
namespace LesGrupo8Bioterio
{
    public partial class RegTratamento
    {
        public int IdRegTra { get; set; }
        [Display(Name = "Data")]
        public DateTime Date { get; set; }
        [Display(Name = "Tempo")]
        public int Tempo { get; set; }
        [Display(Name = "Concentração")]
        public float Concentracao { get; set; }
        [Display(Name = "Finalidade")]
        public int FinalidadeIdFinalidade { get; set; }
        [Display(Name = "Agente de Tratamento")]
        public int AgenteTratIdAgenTra { get; set; }
        [Display(Name = "Concentração Agente Tratamento")]
        public int? ConcAgenTra { get; set; }
        [Display(Name = "Tanque")]
        public int TanqueIdTanque { get; set; }
        [Display(Name = "Agente de Tratamento")]
        public AgenteTrat AgenteTratIdAgenTraNavigation { get; set; }
        [Display(Name = "Finalidade")]
        public Finalidade FinalidadeIdFinalidadeNavigation { get; set; }
        [Display(Name = "Tanque")]
        public Tanque TanqueIdTanqueNavigation { get; set; }
        public string data;
    }
}
