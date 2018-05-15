﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation
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

        [Display(Name = "Nº de Animais")]
        public int NroAnimais { get; set; }

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
    }
}
