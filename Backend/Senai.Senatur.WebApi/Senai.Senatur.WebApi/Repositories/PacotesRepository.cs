using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacotesRepository : IPacoteRepository
    {
        SenaturContext ctx = new SenaturContext();

        public List<Pacotes> Listar()
        {
            return ctx.Pacotes.ToList();
        }
    }
}
