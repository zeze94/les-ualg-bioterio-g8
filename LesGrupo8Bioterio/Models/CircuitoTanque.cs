using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LesGrupo8Bioterio
{
    public partial class CircuitoTanque
    {
        public CircuitoTanque()
        {
            RegCondAmb = new HashSet<RegCondAmb>();
            Tanque = new HashSet<Tanque>();
        }
       
        public int IdCircuito { get; set; }
        [Display(Name = "Projeto")]
        public int ProjetoIdProjeto { get; set; }
        [Display(Name = "Codigo do Circuito")]
        public string CodigoCircuito { get; set; }
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }
        [Display(Name = "Data Final")]
        public DateTime DataFinal { get; set; }
        [Display(Name = "Projeto")]
        public Projeto ProjetoIdProjetoNavigation { get; set; }
        [Display(Name = "Condição Ambiental")]
        public ICollection<RegCondAmb> RegCondAmb { get; set; }
        [Display(Name = "Tanque")]
        public ICollection<Tanque> Tanque { get; set; }
    }
}
