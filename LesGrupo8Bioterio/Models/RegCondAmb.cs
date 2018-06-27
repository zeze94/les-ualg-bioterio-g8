using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation

namespace LesGrupo8Bioterio
{
    public partial class RegCondAmb
    {
        public int IdRegCondAmb { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Temperatura")]
        public float? Temperatura { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Volume de água")]
        public float? VolAgua { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Salinidade da água")]
        public float? SalinidadeAgua { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Nível de Oxigénio")]
        public float? NivelO2 { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Circuito Tanque")]
        public int CircuitoTanqueIdCircuito { get; set; }
        [Display(Name = "Circuito Tanque")]
        public CircuitoTanque CircuitoTanqueIdCircuitoNavigation { get; set; }
        public string data;
        public int isarchived { get; set; }
    }
}
