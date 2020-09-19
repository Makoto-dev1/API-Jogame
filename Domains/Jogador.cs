using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Domains
{
    public class Jogador : BaseDomain
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

        //Relacionamento com a tabela JogoJogador
        public List<JogoJogador> JogosJogadores { get; set; }
    }
}
