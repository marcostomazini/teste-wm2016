using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Elasticsearch.Net;
using Angle_MVC6_Angular_Seed.Models.PessoaViewModels;
using Angle_MVC6_Angular_Seed.RegrasNegocio;
using Angle_MVC6_Angular_Seed.Dtos.AgendaDtos;

namespace Angle_MVC6_Angular_Seed.RegrasNegocio
{
    public interface IAgendaBo
    {
        bool SalvarAgenda(AgendaDto agenda);
    }
}
