using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Angle_MVC6_Angular_Seed.Models
{    
    public class Entidade    
    {
    	[Key]
    	public int Id  { get; set; }

    	[Required]
        public string Nome { get; set; }

		[Required]
    	public DateTime DataInclusao { get; set; }

    	public DateTime? DataAlteracao { get; set; }
    }
}
