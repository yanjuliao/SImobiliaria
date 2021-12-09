# SJImobiliaria

Sistema de uma imobiliária que permite ao usuário controlar os imóveis da mesma, quais imóveis ela tem disponível, quais estão alugados, quais serão vendidos, quem são os residentes, entre outros...

--------------------------------------------------------------------------------------------------------------------------------------------------------------------

Relatório 25/11

Até o momento ainda estamos trabalhando na arquitetura do projeto, quais serão as classes e como irão funcionar. Estamos em fase de planejamento


--------------------------------------------------------------------------------------------------------------------------------------------------------------------

Relatório 12/11

Começei a programar o projeto, criei 5 classes, uma chamada Imóvel e duas que herdam dela chamadas, casa e apartamento, uma classe morador e uma classe imobiliaria. Na classe Imóvel já crieis os atributos bases e também iniciei a concepção da classe casa que possui 2 Métodos, CadastrarCasa() e ExcluirCasa().

Abaixo um pouco do que já fiz: 

using System;

class Imovel
{
    private double Area, CEP, PreçoLocação;
    public bool Alugado;

    public void SetArea(double area)
    {
        Area = area;
    }

    public void SetCEP(double cep)
    {
       CEP = cep;
    }

    public void GetArea()
    {
        Console.WriteLine(Area);
    }

    public void GetCEP()
    {
        Console.WriteLine(CEP);
    }

    class Casa : Imovel
    {
        string Endereço;

        public void CadastrarCasa( double area, double preçolocação, string endereço, double cep)
        {
            Console.WriteLine("Informe a area da casa em m²: ");
            area = Convert.ToDouble(Console.ReadLine());
            SetArea(area);

            Console.WriteLine("Informe o endereço da casa: ");
            endereço = Console.ReadLine();
            Endereço = endereço;

            Console.WriteLine("Informe o CEP: ");
            cep = Convert.ToDouble(Console.ReadLine());
            SetCEP(cep);
            
            Console.WriteLine("Informe o preço de locação da casa: ");
            preçolocação = Convert.ToDouble(Console.ReadLine());
            PreçoLocação = preçolocação;
        }

        public void ExcluirCasa()
        {
            SetArea(0);
            Endereço = "";
            PreçoLocação = 0;
            SetCEP(0);
        }
    }

    class Apartamento : Imovel
    {

    }

    class Morador
    {

    }

    class Imobiliaria
    {
        Casa[] CasasAlugadas = new Casa[100];
        Casa[] CasasDisponíveis = new Casa[100];
    }

    class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }
}

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

Relatório 09/12

Modifiquei basicamente toda a estrutura do sistema, troquei a classe morador por pessoa e cliente que herda de pessoa, criei também um menu na main como parte principal do código e comecei a implementar os métodos.
A maioria dos atributos das classes também foi trocado porque iria ficar muito complexo o sistema, então resolvi deixar ele mais enxuto.
Assim está o código neste momento: 

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
