using System;
using System.Collections.Generic;

namespace Angle_MVC6_Angular_Seed.Models
{
    public partial class TbAgenda
    {
        public TbAgenda()
        {
            TbTelefone = new HashSet<TbTelefone>();
        }

        public int CdAgenda { get; set; }
        public string NmAgenda { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }

        public virtual ICollection<TbTelefone> TbTelefone { get; set; }
    }
}
