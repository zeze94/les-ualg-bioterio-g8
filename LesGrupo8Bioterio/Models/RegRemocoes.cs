using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation

namespace LesGrupo8Bioterio
{
    public partial class RegRemocoes
    {
        public int IdRegRemo { get; set; }
        [Display(Name = "Data")]
        public DateTime Date { get; set; }
        [Display(Name = "Nº de Removidos")]
        public int? NroRemoções { get; set; }
        [Display(Name = "Motivo")]
        public int MotivoIdMotivo { get; set; }
        [Display(Name = "Causa da Morte")]
        public string CausaMorte { get; set; }
        [Display(Name = "Tanque")]
        public int TanqueIdTanque { get; set; }
        [Display(Name = "Motivo")]
        public Motivo MotivoIdMotivoNavigation { get; set; }
        [Display(Name = "Tanque")]
        public Tanque TanqueIdTanqueNavigation { get; set; }
    }
}
