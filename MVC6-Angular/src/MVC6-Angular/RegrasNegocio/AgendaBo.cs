using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Angle_MVC6_Angular_Seed.Models.PessoaViewModels;
using Angle_MVC6_Angular_Seed.RegrasNegocio;
using Angle_MVC6_Angular_Seed.Dtos.AgendaDtos;
using Angle_MVC6_Angular_Seed.Models.Repositorio;
using Angle_MVC6_Angular_Seed.Models;

namespace Angle_MVC6_Angular_Seed.RegrasNegocio
{
    public class AgendaBo : IAgendaBo
    {
        public readonly IAgendaRepositorio _agendaRepositorio;

        public AgendaBo(IAgendaRepositorio agendaRepositorio)
        {
            _agendaRepositorio = agendaRepositorio;
        }

        public bool SalvarAgenda(AgendaDto agenda)
        {
            if (agenda.id > 0)
            {
                var agendaEntidade = _agendaRepositorio.Agenda(agenda.id);
                agendaEntidade.NmAgenda = agenda.nome;
                agendaEntidade.DtAlteracao = DateTime.Now;

                ConverterDto(agenda, agendaEntidade);

                _agendaRepositorio.Update(agendaEntidade);
            }
            else
            {
                var agendaEntidade = new TbAgenda();
                ConverterDto(agenda, agendaEntidade);

                _agendaRepositorio.Add(agendaEntidade);
            }

            //var entidade = _mapper.Map<AgendaDto, AgendaModel>(agenda);
            //entidade.DataUltimaAlteracao = DateTime.Now;

            return true;
        }

        private static void ConverterDto(AgendaDto agenda, TbAgenda agendaEntidade)
        {
            agendaEntidade.NmAgenda = agenda.nome;
            agendaEntidade.DtInclusao = DateTime.Now;

            agendaEntidade.TbTelefone = agenda.Telefones.Select(s => new TbTelefone()
            {
                CdTelefone = s.id,
                CdAgenda = agenda.id,
                CdTipoTelefone = s.tipo,
                DddTelefone = s.ddd,
                NrTelefone = s.numero,
                NmContato = s.nome,
                DtAlteracao = DateTime.Now,
                DtInclusao = DateTime.Now
            }).ToList();
        }
    }
}
