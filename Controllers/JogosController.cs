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
    public class JogosController : ControllerBase
    {
        private readonly IJogoRepository _jogoRepository;

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpPost]
        public IActionResult Post(List<JogoJogador> jogosJogadores)
        {
            try
            {
                //Cadastra um jogo
                Jogo jogo = _jogoRepository.Cadastrar(jogosJogadores);
                return Ok(jogo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var jogos = _jogoRepository.Listar();

                if(jogos.Count == 0)
                    return NoContent();

                return Ok(jogos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var jogos = _jogoRepository.BuscarPorId(id);

                if (jogos == null)
                    return NotFound();

                return Ok(jogos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
