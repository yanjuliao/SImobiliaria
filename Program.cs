using System;
using System.Collections;

namespace SJImobiliaria
{
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
        int id;
        int idImovel;
        int idCliente;
        string situacao;
    }

    class Imobiliaria
    {
        ArrayList clientes = new ArrayList();
        ArrayList imoveis = new ArrayList();
        ArrayList movimentacoes = new ArrayList();

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

                    imovel.situacao = "Disponível";
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

                    imovel.situacao = "Disponível";
                    imovel.id = imoveis.Count + 1;

                    imoveis.Add(imovel);
                }

                Console.WriteLine("Digite 1 para continuar o cadastro ou 0 para ecerrar o cadasrto");
                txtLido = Console.ReadLine();

                while (txtLido != "1" && txtLido != "2")
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

        public void listarImoveis(string situacao = "")
        {
            Console.WriteLine("Id | Descricao | Situacao");

            foreach (Imovel imovel in imoveis)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(imovel.id.ToString() + " | " + imovel.descricao + " | " + imovel.situacao);
            }

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Informe qualquer tecla para retornar ao MENU PRINCIPAL!");
            Console.ReadLine();
        }

        public void listarClientes()
        {
            Console.WriteLine("Id | Nome ");

            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine(cliente.id.ToString() + " | " + cliente.nome);
            }

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Informe qualquer tecla para retornar ao MENU PRINCIPAL!");
            Console.ReadLine();
        }

        public void alugarImovel(Movimentacao movimentacao)
        {
            
        }

        public void finalizarLocacao(Movimentacao movimentacao)
        {

        }

        public void venderImovel(Movimentacao movimentacao)
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
            Console.WriteLine("Digite 2 para listar os imóveis ");
            Console.WriteLine("Digite 3 para listar os clientes ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite 4 para locação.");
            Console.WriteLine("Digite 5 para finalizar locação.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite 6 para vendas.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite outra tecla para sair.");
            txtLido = Console.ReadLine();
        }

        static void Main(string[] args)
        {
            lerOpcaoMenuPrincipal();

            Imobiliaria imobiliaria = new Imobiliaria();

            while (txtLido != "")
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
                }
                else if (txtLido == "3")
                {
                    imobiliaria.listarClientes();
                }
                else if (txtLido == "4")
                {

                }
                else if (txtLido == "5")
                {

                }
                else if (txtLido == "6")
                {

                }
                else
                {
                    break;
                }

                lerOpcaoMenuPrincipal();
            }
        }
    }
}
