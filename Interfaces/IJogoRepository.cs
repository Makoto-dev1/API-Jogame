using API_Jogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Interfaces
{
    interface IJogoRepository
    {
        public Jogo Cadastrar();

        public Jogo Alterar();

        public Jogo BuscarPorId();

        public void Deletar();

        public List<Jogo> Listar();
    }
}
