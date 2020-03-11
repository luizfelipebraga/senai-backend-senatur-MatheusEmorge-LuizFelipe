using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SenaturContext ctx = new SenaturContext();

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).ToList();
        }

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            Usuarios usuarioLogado = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            return usuarioLogado;
        }
    }
}
