using System;

namespace SJImobiliaria
{
    class Apartamento : Imovel
    {
        int andar;

        public Apartamento(int id, string descricao, string situacao, int andar) : base(id, descricao, situacao)
        {
            this.andar = andar;
        }

        public int getAndar()
        {
            return this.andar;
        }
    }
}