using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;
using LesGrupo8Bioterio;
using LesGrupo8Bioterio.Models;
using System.Linq;
//needed for DisplayName annotation


namespace LesGrupo8Bioterio
{
    public partial class Projeto
    {
        public Projeto()
        {
            CircuitoTanque = new HashSet<CircuitoTanque>();
            Elementoequipa = new HashSet<Elementoequipa>();
            Ensaio = new HashSet<Ensaio>();
        }

        public int IdProjeto { get; set; }
        [Display(Name = "Nome do Projeto")]
        public string Nome { get; set; }
        [Display(Name = "Data de Inicio do projeto")]
        public DateTime DataInicio { get ; set; }
        [Display(Name = "Data de Fim do projeto")]
        public DateTime DataFim { get; set; }
        [Display(Name = "Aut. DGVA")]
        public string AutorizacaoDgva { get; set; }
        [Display(Name = "Ref. Orbea")]
        public int? RefOrbea { get; set; }
        [Display(Name = "Sub. Inst. Europeias")]
        public Boolean? SubmisInsEurop { get; set; }
        [Display(Name = "Nº de Animais Autorizados")]
        public int? NroAnimaisAutoriz { get; set; }
        public CircuitoTanque objetoCT;
        public IQueryable<Ensaio> objetoEN;
        public IQueryable<Elementoequipa> objetoEE;
        public Elementoequipa dummyEE;
        public Ensaio dummyEnsaio;
        public ICollection<CircuitoTanque> CircuitoTanque { get; set; }
        public ICollection<Elementoequipa> Elementoequipa { get; set; }
        public ICollection<Ensaio> Ensaio { get; set; }
    }
}
