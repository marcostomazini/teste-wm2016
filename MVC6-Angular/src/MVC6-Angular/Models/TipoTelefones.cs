using System;
using System.Collections.Generic;

namespace Angle_MVC6_Angular_Seed.Models
{
    public partial class TipoTelefones
    {
        public TipoTelefones()
        {
            Telefones = new HashSet<Telefones>();
        }

        public int CdTipoTelefone { get; set; }
        public string NmTipoTelefone { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }

        public virtual ICollection<Telefones> Telefones { get; set; }
    }
}
