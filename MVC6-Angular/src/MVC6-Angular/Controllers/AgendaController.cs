using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Angle_MVC6_Angular_Seed.Models.PessoaViewModels;
using Angle_MVC6_Angular_Seed.RegrasNegocio;
using Angle_MVC6_Angular_Seed.Dtos.AgendaDtos;
using Angle_MVC6_Angular_Seed.Models;

namespace Angle_MVC6_Angular_Seed.Controllers
{
    public class AgendaController : Controller
    {
        //public readonly ElasticClient _client;
        public readonly IAgendaBo _agendaBo;

        public AgendaController(IAgendaBo agendaBo)
        {
            //var node = new Uri("http://localhost:9200");
            //var node = new Uri("https://x2zhpy3z:aw1xordolgdltk4z@azalea-9437794.us-east-1.bonsaisearch.net");

            //var settings = new ConnectionSettings(
            //    node
            //);

            //_client = new ElasticClient(settings);

            _agendaBo = agendaBo;
        }

        public IActionResult Index()
        {
            var t = new DB_AgendaContext();
            var aasd= t.TbAgenda;
            return View();
        }

        public IActionResult BuscaTipoTelefone()
        {
            return View();
        }

        public IActionResult BuscaAgenda()
        {
            return View();
        }

        public IActionResult BuscaTelefonesPorAgenda(int id)
        {
            return View();
        }

        public IActionResult SalvarAgenda(AgendaDto agenda)
        {
            var status = _agendaBo.SalvarAgenda(agenda);
            return View(status);
        }

        public IActionResult _InserirAgendaModal()
        {
            return PartialView();
        }

        public IActionResult _EditarAgendaModal()
        {
            return PartialView();
        }

        public IActionResult Pessoas()
        {          
            var person = new PessoaDto
            {
                Id = "1",
                Nome = "Martijn",
                Idade = 18,
                Genero = Sexo.Masculino
            };

            //var index = _client.Index(person, i => i
            //    .Index("teste"));

            //var searchResults = _client.Search<PessoaDto>(s => s
            //    .From(0)
            //    .Size(10)
            //    .Query(q => q
            //         .Term(p => p.Nome, "martijn")
            //    )
            //);

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
