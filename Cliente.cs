using System;

class Cliente : Pessoa
{
    //to-do: incluir o número do contrato
    string numeroContrato;

    public Cliente(int id, string nome) : base(id, nome) { }
}
