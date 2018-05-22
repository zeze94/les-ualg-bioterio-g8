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
        public DateTime Data { get; set; }
        [Display(Name = "Peso Médio")]
        public float PesoMedio { get; set; }
        [Display(Name = "Numero de Individuos")]
        public int NroIndividuos { get; set; }
        [Display(Name = "Peso Total")]
        public float PesoTotal { get; set; }
        [Display(Name = "Tanque")]
        public int TanqueIdTanque { get; set; }
        [Display(Name = "Tanque")]
        public Tanque TanqueIdTanqueNavigation { get; set; }
        public string data;
    }
}
