using System;

namespace SJImobiliaria
{
    class Cliente : Pessoa
    {
        //to-do: incluir o número do contrato
        int numeroContrato;

        public Cliente(int id, string nome) : base(id, nome) 
        {   
        }

        public void setNumeroContrato(int numeroContrato)
        {
            this.numeroContrato = numeroContrato;
        }
        public int getNumeroContrato()
        {
            return this.numeroContrato;
        }
    }
}
