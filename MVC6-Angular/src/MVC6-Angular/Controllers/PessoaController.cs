using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Elasticsearch.Net;
using Angle_MVC6_Angular_Seed.Models.PessoaViewModels;

namespace Angle_MVC6_Angular_Seed.Controllers
{
    public class PessoaController : Controller
    {
        public readonly ElasticClient _client;

        public PessoaController()
        {
            //var node = new Uri("http://localhost:9200");
            var node = new Uri("https://x2zhpy3z:aw1xordolgdltk4z@azalea-9437794.us-east-1.bonsaisearch.net");

            var settings = new ConnectionSettings(
                node
            );

            _client = new ElasticClient(settings);
        }
        public IActionResult Index()
        {
            return View();
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

            var index = _client.Index(person, i => i
                .Index("teste"));

            var searchResults = _client.Search<PessoaDto>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                     .Term(p => p.Nome, "martijn")
                )
            );

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
