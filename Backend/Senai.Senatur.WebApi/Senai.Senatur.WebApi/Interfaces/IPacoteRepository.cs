using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacoteRepository
    {
        List<Pacotes> Listar();
        List<Pacotes> ListarOrdem(string ordem);
        Pacotes BuscarPorId(int id);
        void Cadastrar(Pacotes novoPacote);
        void Atualizar(int id, Pacotes pacoteAtualizado);
        void Deletar(int id);
        List<Pacotes> BuscarPorAtivo(bool ativo);
        List<Pacotes> BuscarPorCidade(string cidade);
    }
}
