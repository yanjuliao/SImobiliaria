using System;
using System.Collections;

namespace SJImobiliaria
{

    class EAbort : Exception { 
        public EAbort(string message): base (message) { }
    }

    class Imovel
    {
        public int id;
        public string descricao;
        public string situacao;
    }

    class Apartamento : Imovel
    {
        public int andar;
    }

    class Casa : Imovel
    {
        public double medidaAreaExterna;
    }

    class Pessoa
    {
       public int id;
       public string nome;
    }

    class Cliente : Pessoa
    {
        public string numeroContrato;
    }

    class Movimentacao
    {
        public int id;
        public int idImovel;
        public int idCliente;
        public string situacao;
    }

    class Imobiliaria
    {
        ArrayList clientes = new ArrayList();
        ArrayList imoveis = new ArrayList();
        ArrayList movimentacoes = new ArrayList();

         public Imovel getImovelById(int id)
        {            
            foreach (Imovel imovel in imoveis)
            {                
                if (imovel.id == id)
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
                if (cliente.id == id)
                {
                    return cliente;
                }
            }
            return null;
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
                    Casa imovel = new Casa();
                    Console.WriteLine("Informe a descrição da casa, Ex: Casa, 3 quartos.");
                    imovel.descricao = Console.ReadLine();

                    Console.WriteLine("Informe a metragem da área externa em m².");
                    imovel.medidaAreaExterna = Convert.ToDouble(Console.ReadLine());

                    imovel.situacao = "Disponivel";
                    imovel.id = imoveis.Count + 1;

                    imoveis.Add(imovel);
                }
                else if (txtLido == "2")
                {
                    Apartamento imovel = new Apartamento();
                    Console.WriteLine("Informe a descrição do apartamento, Ex: Apartamento, 3 quartos.");
                    imovel.descricao = Console.ReadLine();

                    Console.WriteLine("Informe o andar do apartamento.");
                    imovel.andar = Convert.ToInt32(Console.ReadLine());

                    imovel.situacao = "Disponivel";
                    imovel.id = imoveis.Count + 1;

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
                Cliente cliente = new Cliente();
                Console.WriteLine("Informe o nome do cliente");
                cliente.nome = Console.ReadLine();
                cliente.id = clientes.Count + 1;

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
            Console.WriteLine("Id | Descricao | Situacao");

            foreach (Imovel imovel in imoveis)
            {
                if((imovel.situacao == situacao) || (situacao == "")) { 
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine(imovel.id.ToString() + " | " + imovel.descricao + " | " + imovel.situacao);
                }
            }
       
        }

        public void listarClientes()
        {
            Console.WriteLine("Id | Nome ");

            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(cliente.id.ToString() + " | " + cliente.nome);
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

            if(imovel.situacao != "Disponivel")
            {
                throw new EAbort("O imóvel não está disponível!");
            }

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite o ID do cliente que está locando este imóvel: ");
            idLido = Convert.ToInt32(Console.ReadLine());

            Cliente cliente = this.getClienteById(idLido);

            if (cliente == null)
            {
                throw new Exception("O clientel não foi localizado!");
            }

            Movimentacao movimentacao = new Movimentacao();
            movimentacao.id = this.movimentacoes.Count + 1;
            movimentacao.idImovel = imovel.id;
            movimentacao.idCliente = cliente.id;
            movimentacao.situacao = "Aluguel";

            this.movimentacoes.Add(movimentacao);

            imovel.situacao = "Alugado";

            Console.WriteLine("Locação realizada com sucesso!");
        }

        public void finalizarLocacao()
        {

        }

        public void venderImovel()
        {

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
            Console.WriteLine("Digite 8 para finalizar locação.");
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
            lerOpcaoMenuPrincipal();

            Imobiliaria imobiliaria = new Imobiliaria();

            while (txtLido != "")
            {
                try
                {
                    if (txtLido == "0")
                    {
                        imobiliaria.cadastrarImovel();
                    }
                    else if (txtLido == "1")
                    {
                        imobiliaria.cadastrarCliente();
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
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "8")
                    {

                    }
                    else if (txtLido == "9")
                    {

                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception erro)
                {
                    if(erro is EAbort)
                    {
                        Console.WriteLine("Operação abortada. Descrição: " + erro.Message);
                    } else
                    {
                        Console.WriteLine("Ocorreu um erro inesperado. Descrição: " + erro.Message);
                    }
                }

                lerOpcaoMenuPrincipal();
            }
        }
    }
}
