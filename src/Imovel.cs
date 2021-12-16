using System;

namespace SJImobiliaria
{
    class Imovel
    {
        int id;
        string descricao;
        string situacao;

        public Imovel(int id, string descricao, string situacao)
        {
            this.id = id;
            this.descricao = descricao;
            this.situacao = situacao;
        }

        public int getId()
        {
            return this.id;
        }

        public string getDescricao()
        {
            return this.descricao;
        }

        public string getSituacao()
        {
            return this.situacao;
        }

        public void setSituacao(string situacao)
        {
            if ((situacao == "Disponivel") || (situacao == "Alugado") || (situacao == "Vendido"))
                this.situacao = situacao;
            else
                throw new EAbort("A situação é inválida ou não foi informada");
        }
    }
}
