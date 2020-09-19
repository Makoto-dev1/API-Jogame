using API_Jogame.Context;
using API_Jogame.Domains;
using API_Jogame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly ContextJogame _ctx;    

        public JogoRepository()
        {
           _ctx = new ContextJogame();
        }

        #region Alterar
        #endregion

        #region BuscarID
        public Jogo BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Jogos.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Cadastrar
        public Jogo Cadastrar(List<JogoJogador> jogosJogadores) 
        {
            try
            {
                //Criaçao do objeto jogador passando os valores      
                Jogo jogo = new Jogo
                {
                    Nome = "Valorant",
                    DataLancamento = DateTime.Today
                };
 
                foreach (var item in jogosJogadores)
                {
                    //Adiciona um jogojogador a lista 
                    jogo.JogosJogadores.Add(new JogoJogador
                    {
                        IdJogo = jogo.Id,
                        Jogo = item.Jogo,
                        IdJogador = item.IdJogador,
                        Jogador = item.Jogador
                         
                    });
                }

                //Adicona o jogo ao contexto
                _ctx.Jogos.Add(jogo);
                //Salva as mudanças no banco 
                _ctx.SaveChanges();

                return jogo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Deletar
        #endregion

        #region Listar
        public List<Jogo> Listar()
        {
            try
            {
                return _ctx.Jogos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
