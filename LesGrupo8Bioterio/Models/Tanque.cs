using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LesGrupo8Bioterio;
using LesGrupo8Bioterio.Models;
namespace LesGrupo8Bioterio
{
    public partial class Tanque
    {
        public Tanque()
        {
            RegAlimentar = new HashSet<RegAlimentar>();
            RegAmostragens = new HashSet<RegAmostragens>();
            RegManutencao = new HashSet<RegManutencao>();
            RegRemocoes = new HashSet<RegRemocoes>();
            RegTratamento = new HashSet<RegTratamento>();
        }

        public int IdTanque { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Nº de Animais")]
        public int NroAnimais { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Sala")]
        public string Sala { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }
        [Display(Name = "Lote")]
        public int LoteIdLote { get; set; }
        [Display(Name = "Circuito Tanque")]
        public int CircuitoTanqueIdCircuito { get; set; }
        [Display(Name = "Circuito Tanque")]
        public CircuitoTanque CircuitoTanqueIdCircuitoNavigation { get; set; }
        [Display(Name = "Lote")]
        public Lote LoteIdLoteNavigation { get; set; }
        [Display(Name = "Registo Alimentar")]
        public ICollection<RegAlimentar> RegAlimentar { get; set; }
        [Display(Name = "Registo Amostragens")]
        public ICollection<RegAmostragens> RegAmostragens { get; set; }
        [Display(Name = "Registo Manutenção")]
        public ICollection<RegManutencao> RegManutencao { get; set; }
        [Display(Name = "Registo Remoções")]
        public ICollection<RegRemocoes> RegRemocoes { get; set; }
        [Display(Name = "Registo Tratamento")]
        public ICollection<RegTratamento> RegTratamento { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Identificador")]
        public string codidenttanque { get; set; }


        public IQueryable<RegTratamento> Tratamentos;
        public RegTratamento dummyTratamento;
        public IQueryable<RegAlimentar> regAlimentar;
        public RegAlimentar dummyAlimentar;

        public IQueryable<RegAmostragens> regAmostragem;
        public RegAmostragens dummyAmostragem;

        public IQueryable<RegManutencao> regManutencao;
        public RegManutencao dummyManutencao;

        public IQueryable<RegRemocoes> regRemocoes;
        public RegRemocoes dummyRemocoes;

        public Boolean isDeletable;

    }
}
