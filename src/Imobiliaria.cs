using System;
using System.Collections;

namespace SJImobiliaria
{
    class Imobiliaria
    {
        ArrayList clientes = new ArrayList();
        ArrayList imoveis = new ArrayList();
        ArrayList movimentacoes = new ArrayList();

        public Imobiliaria(ArrayList clientes, ArrayList imoveis, ArrayList movimentacoes)
        {
            this.clientes = clientes;
            this.imoveis = imoveis;
            this.movimentacoes = movimentacoes;
        }

        public ArrayList getClientes()
        {
            return this.clientes;
        }

        public ArrayList getImoveis()
        {
            return this.imoveis;
        }

        public ArrayList getMovimentacoes()
        {
            return this.movimentacoes;
        }

        public Imovel getImovelById(int id)
        {
            foreach (Imovel imovel in imoveis)
            {
                if (imovel.getId() == id)
                {
                    return imovel;
                }
            }
            return null;
        }

        public Cliente getClienteById(int id)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.getId() == id)
                {
                    return cliente;
                }
            }
            return null;
        }

        public int getClienteByNumContrato(int numContrato)
        {
            if (numContrato != 0)
            {
                return numContrato + 1;
            }
            return 1;
        }

        public Movimentacao getUltimaMovimentacaoByImovel(int id)
        {
            int idUltimaMovimentacao = 0;
            Movimentacao ultimaMovimentacao = null;

            foreach (Movimentacao movimentacao in movimentacoes)
            {
                if ((movimentacao.getIdImovel() == id) && (movimentacao.getId() > idUltimaMovimentacao))
                {
                    idUltimaMovimentacao = movimentacao.getId();
                    ultimaMovimentacao = movimentacao;
                }
            }

            return ultimaMovimentacao;
        }

        public void cadastrarImovel()
        {
            string txtLido = "1";
            while (txtLido == "1")
            {
                Console.WriteLine("Digite 1 para casa ou pressione ou 2 para apartamento.");
                txtLido = Console.ReadLine();

                while (txtLido != "1" && txtLido != "2")
                {
                    Console.WriteLine("Ops... parece que você digitou outro valor, tente novamente!!!!");
                    Console.WriteLine("Digite 1 para casa ou pressione ou 2 para apartamento.");
                    txtLido = Console.ReadLine();
                }

                if (txtLido == "1")
                {
                    Console.WriteLine("Informe a descrição da casa, Ex: Casa, 3 quartos.");
                    string descricao = Console.ReadLine();

                    Console.WriteLine("Informe a metragem da área externa em m².");
                    double medidaAreaExterna = Convert.ToDouble(Console.ReadLine());

                    string situacao = "Disponivel";
                    int id = imoveis.Count + 1;

                    Casa imovel = new Casa(id, descricao, situacao, medidaAreaExterna);

                    imoveis.Add(imovel);
                }
                else if (txtLido == "2")
                {
                    Console.WriteLine("Informe a descrição do apartamento, Ex: Apartamento, 3 quartos.");
                    string descricao = Console.ReadLine();

                    Console.WriteLine("Informe o andar do apartamento.");
                    int andar = Convert.ToInt32(Console.ReadLine());

                    string situacao = "Disponivel";
                    int id = imoveis.Count + 1;

                    Apartamento imovel = new Apartamento(id, descricao, situacao, andar);

                    imoveis.Add(imovel);
                }

                Console.WriteLine("Digite 1 para continuar o cadastro ou 0 para encerrar o cadastro");
                txtLido = Console.ReadLine();

                while (txtLido != "1" && txtLido != "0")
                {
                    Console.WriteLine("Ops... parece que você digitou outro valor, tente novamente!!!!");
                    Console.WriteLine("Digite 1 para continuar o cadastro ou 0 para encerrar o cadastro");
                    txtLido = Console.ReadLine();
                }
            }
        }

        public void cadastrarCliente()
        {
            string txtLido = "1";
            while (txtLido == "1")
            {
                Console.WriteLine("Informe o nome do cliente");
                string nome = Console.ReadLine();
                int id = clientes.Count + 1;
                Cliente cliente = new Cliente(id, nome);

                clientes.Add(cliente);

                Console.WriteLine("Digite 1 para continuar o cadastro ou 0 para ecerrar o cadastro");
                txtLido = Console.ReadLine();

                while (txtLido != "1" && txtLido != "0")
                {
                    Console.WriteLine("Ops... parece que você digitou outro valor, tente novamente!!!!");
                    Console.WriteLine("Digite 1 para continuar o cadastro ou 0 para ecerrar o cadasrto");
                    txtLido = Console.ReadLine();
                }
            }
        }

        public void listarImoveis(String situacao = "")
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Id | Descricao | Situacao | Medida Area Externa | Andar");

            foreach (Imovel imovel in imoveis)
            {
                if ((imovel.getSituacao() == situacao) || (situacao == ""))
                {
                    if (imovel is Casa)
                    {
                        Casa casa = imovel as Casa;
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine(casa.getId().ToString() + " | " + casa.getDescricao() + " | " + casa.getSituacao() + " | " +  casa.getMedidaAreaExterna() + " | " + "" + " | ");
                    }
                    else if (imovel is Apartamento)
                    {
                        Apartamento apartamento = imovel as Apartamento;
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine(apartamento.getId().ToString() + " | " + apartamento.getDescricao() + " | " + apartamento.getSituacao() + " | " + "" + " | " + apartamento.getAndar() + " | ");
                    }
                }
            }

        }

        public void listarClientes()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Id | Nome | Número Contrato");

            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(cliente.getId().ToString() + " | " + cliente.getNome() + " | " + cliente.getNumeroContrato());
            }

        }

        public void alugarImovel()
        {
            int idLido;

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite o ID do imóvel que deseja locar: ");
            idLido = Convert.ToInt32(Console.ReadLine());

            Imovel imovel = this.getImovelById(idLido);

            if (imovel == null)
            {
                throw new EAbort("O imóvel não foi localizado!");
            }

            if (imovel.getSituacao() != "Disponivel")
            {
                throw new EAbort("O imóvel não está disponível!");
            }

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite o ID do cliente que está locando este imóvel: ");
            idLido = Convert.ToInt32(Console.ReadLine());

            Cliente cliente = this.getClienteById(idLido);

            if (cliente == null)
            {
                throw new EAbort("O clientel não foi localizado!");
            }

            Movimentacao movimentacao = new Movimentacao(this.movimentacoes.Count + 1, imovel.getId(), cliente.getId(), "Aluguel");

            this.movimentacoes.Add(movimentacao);

            imovel.setSituacao("Alugado");
            cliente.setNumeroContrato(getClienteByNumContrato(0));
            Console.WriteLine("Locação realizada com sucesso!");
        }

        public void finalizarLocacao()
        {
            int idLido;

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite o ID do imóvel que deseja finalizar a locação: ");
            idLido = Convert.ToInt32(Console.ReadLine());

            Imovel imovel = this.getImovelById(idLido);

            if (imovel == null)
            {
                throw new EAbort("O imóvel não foi localizado!");
            }

            if (imovel.getSituacao() != "Alugado")
            {
                throw new EAbort("O imóvel não está alugado!");
            }

            Movimentacao ultimaMovimentacao = this.getUltimaMovimentacaoByImovel(imovel.getId());

            if (ultimaMovimentacao == null)
            {
                throw new EAbort("A movimentação do imóvel não foi localizada!");
            }

            if (ultimaMovimentacao.getSituacao() != "Aluguel")
            {
                throw new EAbort("A última movimentação do imóvel não foi de locação.");
            }

            Movimentacao movimentacao = new Movimentacao(this.movimentacoes.Count + 1, imovel.getId(), ultimaMovimentacao.getIdCliente(), "Finalização da locação");
            
            this.movimentacoes.Add(movimentacao);

            imovel.setSituacao("Disponivel");

            Console.WriteLine("Finalização da locação realizada com sucesso!");
        }

        public void venderImovel()
        {
            int idLido;

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite o ID do imóvel que deseja vender: ");
            idLido = Convert.ToInt32(Console.ReadLine());

            Imovel imovel = this.getImovelById(idLido);

            if (imovel == null)
            {
                throw new EAbort("O imóvel não foi localizado!");
            }

            if (imovel.getSituacao() != "Disponivel")
            {
                throw new EAbort("O imóvel não está disponível!");
            }

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite o ID do cliente que está comprando este imóvel: ");
            idLido = Convert.ToInt32(Console.ReadLine());

            Cliente cliente = this.getClienteById(idLido);

            if (cliente == null)
            {
                throw new EAbort("O clientel não foi localizado!");
            }

            Movimentacao movimentacao = new Movimentacao(this.movimentacoes.Count + 1, imovel.getId(), cliente.getId(), "Venda");

            this.movimentacoes.Add(movimentacao);

            imovel.setSituacao("Vendido");

            Console.WriteLine("Venda realizada com sucesso!");
        }
    }
}
