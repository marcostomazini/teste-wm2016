using System;
using System.Collections.Generic;

namespace Angle_MVC6_Angular_Seed.Models
{
    public partial class TbTipoTelefone
    {
        public TbTipoTelefone()
        {
            TbTelefone = new HashSet<TbTelefone>();
        }

        public int CdTipoTelefone { get; set; }
        public string NmTipoTelefone { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }

        public virtual ICollection<TbTelefone> TbTelefone { get; set; }
    }
}
