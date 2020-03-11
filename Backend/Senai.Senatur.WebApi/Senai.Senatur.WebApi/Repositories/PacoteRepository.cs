using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        SenaturContext ctx = new SenaturContext();

        public Pacotes BuscarPorId(int id)
        {
            return ctx.Pacotes.FirstOrDefault(p => p.IdPacote == id);
        }

        public void Atualizar(int id, Pacotes pacoteAtualizado)
        {
            var entity = BuscarPorId(id);

            if(entity != null)
            {
                entity.Ativo = pacoteAtualizado.Ativo;
                entity.DataIda = pacoteAtualizado.DataIda;
                entity.DataVolta = pacoteAtualizado.DataVolta;
                entity.Descricao = pacoteAtualizado.Descricao;
                entity.NomeCidade = pacoteAtualizado.NomeCidade;
                entity.NomePacote = pacoteAtualizado.NomePacote;
                entity.Valor = pacoteAtualizado.Valor;
            }

            ctx.Pacotes.Update(pacoteAtualizado);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os pacotes
        /// </summary>
        /// <returns>Retorna uma lista de pacotes e um status code 200 - Ok</returns>
        /// dominio/api/Usuarios
        public List<Pacotes> Listar()
        {
            return ctx.Pacotes.ToList();
        }

        public List <Pacotes> ListarOrdem(string ordem)
        {
            if (ordem == "ASC")
            {

                return ctx.Pacotes.OrderBy(p => p.Valor).ToList();
            }
            else {
                return ctx.Pacotes.OrderByDescending(p => p.Valor).ToList();
            }
        }


        public void Cadastrar (Pacotes novoPacote)
        {
            ctx.Pacotes.Add(novoPacote);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Pacotes.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

    }
}
