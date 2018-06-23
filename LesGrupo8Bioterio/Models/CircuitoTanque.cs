using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LesGrupo8Bioterio;
using LesGrupo8Bioterio.Models;

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
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Identificador")]
        public string CodigoCircuito { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Data Final")]
        public DateTime DataFinal { get; set; }
        [Display(Name = "Projeto")]
        public Projeto ProjetoIdProjetoNavigation { get; set; }
        [Display(Name = "Condição Ambiental")]
        public ICollection<RegCondAmb> RegCondAmb { get; set; }
        [Display(Name = "Tanque")]
        public ICollection<Tanque> Tanque { get; set; }
        public string dateFinal;
        public string dateCriacao;
        public IQueryable<Tanque> tanquesCol;
        public Tanque dummyTanque;

        public IQueryable<RegCondAmb> regCondAmb;
        public RegCondAmb dummyCondAmb;

        public Boolean isDeletable;

        public int isarchived { get; set; }

    }
}
