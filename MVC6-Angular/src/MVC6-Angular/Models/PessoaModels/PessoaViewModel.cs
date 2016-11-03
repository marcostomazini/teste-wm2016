using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Angle_MVC6_Angular_Seed.Models.PessoaViewModels
{
    public class PessoaDto
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public Sexo Genero { get; set; }

    }

    public enum Sexo
    {
        Masculino,
        Feminino
    }
}
