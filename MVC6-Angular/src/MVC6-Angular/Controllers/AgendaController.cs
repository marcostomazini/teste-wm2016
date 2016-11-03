using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Angle_MVC6_Angular_Seed.Models.PessoaViewModels;
using Angle_MVC6_Angular_Seed.RegrasNegocio;
using Angle_MVC6_Angular_Seed.Dtos.AgendaDtos;
using Angle_MVC6_Angular_Seed.Models;
using Angle_MVC6_Angular_Seed.Models.Repositorio;
using System.Net.Http;
using System.Net;

namespace Angle_MVC6_Angular_Seed.Controllers
{
    public class AgendaController : Controller
    {
        //public readonly ElasticClient _client;
        public readonly IAgendaBo _agendaBo;
        public readonly IAgendaRepositorio _agendaRepositorio;

        public AgendaController(IAgendaBo agendaBo, IAgendaRepositorio agendaRepositorio)
        {
            //var node = new Uri("https://x2zhpy3z:aw1xordolgdltk4z@azalea-9437794.us-east-1.bonsaisearch.net");

            //var settings = new ConnectionSettings(
            //    node
            //);

            //_client = new ElasticClient(settings);

            _agendaBo = agendaBo;
            _agendaRepositorio = agendaRepositorio;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult BuscaTiposTelefone()
        {
            var tiposTelefone = _agendaRepositorio.TiposTelefone();

            return Ok(tiposTelefone);
        }

        public IActionResult BuscaAgenda()
        {
            var agendas = _agendaRepositorio.Agendas();

            return Ok(agendas);
        }

        public IActionResult BuscaTelefonesPorId(int id)
        {
            var agendas = _agendaRepositorio.Agendas(id);

            return Ok(agendas);
        }

        [HttpPost]
        public IActionResult SalvarAgenda([FromBody]AgendaDto agenda)
        {
            var status = _agendaBo.SalvarAgenda(agenda);
            return Ok(status);
        }

        public IActionResult _InserirAgendaModal()
        {
            return PartialView();
        }

        public IActionResult _EditarAgendaModal()
        {
            return PartialView();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
