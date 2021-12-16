using System;

class Casa : Imovel
{
    double medidaAreaExterna;

    public Casa(int id, string descricao, string situacao, double medidaAreaExterna) : base(id, descricao, situacao)
    {
        this.medidaAreaExterna = medidaAreaExterna;
    }

    public double getMedidaAreaExterna()
    {
        return this.medidaAreaExterna;
    }
}
