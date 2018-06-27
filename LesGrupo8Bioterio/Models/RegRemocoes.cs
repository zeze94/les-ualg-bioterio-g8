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
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        public DateTime Date { get; set; }
        [Display(Name = "Nº de Removidos")]
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Range(0, 99999999999999, ErrorMessage = "Este Número deve ser positivo")]
        public int? NroRemoções { get; set; }
        [Display(Name = "Motivo")]
        public int MotivoIdMotivo { get; set; }
        [Display(Name = "Causa da Morte")]
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        public string CausaMorte { get; set; }
        [Display(Name = "Tanque")]
        public int TanqueIdTanque { get; set; }
        [Display(Name = "Motivo")]
        public Motivo MotivoIdMotivoNavigation { get; set; }
        [Display(Name = "Tanque")]
        public Tanque TanqueIdTanqueNavigation { get; set; }
        public string data;
        public int isarchived { get; set; }
    }
}
