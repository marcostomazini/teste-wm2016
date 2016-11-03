using Angle_MVC6_Angular_Seed.Models;
using System.Collections.Generic;

namespace Angle_MVC6_Angular_Seed.Dtos.AgendaDtos
{
    public class AgendaDto
    {
        public int id { get; set; }

        public string nome { get; set; }

        public virtual IList<TelefoneDto> Telefones { get; set; }
    }
}
