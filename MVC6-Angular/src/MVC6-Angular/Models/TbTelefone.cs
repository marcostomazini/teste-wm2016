using System;
using System.Collections.Generic;

namespace Angle_MVC6_Angular_Seed.Models
{
    public partial class TbTelefone
    {
        public int CdTelefone { get; set; }
        public string NmContato { get; set; }
        public string NrTelefone { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }
        public int CdAgenda { get; set; }
        public int CdTipoTelefone { get; set; }
        public int DddTelefone { get; set; }

        public virtual TbAgenda CdAgendaNavigation { get; set; }
        public virtual TbTipoTelefone CdTipoTelefoneNavigation { get; set; }
    }
}
