using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angle_MVC6_Angular_Seed.Models.AgendaModels
{
    [Table("tbAgenda")]
    public class AgendaModel : Entidade
    {
        public virtual IList<TelefoneModel> Telefones { get; set; }
    }
}
