using System;
using System.Collections.Generic;

namespace Angle_MVC6_Angular_Seed.Models
{
    public partial class Telefones
    {
        public int CdTelefone { get; set; }
        public string NmContato { get; set; }
        public int NrTelefone { get; set; }
        public int DddTelefone { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }
        public int CdTipoTelefone { get; set; }
        public int CdAgenda { get; set; }

        public virtual Agenda CdAgendaNavigation { get; set; }
        public virtual TipoTelefones CdTipoTelefoneNavigation { get; set; }
    }
}
