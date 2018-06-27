using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation

namespace LesGrupo8Bioterio
{
    public partial class RegAmostragens
    {
        public int IdRegAmo { get; set; }
        [Display(Name = "Data")]
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        public DateTime Data { get; set; }
        [Display(Name = "Peso Médio")]
        [Range(0,99999999999999, ErrorMessage ="Este Número deve ser positivo")]
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        public float PesoMedio { get; set; }
        [Display(Name = "Número de Individuos")]
        [Range(0, 99999999999999, ErrorMessage = "Este Número deve ser positivo")]
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        public int NroIndividuos { get; set; }
        [Display(Name = "Peso Total")]
        [Range(0, 99999999999999, ErrorMessage = "Este Número deve ser positivo")]
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        public float PesoTotal { get; set; }
        [Display(Name = "Tanque")]
        public int TanqueIdTanque { get; set; }
        [Display(Name = "Tanque")]
        public Tanque TanqueIdTanqueNavigation { get; set; }
        public string data;
        public int isarchived { get; set; }
    }
}
