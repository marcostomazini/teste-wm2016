using Angle_MVC6_Angular_Seed.Dtos.AgendaDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angle_MVC6_Angular_Seed.Models.Repositorio
{
    public interface IAgendaRepositorio
    {
        /// <summary>
        ///     Metodo que retorna todas as agendas
        /// </summary>
        /// <returns></returns>
        IEnumerable<TbAgenda> Agendas();

        /// <summary>
        ///     Metodo que retorna a agenda por id e seus telefones
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AgendaDto Agendas(int id);

        /// <summary>
        ///     Metodo que retorna a agenda por id e seus telefones
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TbAgenda Agenda(int id);

        /// <summary>
        ///     Metodo que retorna todos os telefones
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<TbTelefone> Telefones(int id);

        /// <summary>
        ///     Metodo que retorna os tipos de telefone
        /// </summary>
        /// <returns></returns>
        IEnumerable<TbTipoTelefone> TiposTelefone();

        /// <summary>
        ///     Adiciona uma agenda
        /// </summary>
        /// <param name="agenda"></param>
        void Add(TbAgenda agenda);

        /// <summary>
        ///     Atualiza uma agenda e seus numeros
        /// </summary>
        /// <param name="agenda"></param>
        void Update(TbAgenda agenda);

        /// <summary>
        ///     Metodo que remove uma agenda
        /// </summary>
        /// <param name="agenda"></param>
        void Delete(int id);
    }
}
