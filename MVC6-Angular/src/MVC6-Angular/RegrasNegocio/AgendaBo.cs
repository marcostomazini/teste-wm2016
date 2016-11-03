using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Angle_MVC6_Angular_Seed.Models.PessoaViewModels;
using Angle_MVC6_Angular_Seed.RegrasNegocio;
using Angle_MVC6_Angular_Seed.Dtos.AgendaDtos;

namespace Angle_MVC6_Angular_Seed.RegrasNegocio
{
    public class AgendaBo : IAgendaBo
    {
        public bool SalvarAgenda(AgendaDto agenda)
        {
            //var entidade = _mapper.Map<AgendaDto, AgendaModel>(agenda);
            //entidade.DataUltimaAlteracao = DateTime.Now;

            return true;
        }
    }
}
