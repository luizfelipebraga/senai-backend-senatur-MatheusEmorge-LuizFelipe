using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        private IPacoteRepository pacoteRepository;
        public PacotesController()
        {
            pacoteRepository = new PacoteRepository();
        }
        /// <summary>
        /// Lista todos os pacotes
        /// </summary>
        /// <returns>Retorna uma lista de usuários e um status code 200 - Ok</returns>
        /// dominio/api/Pacotes
        [Authorize(Roles = "1")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(pacoteRepository.Listar());
        }
        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="novoPacote">Objeto novoPacote que será cadastrado</param>
        /// <returns>Retorna os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Pacotes
        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            pacoteRepository.Cadastrar(novoPacote);
            return StatusCode(201);
        }

        /// <summary>
        /// Busca um pacote através do seu ID
        /// </summary>
        /// <param name="id">ID do pacote que será buscado</param>
        /// <returns>Retorna um usuário buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Pacotes/1
        [Authorize(Roles = "1")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto usuarioBuscado que irá receber o pacote buscado no banco de dados
            Pacotes pacoteBuscado = pacoteRepository.BuscarPorId(id);

            // Verifica se algum tipo de pacote foi encontrado
            if (pacoteBuscado != null)
            {
                // Caso seja, retorna os dados buscados e um status code 200 - Ok
                return Ok(pacoteBuscado);
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum pacote encontrado para o identificador informado");
        }
        /// <summary>
        /// Atualiza um pacote existente
        /// </summary>
        /// <param name="id">ID do pacote que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto pacoteAtualizado que será atualizado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Pacotes/1
        [Authorize(Roles = "1")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pacotes pacoteAtualizado)
        {
            Pacotes pacoteBuscado = pacoteRepository.BuscarPorId(id);

            if (pacoteBuscado != null)
            {
                try
                {
                    pacoteRepository.Atualizar(id, pacoteAtualizado);
                    return NoContent();
                }

                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound
                    (
                        new
                        {
                            mensagem = "Pacote não encontrado",
                            erro = true
                        }
                    );
        }

        /// <summary>
        /// Deleta um pacote
        /// </summary>
        /// <param name="id">ID do pacote que será deletado</param>
        /// <returns>Retorna um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Pacotes/1
        [Authorize(Roles = "1")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint
        public IActionResult Delete(int id)
        {
            Pacotes pacoteDeletado = pacoteRepository.BuscarPorId(id);

            if (pacoteDeletado != null)
            {
                pacoteRepository.Deletar(id);
                return Ok($"O pacote{id} foi deletado");
            }
            return NotFound($"O pacote não foi encontrado");
        }
    }
}