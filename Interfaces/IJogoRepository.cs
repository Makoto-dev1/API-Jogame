using API_Jogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Interfaces
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Cadastra um jogo
        /// </summary>
        /// <param name="jogosJogadores">Jogos</param>
        /// <returns>Jogo cadastrado</returns>
        Jogo Cadastrar(List<JogoJogador> jogosJogadores);

        Jogo BuscarPorId(Guid id);

        List<Jogo> Listar();
        
    }
}
