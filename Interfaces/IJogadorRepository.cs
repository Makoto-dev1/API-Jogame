using API_Jogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Interfaces
{
    interface IJogadorRepository
    {
        public void Cadastrar(Jogador jogador);

        public void Alterar(Jogador jogador);

        public Jogador BuscarPorId(Guid id);

        public void Deletar(Guid id);

        public List<Jogador> Listar();
    }
}
