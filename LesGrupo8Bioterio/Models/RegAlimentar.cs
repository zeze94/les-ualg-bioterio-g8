using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LesGrupo8Bioterio
{
    public partial class RegAlimentar
    {
        public int IdRegAlim { get; set; }
        [Display(Name = "Data")]
        public DateTime Data { get; set; }
        [Display(Name = "Peso")]
        public float Peso { get; set; }
        [Display(Name = "Sobras")]
        public float? Sobras { get; set; }
        [Display(Name = "Plano Alimentar")]
        public int PlanoAlimentarIdPlanAlim { get; set; }
        [Display(Name = "Tanque")]
        public int TanqueIdTanque { get; set; }
        [Display(Name = "Plano Alimentar")]
        public PlanoAlimentar PlanoAlimentarIdPlanAlimNavigation { get; set; }
        [Display(Name = "Tanque")]
        public Tanque TanqueIdTanqueNavigation { get; set; }
    }
}
