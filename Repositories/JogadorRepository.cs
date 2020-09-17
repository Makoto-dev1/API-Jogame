using API_Jogame.Context;
using API_Jogame.Domains;
using API_Jogame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly ContextJogame _ctx;
        //Método construtor
        public JogadorRepository()
        {                                  
            _ctx = new ContextJogame();
        }

        #region Alterar
        /// <summary>
        /// Altera um jogador
        /// </summary>
        /// <param name="jogador">Nome do jogador</param>
        /// <returns>Jogador editado</returns>
        public void Alterar(Jogador jogador)
        {
            try
            {
                Jogador jogadorTemp = BuscarPorId(jogador.Id);
                
                //verifica se ele existe
                //if (jogadorTemp == null) 
                // se o jogador nao existir retorna a mensagem abaixo
                // throw new Exception("Jogador não encontrado");

                // Caso exista altera suas propriedades 
                jogadorTemp.Nome = jogador.Nome;
                jogadorTemp.DataNascimento = jogador.DataNascimento;
                jogadorTemp.Email = jogador.Email;
                jogadorTemp.Senha = jogador.Senha;
                // Altera no banco 
                _ctx.Jogadores.Update(jogadorTemp);
                // salva no banco
                _ctx.SaveChanges();
            }
            catch (Exception ex) 
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region BuscarID
        /// <summary>
        /// Busca um Jogador pelo seu id
        /// </summary>
        /// <param name="id">Id do Jogador</param>
        /// <returns>Retorna o jogador que tem o id correspondido</returns>
        public Jogador BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Jogadores.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Cadastrar
        /// <summary>
        /// Adiciona um novo jogador
        /// </summary>
        /// <param name="jogador">Objeto do tipo jogador</param>
        public void Cadastrar(Jogador jogador)
        {
            try
            {
                _ctx.Jogadores.Add(jogador);
                /* Outras maneiras de adicionar
                _ctx.Entry(jogador).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _ctx.Set<Jogador>().Update(jogador); */
                
                // Salvando as alteraçoes no contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }         
        }
        #endregion

        #region Deletar
        /// <summary>
        /// Exclui os jogadores
        /// </summary>
        /// <param name="id">ID do jogador</param>
        public void Deletar(Guid id)
        {
            try
            {
                Jogador jogadorTemp = BuscarPorId(id);

                if (jogadorTemp == null)
                    // se o jogador nao existir retorna a mensagem abaixo
                    throw new Exception("Jogador não encontrado");
                                  

                //Remove o jogador do dbset
                _ctx.Jogadores.Remove(jogadorTemp);
                //salva as alteraçoes
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            
        }
        #endregion

        #region Listar
        /// <summary>
        /// Lista todos os jogadores cadastrados
        /// </summary>
        /// <returns>Retorna uma lista com jogadores</returns>
        public List<Jogador> Listar()
        {
            try
            {
                return _ctx.Jogadores.ToList();
            }
            catch (Exception ex) //retorna msg de erro
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
