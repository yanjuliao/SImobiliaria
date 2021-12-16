using System;

namespace 
class Movimentacao
{
    int id;
    int idImovel;
    int idCliente;
    string situacao;

    public Movimentacao(int id, int idImovel, int idCliente, string situacao)
    {
        this.id = id;
        this.idImovel = idImovel;
        this.idCliente = idCliente;
        this.situacao = situacao;
    }

    public int getId()
    {
        return this.id;
    }

    public int getIdImovel()
    {
        return this.idImovel;
    }

    public int getIdCliente()
    {
        return this.idCliente;
    }

    public string getSituacao()
    {
        return this.situacao;
    }
}
