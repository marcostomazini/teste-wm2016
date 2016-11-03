using System;
using System.Collections.Generic;

namespace Angle_MVC6_Angular_Seed.Models
{
    public partial class Agenda
    {
        public Agenda()
        {
            Telefones = new HashSet<Telefones>();
        }

        public int CdAgenda { get; set; }
        public string NmAgenda { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }

        public virtual ICollection<Telefones> Telefones { get; set; }
    }
}
