using System;
using System.Collections.Generic;

namespace LesGrupo8Bioterio.Models
{
    public partial class Conselho
    {
        public Conselho()
        {
            Localcaptura = new HashSet<Localcaptura>();
        }

        public int Id { get; set; }
        public string NomeConselho { get; set; }
        public int DistritoId { get; set; }

        public Distrito Distrito { get; set; }
        public ICollection<Localcaptura> Localcaptura { get; set; }
    }
}
