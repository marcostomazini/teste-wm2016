using Angle_MVC6_Angular_Seed.Dtos.AgendaDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angle_MVC6_Angular_Seed.Models.Repositorio
{
    public class AgendaRepositorio : IAgendaRepositorio
    {
        private readonly DB_AgendaContext _dbContext;

        public AgendaRepositorio(DB_AgendaContext dbContext)
        {
            _dbContext = dbContext;
        }               

        public IEnumerable<TbAgenda> Agendas()
        {
            return _dbContext.TbAgenda.AsEnumerable();
        }

        public TbAgenda Agenda(int id)
        {
            return _dbContext.TbAgenda.FirstOrDefault(x => x.CdAgenda == id);
        }

        public AgendaDto Agendas(int id)
        {
            var agenda = _dbContext.TbAgenda
                .Where(x => x.CdAgenda == id)
                .FirstOrDefault();

            var telefones = _dbContext.TbTelefone
                .Where(x => x.CdAgenda == id)
                .AsEnumerable();

            agenda.TbTelefone = telefones.ToList();

            var dto = new AgendaDto()
            {
                id = agenda.CdAgenda,
                nome = agenda.NmAgenda,
                Telefones = agenda.TbTelefone.Select(s => new TelefoneDto()
                {
                    id = s.CdTelefone,
                    nome = s.NmContato,
                    ddd = s.DddTelefone,
                    numero = s.NrTelefone,
                    tipo = s.CdTipoTelefone
                }).ToList()
            };

            return dto;
        }

        public IEnumerable<TbTelefone> Telefones(int id)
        {
            return _dbContext.TbTelefone.Where(x => x.CdAgenda == id).AsEnumerable();
        }

        public IEnumerable<TbTipoTelefone> TiposTelefone()
        {
            return _dbContext.TbTipoTelefone.AsEnumerable();
        }

        public void Add(TbAgenda agenda)
        {
            _dbContext.TbAgenda.Add(agenda);
            _dbContext.SaveChanges();
        }

        public void Update(TbAgenda agenda)
        {
            _dbContext.TbAgenda.Update(agenda);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var agenda = Agenda(id);
            _dbContext.TbAgenda.Remove(agenda);
            _dbContext.SaveChanges();
        }
    }
}
