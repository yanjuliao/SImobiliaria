using System;
using System.IO;
using System.Collections;

namespace SJImobiliaria
{

    class EAbort : Exception
    {
        public EAbort(string message) : base(message) { }
    }

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

    class Pessoa
    {
        int id;
        string nome;

        public Pessoa(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public int getId()
        {
            return this.id;
        }

        public string getNome()
        {
            return this.nome;
        }
    }

    class Cliente : Pessoa
    {
        //to-do: incluir o número do contrato
        string numeroContrato;

        public Cliente(int id, string nome) : base(id, nome) { }
    }

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

        public Movimentacao getUltimaMovimentacaoByImovel(int id)
        {
            Movimentacao ultimaMovimentacao = null;

            foreach (Movimentacao movimentacao in movimentacoes)
            {
                if (movimentacao.getIdImovel() == id)
                {
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

                Console.WriteLine("Digite 1 para continuar o cadastro ou 0 para ecerrar o cadasrto");
                txtLido = Console.ReadLine();

                while (txtLido != "1" && txtLido != "0")
                {
                    Console.WriteLine("Ops... parece que você digitou outro valor, tente novamente!!!!");
                    Console.WriteLine("Digite 1 para continuar o cadastro ou 0 para ecerrar o cadasrto");
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
            //to-do: colocar para exibir os dados da casa e do apartamento que não estão sendo listados

            Console.WriteLine("Id | Descricao | Situacao | Medida Area Externa | Andar");

            foreach (Imovel imovel in imoveis)
            {
                if ((imovel.getSituacao() == situacao) || (situacao == ""))
                {
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine(imovel.getId().ToString() + " | " + imovel.getDescricao() + " | " + imovel.getSituacao());
                }
            }

        }

        public void listarClientes()
        {
            //to-do: listar o número do contrato

            Console.WriteLine("Id | Nome | Número Contrato");

            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(cliente.getId().ToString() + " | " + cliente.getNome());
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

            Console.WriteLine("Locação realizada com sucesso!");
        }

        public void finalizarEscritoresLocacao()
        {
            int idLido;

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite o ID do imóvel que deseja finalizarEscritores a locação: ");
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

    class Program
    {
        static string txtLido;

        static void lerOpcaoMenuPrincipal()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite 0 para cadastrar imóvel ");
            Console.WriteLine("Digite 1 para cadastrar cliente ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite 2 para listar todos os imóveis ");
            Console.WriteLine("Digite 3 para listar os imóveis disponíves");
            Console.WriteLine("Digite 4 para listar os imóveis alugados");
            Console.WriteLine("Digite 5 para listar os imóveis vendidos");
            Console.WriteLine("Digite 6 para listar os clientes ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite 7 para locação.");
            Console.WriteLine("Digite 8 para finalizarEscritores locação.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite 9 para vendas.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite outra tecla para sair.");
            txtLido = Console.ReadLine();
        }

        static void retornarMenuPrincipal()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Informe qualquer tecla para retornar ao MENU PRINCIPAL!");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Imobiliaria imobiliaria = Repositorio.getImobiliaria();

            lerOpcaoMenuPrincipal();

            while (txtLido != "")
            {
                try
                {
                    if (txtLido == "0")
                    {
                        imobiliaria.cadastrarImovel();
                        Repositorio.salvarImobiliaria(imobiliaria);
                    }
                    else if (txtLido == "1")
                    {
                        imobiliaria.cadastrarCliente();
                        Repositorio.salvarImobiliaria(imobiliaria);
                    }
                    else if (txtLido == "2")
                    {
                        imobiliaria.listarImoveis();
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "3")
                    {
                        imobiliaria.listarImoveis("Disponivel");
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "4")
                    {
                        imobiliaria.listarImoveis("Alugado");
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "5")
                    {
                        imobiliaria.listarImoveis("Vendido");
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "6")
                    {
                        imobiliaria.listarClientes();
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "7")
                    {
                        imobiliaria.alugarImovel();
                        Repositorio.salvarImobiliaria(imobiliaria);
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "8")
                    {
                        imobiliaria.finalizarEscritoresLocacao();
                        Repositorio.salvarImobiliaria(imobiliaria);
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "9")
                    {
                        imobiliaria.venderImovel();
                        Repositorio.salvarImobiliaria(imobiliaria);
                        retornarMenuPrincipal();
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception erro)
                {
                    if (erro is EAbort)
                    {
                        Console.WriteLine("Operação abortada. Descrição: " + erro.Message);
                    }
                    else
                    {
                        Console.WriteLine("Ocorreu um erro inesperado. Descrição: " + erro.Message);
                    }
                }

                lerOpcaoMenuPrincipal();
            }
        }
    }
}