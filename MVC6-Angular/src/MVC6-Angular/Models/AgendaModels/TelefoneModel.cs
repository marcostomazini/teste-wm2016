using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Angle_MVC6_Angular_Seed.Models.AgendaModels
{
    public class TelefoneModel : Entidade
    {
        [Required]
        public string Numero { get; set; }

        [Required]
        public string Ddd { get; set; }        
    }
}
