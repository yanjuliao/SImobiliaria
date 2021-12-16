using System;

namespace SJImobiliaria
{
    class Cliente : Pessoa
    {
        string numeroContrato;

        public Cliente(int id, string nome, string numeroContrato = "") : base(id, nome) 
        {
            this.numeroContrato = numeroContrato;
        }

        public void setNumeroContrato(string numeroContrato)
        {
            this.numeroContrato = numeroContrato;
        }

        public string getNumeroContrato()
        {
            return this.numeroContrato;
        }
    }
}
