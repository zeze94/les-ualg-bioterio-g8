using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation

namespace LesGrupo8Bioterio
{
    public partial class RegCondAmb
    {
        public int IdRegCondAmb { get; set; }
        [Display(Name = "Data")]
        public DateTime Data { get; set; }
        [Display(Name = "Temperatura")]
        public float? Temperatura { get; set; }
        [Display(Name = "Volume de Água")]
        public float? VolAgua { get; set; }
        [Display(Name = "Salinidae da água")]
        public float? SalinidadeAgua { get; set; }
        [Display(Name = "Nível de Oxigénio")]
        public float? NivelO2 { get; set; }
        [Display(Name = "Circuito Tanque")]
        public int CircuitoTanqueIdCircuito { get; set; }
        [Display(Name = "Circuito Tanque")]
        public CircuitoTanque CircuitoTanqueIdCircuitoNavigation { get; set; }
        public string data;
        public int isarchived { get; set; }
    }
}
