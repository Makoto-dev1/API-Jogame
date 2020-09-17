using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Jogame.Domains;
using API_Jogame.Interfaces;
using API_Jogame.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Jogame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadorRepository _jogadorRepository;

        public JogadoresController()
        {
            _jogadorRepository = new JogadorRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Lista os jogadores
                var jogadores = _jogadorRepository.Listar();

                //Verifica se existe jogadores, caso não exista 
                //NoContent - Sem conteudo 
                if (jogadores.Count == 0)
                    return NoContent();

                //Caso exista retorna "ok" e os jogadores
                return Ok(jogadores);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca o jogador
                var jogador = _jogadorRepository.BuscarPorId(id);

                //Verifica se existe jogadores 
                //caso não exista retorna NotFound
                if (jogador == null)
                    return NotFound();

                //Caso exista retorna "ok" e o jogador
                return Ok(jogador);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }

        // POST api/<RacaController>
        [HttpPost]
        public IActionResult Post( Jogador jogador)
        {
            try
            {
                _jogadorRepository.Cadastrar(jogador);

                return Ok(jogador);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogador jogador)
        {
            try
            {
                var jogadorTemp = _jogadorRepository.BuscarPorId(id);

                if (jogadorTemp == null)
                    return NotFound();

                jogador.Id = id;
                _jogadorRepository.Alterar(jogador);

                return Ok(jogador);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _jogadorRepository.Deletar(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }
    }
}
